using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook_Application.Service.Abstraction
{
    public interface IPhotoService
    {
        public interface IPhotoService
        {
            string AddPhotoForUser(string userId, IFormFile file);
        }
    }
}
