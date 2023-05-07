using Amazon.S3;
using Amazon.S3.Model;
using BackEndLS.IServices;
using BackEndLS.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEndLS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AWSController : Controller
    {
        private readonly IAWSServices _awsServices;
        private readonly IAmazonS3 _amazonS3;
        public AWSController(IAWSServices awsServices, IAmazonS3 amazonS3)
        {
            _awsServices = awsServices;
            _amazonS3 = amazonS3;
        }


        [HttpPost("savePhoto")]
        public IActionResult SavePhoto(IFormFile file)
        {
            try
            {
                //_awsServices.SavePhoto("");
                _awsServices.ConfigCredentialsAWSAsync(file);
                return Ok();
            }
            catch (Exception ex)
            {
                
                return BadRequest();
            }
        }

        [HttpPost("saveImage")]
        public async Task<IActionResult> Post([FromForm] IFormFile file)
        {
            var putRequest = new PutObjectRequest()
            {
                BucketName= "imagesusers",
                Key = file.FileName,
                InputStream = file.OpenReadStream(),
                ContentType = file.ContentType,
                CannedACL = S3CannedACL.PublicRead

            };

            var result = await _amazonS3.PutObjectAsync(putRequest);

            if (result.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                var imageUrl = $"https://s3.amazonaws.com/imagesusers/{file.FileName}";

                Response<string> response = new Response<string>(true, "Exito", imageUrl);
                return Ok(response);
            }

            Response<string> response2 = new Response<string>(true, "Exito", "");
            return Ok(response2);
        }
    }
}
