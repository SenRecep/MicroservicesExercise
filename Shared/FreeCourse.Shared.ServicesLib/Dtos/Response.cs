using System.Collections.Generic;

namespace FreeCourse.Shared.ServicesLib.Dtos
{
    public class Response<T>
    {
        public T Data { get; private set; }
        public int StatusCode { get; private set; }
        public bool IsSuccesful { get; private set; }
        public IEnumerable<string>  Errors { get; private set; }

        public static Response<T> Success(T data, int statusCode) => new Response<T>
        {
            Data = data,
            StatusCode = statusCode,
            IsSuccesful = true
        };

        public static Response<T> Success(int statusCode) => new Response<T>
        {
            Data = default,
            StatusCode = statusCode,
            IsSuccesful = true
        };

        public static Response<T> Fail(int statusCode, params string[] errors) => new Response<T>
        {
            StatusCode=statusCode,
            Errors=errors,
            IsSuccesful=false,
            Data=default
        };
    }
}
