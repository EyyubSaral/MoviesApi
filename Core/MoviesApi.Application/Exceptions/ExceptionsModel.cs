using Newtonsoft.Json;


namespace MoviesApi.Application.Exceptions
{
    public class ExceptionsModel : ErrorStatusCode
    {
        public IEnumerable<string> Errors { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ErrorStatusCode
    {
        public int StatusCode { get; set; }
    }
}
