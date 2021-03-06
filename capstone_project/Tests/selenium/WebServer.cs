﻿using System.Diagnostics;
using System.Threading;

namespace GVSU.Tests.selenium
{
    public static class WebServer
    {
        private static Process _iisProcess;

        public static void StartIis()
        {
            if (_iisProcess == null)
            {
                var thread = new Thread(StartIisExpress) { IsBackground = true };

                thread.Start();
            }
        }

        private static void StartIisExpress()
        {
            var startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Normal,
                ErrorDialog = true,
                LoadUserProfile = true,
                CreateNoWindow = false,
                UseShellExecute = false,
                Arguments = string.Format("/config:{0} /site:{1}", @"../../../.vs/config/applicationhost.config", "Web")
            };
            var programfiles = string.IsNullOrEmpty(startInfo.EnvironmentVariables["programfiles"])
                                ? startInfo.EnvironmentVariables["programfiles(x86)"]
                                : startInfo.EnvironmentVariables["programfiles"];

            startInfo.FileName = programfiles + "\\IIS Express\\iisexpress.exe";

            try
            {
                _iisProcess = new Process { StartInfo = startInfo };

                _iisProcess.Start();
                _iisProcess.WaitForExit();
            }
            catch
            {
                _iisProcess.CloseMainWindow();
                _iisProcess.Dispose();
            }
        }

        public static void StopIis()
        {
            try
            {
                if (_iisProcess != null)
                {
                    _iisProcess.CloseMainWindow();
                    _iisProcess.Dispose();
                }
            }
            catch
            {
                //IIS express was probably already started from an earlier run and cannot be closed from here
            }

        }
    }
}