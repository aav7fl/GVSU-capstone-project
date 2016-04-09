using System.Collections.Generic;
using GVSU.BusinessLogic;
using GVSU.Contracts;
using GVSU.Simulators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System;
using System.IO;

namespace GVSU.Tests
{
    [TestClass]
    public class AssemblyInitializers
    {
        public static IWebDriver driverFF { get; set; }
        public static IWebDriver driverGC { get; set; }
        public static List<IWebDriver> drivers = new List<IWebDriver>();

        public static string WebsiteAddress
        {
            get
            {
                var url = "";
#if DEBUG
                url = ConfigurationManager.AppSettings["LocalUrl"];
#else
                url = "https://gvsuciscapstone.azurewebsites.net/";
#endif
                //Console.WriteLine("URL:" + ConfigurationManager.AppSettings["LocalUrl"]);
                return url;
            }
        }

        [AssemblyInitialize]
        public static void Init(TestContext context)
        {
            Factory.Register<IVolunteerService>(() => new VolunteerServiceSimulator());
            driverFF = new FirefoxDriver();
            driverGC = new ChromeDriver(@".\chromedriver_win32\");
            

            //Add drivers to the list to be used in a for-each method for browser testing
            drivers.Add(driverGC);
            drivers.Add(driverFF);
        }
        

        [AssemblyCleanup]
        public static void TearDown()
        {
            driverFF.Quit(); //exit Firefox selenium driver at the end of the test
            driverGC.Quit(); //exit Google Chrome selenium driver at the end of the test
        }


        private Process _process;
        private ManualResetEventSlim _manualResetEvent;

        /// <summary>
        /// Starts the IISExpress process that hosts the test site.
        /// </summary>
        public void Start()
        {
            _manualResetEvent = new ManualResetEventSlim(false);

            var thread = new Thread(StartIisExpress) { IsBackground = true };
            thread.Start();

            if (!_manualResetEvent.Wait(15000))
                throw new Exception("Could not start IIS Express");

            _manualResetEvent.Dispose();
        }

        private void StartIisExpress()
        {
            var startInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Minimized,
                //CreateNoWindow = !_options.ShowIisExpressWindow,
                //Arguments = string.Format("/config:\"{0}\" /systray:true", applicationHostPath)
            };

            var programfiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            startInfo.FileName = programfiles + "\\IIS Express\\iisexpress.exe";

            try
            {
                _process = new Process { StartInfo = startInfo };

                _process.Start();
                _manualResetEvent.Set();
                _process.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error starting IIS Express: " + ex);
                _process.CloseMainWindow();
                _process.Dispose();
            }
        }

        /// <summary>
        /// Stops the IISExpress process that hosts the test site.
        /// </summary>
        public void Stop()
        {
            if (_process == null)
                return;
            _process.WaitForExit(5000);
            if (!_process.HasExited)
                _process.Kill();
        }


    }
}