using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalWebAPI.ViewModels
{
    public class UserLoginViewModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
     public class ResponseVM<T>
    {
        public bool Success { get; set; }
        public string Response { get; set; }
        public T Data { get; set; }
        public string ExceptionMessage { get; set; }
        public string ErrorType { get; set; }

        public ResponseVM(bool success, string key)
        {
            Success = success;
            Response = key;
        }
        public ResponseVM(bool success, string key, Exception exception) : this(success, key)
        {
            ExceptionMessage = exception.Message;
            Response = key;
        }

        public ResponseVM(bool success, string key, T data) : this(success, key)
        {
            Data = data;
            Response = key;
        }
    }
}
