using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook_Domain.Dtos.Response
{
    public class StandardReponse<T>
    {
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public int StatusCode { get; set; }
        public DateTime? ExpiryDate { get; set; } = DateTime.Now;

        public StandardReponse(int statuscode, bool success, string msg, T date)
        {
            Data = date;
            Succeeded = success;
            StatusCode = statuscode;
            Status = msg;
           
        }
        public StandardReponse()
        {
        }

        /// <summary>
        /// Application custom response message, 66 response means failed
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public static StandardReponse<T> Success(string successMessage, int statusCode = 66)
        {
            return new StandardReponse<T> { Succeeded = true, Message = successMessage, StatusCode = statusCode };
        }

        /// <summary>
        /// Application custom response message, 88 means successful
        /// </summary>
        /// <param name="successMessage"></param>
        /// <param name="data"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public static StandardReponse<T> Success(string successMessage, T data, int statusCode = 88)
        {
            return new StandardReponse<T> { Succeeded = true, Message = successMessage, Data = data, StatusCode = statusCode };
        }

        /// <summary>
        /// Application custom response message, 66 means third party error
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public static StandardReponse<T> UnExpectedError(string message, T data, int statusCode = 66)
        {
            return new StandardReponse<T> { Succeeded = false, Message = message, Data = data, StatusCode = statusCode };
        }

        public override string ToString() => JsonConvert.SerializeObject(this);




    }
}
