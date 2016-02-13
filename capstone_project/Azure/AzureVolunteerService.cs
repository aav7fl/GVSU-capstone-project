using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GVSU.Contracts;
using GVSU.Contracts.Decorators;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;

namespace GVSU.Azure
{
    public class AzureVolunteerService : VolunteerServiceDecorator
    {
        private CloudBlobContainer _store;

        public AzureVolunteerService(IVolunteerService service)
            : base(service)
        {
            _store = CloudStorageAccount.Parse("")
                .CreateCloudBlobClient()
                .GetContainerReference("volunteers");
        }

        public override string CreateVolunteer(IVolunteer volunteer)
        {
            _store.CreateIfNotExists();
            var blob = _store.GetBlockBlobReference($"{volunteer.Id}.txt");
            var json = JsonConvert.SerializeObject(volunteer);
            blob.UploadText(json);
            return "1";
        }

        public override IVolunteer GetVolunteerById(int id)
        {
            var blob = _store.GetBlockBlobReference($"{id}.txt");
            var json = blob.DownloadText();
            return JsonConvert.DeserializeObject<IVolunteer>(json);
        }
    }
}
