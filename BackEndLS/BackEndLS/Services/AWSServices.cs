using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using BackEndLS.IRepositories;
using BackEndLS.IServices;
using BackEndLS.Models;
using BackEndLS.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackEndLS.Services
{
    public class AWSServices: IAWSServices
    {
        private readonly IAWSRepositories _awsRepositories;
        public AWSServices(IAWSRepositories awsRepositories)
        {
            _awsRepositories = awsRepositories;
        }

        public async Task<string> ConfigCredentialsAWSAsync(IFormFile file)
        {

            string AccessKeyId = "AKIA2VFU6546RFKVP7UK";
            string SecretAccessKey = "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";
            string BucketName = "imagesusers";


            try
            {

                using (var client = new AmazonS3Client(AccessKeyId, SecretAccessKey, RegionEndpoint.USEast1))
                {
                    if (file != null && file.Length > 0)
                    {
                        var transferUtility = new TransferUtility(client);
                        var key = Guid.NewGuid().ToString(); // Generar un nombre de clave único para la imagen

                        using (var stream = file.OpenReadStream())
                        {
                            await transferUtility.UploadAsync(stream, BucketName, key);
                        }

                        var imageUrl = $"https://{BucketName}.s3.amazonaws.com/{key}";

                        return imageUrl;

                    }
                    else
                    {
                    }
                }
            }
            catch (Exception ex)
            {

            }



            return "";
        }

        public Response<string> SavePhoto(string photo)
        {
            var response = new Response<string>();
            
            _awsRepositories.SavePhoto(photo);
            return response;
        }

    }
}
