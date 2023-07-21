
using SwaggerAPI.Models;

namespace Api.Models
{
    public class BaseResponse<TData>
    {
        public bool Result { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseDataSource { get; set; }
        public bool IsCalled { get; set; }
        public int xTotalCount { get; set; }
        public ErrorResponse Error { get; set; }
        public TData Data { get; set; }
    }
}
