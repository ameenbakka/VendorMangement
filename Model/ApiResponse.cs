namespace vendor_Management.Model
{
    public class ApiResponse<T>
    {
            public bool Success { get; set; }
            public string Message { get; set; }
            public T Data { get; set; }
            public string Error { get; set; }
            public ApiResponse(T data, string message = "", bool success = true, string error = null)
            {
                Data = data;
                Message = message;
                Success = success;
                Error = error;
            }
        
    }
}
