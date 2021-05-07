using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.DTOs
{
    public class ApiResponseDto<T>
    {

        public int Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }


        public static ApiResponseDto<T> SuccessResponse(T data, string message = null, int status = 200)
        {
            return new ApiResponseDto<T> { Data = data, Message = message, Status = status };
        }
        public static ApiResponseDto<T> FailedResponseData(T data, string message = null, int status = 300)
        {
            return new ApiResponseDto<T> { Data = data, Message = message, Status = status };
        }
        public static ApiResponseDto<T> SuccessEmpty(string message = null, int status = 200)
        {
            return new ApiResponseDto<T> { Message = message, Status = status };
        }
        public static ApiResponseDto<T> FailedResponse(string message, int status = 400)
        {
            return new ApiResponseDto<T> { Message = message, Status = status };
        }

        public bool IsSucces { get { return Status == 200; } }
        public bool IsNotSucces { get { return Status == 300; } }

    }
}
