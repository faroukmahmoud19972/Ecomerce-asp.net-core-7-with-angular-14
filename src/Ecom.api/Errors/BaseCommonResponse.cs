using Microsoft.AspNetCore.Http.HttpResults;

namespace Ecom.api.Errors
{
    public class BaseCommonResponse
    {
        public BaseCommonResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? DefulatMessgaeForStatusCode(statusCode);
        }

        private string DefulatMessgaeForStatusCode(int statusCode)
        => statusCode switch
        {
            400 => "BadRequest",
            401 => "NotAuthraized",
            404 => "Resource NotFound",
            500 => "server Error",
            _ => null

        };

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
