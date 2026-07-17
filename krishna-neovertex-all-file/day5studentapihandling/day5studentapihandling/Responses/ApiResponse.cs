using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace day5studentapihandling.Responses
{
    public class ApiResponse<T> 
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Date { get; set; }
        
    }
}
