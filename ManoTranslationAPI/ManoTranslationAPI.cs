using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Utf8Json;

namespace ManoTranslationAPI
{
    public static class ManoTranslationAPI
    {
        [FunctionName("translate")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            RequestBody requestBody;

            try
            {
                requestBody = JsonSerializer.Deserialize<RequestBody>(req.Body);
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }

            if (string.IsNullOrEmpty(requestBody?.Text))
            {
                return new BadRequestResult();
            }

            if (string.IsNullOrEmpty(requestBody?.SourceLanguage))
            {
                return new BadRequestResult();
            }

            if (string.IsNullOrEmpty(requestBody?.TargetLanguage))
            {
                return new BadRequestResult();
            }

            if (requestBody.SourceLanguage == "ja" && requestBody.TargetLanguage == "mano")
            {
                var translatedText = ManoTranslator.Encode(requestBody.Text);
                var resultObject = new Result { Data = translatedText };
                var resultJsonString = JsonSerializer.ToJsonString(resultObject);
                return new OkObjectResult(resultJsonString);
            }

            if (requestBody.SourceLanguage == "mano" && requestBody.TargetLanguage == "ja")
            {
                var translatedText = ManoTranslator.Decode(requestBody.Text);
                var resultObject = new Result { Data = translatedText };
                var resultJsonString = JsonSerializer.ToJsonString(resultObject);
                return new OkObjectResult(resultJsonString);
            }

            return new BadRequestResult();
        }
    }
}
