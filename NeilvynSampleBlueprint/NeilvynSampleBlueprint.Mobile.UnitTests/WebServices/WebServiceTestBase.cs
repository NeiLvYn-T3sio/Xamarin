using System.Net;
using System.Net.Http;
using Refit;

namespace NeilvynSampleBlueprint.Mobile.UnitTests.WebServices
{
    public class WebServiceTestBase
    {
        protected static ApiException CreateApiException(HttpStatusCode statusCode)
        {
            var refitSettings = new RefitSettings();
            return ApiException.Create(default!, default!, 
                new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = null
                }, refitSettings).Result;
        }
    }


}
