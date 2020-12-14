using Skills.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skills.ThirdParty
{
    public class Response
    {
        private bool isSuccess;

        private string message;

        private List<Post>result;

        public bool IsSuccess { get => isSuccess; set => isSuccess = value; }
        public string Message { get => message; set => message = value; }
        public List<Post> Result { get => result; set => result = value; }
    }
}
