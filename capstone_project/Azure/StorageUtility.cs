using System;
using System.IO;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace GVSU.Azure
{
    public class StorageUtility
    {
        private CloudStorageAccount _azureStorageAccount;
        private CloudBlobClient _azureBlobClient;
        private CloudBlobContainer _azureBlobContainer;

        public StorageUtility(string url, string container)
        {
            try
            {
                _azureStorageAccount = CloudStorageAccount.Parse(url);
                _azureBlobClient = _azureStorageAccount.CreateCloudBlobClient();
                _azureBlobContainer = _azureBlobClient.GetContainerReference(container);
                _azureBlobContainer.CreateIfNotExists();
            }
            catch (Exception ex)
            {
            }
        }

        public bool UploadFile(HttpPostedFileBase file, long issueId)
        {
            bool success;

            try
            {
                var blockBlob = _azureBlobContainer.GetBlockBlobReference(issueId + "/" + Path.GetFileNameWithoutExtension(file.FileName) + Path.GetExtension(file.FileName));
                blockBlob.UploadFromStream(file.InputStream);
                success = true;
            }
            catch (Exception ex)
            {
                success = false;
            }

            return success;
        }

        public string UploadFile(byte[] fileBytes, string blobName)
        {
            try
            {
                var blockBlob = _azureBlobContainer.GetBlockBlobReference(blobName);

                blockBlob.UploadFromByteArray(fileBytes, 0, fileBytes.Length);

                return blockBlob.Uri.ToString();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DownloadFile(string fileName, string saveLocation)
        {
            bool success;
            try
            {
                var blockBlob = _azureBlobContainer.GetBlockBlobReference(fileName);
                using (var fileStream = File.OpenWrite(saveLocation))
                {
                    blockBlob.DownloadToStream(fileStream);
                }
                success = true;
            }
            catch (Exception ex)
            {
                success = false;
            }

            return success;
        }

        public bool DeleteFile(string fileName, long issueId)
        {
            bool success;
            try
            {
                var blockBlob = _azureBlobContainer.GetBlockBlobReference(issueId + "/" + fileName);
                blockBlob.Delete();
                success = true;
            }
            catch (Exception ex)
            {
                success = false;
            }

            return success;
        }
    }
}
