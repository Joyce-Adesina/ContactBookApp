using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ContactBook_Application.Service.Abstraction;
using ContactBook_Domain.ImgaeModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook_Application.Service.Implementation
{
        public class PhotoService : IPhotoService
        {
            public IConfiguration Configuration { get; }
            private CloudinarySettings _cloudinarySettings;
            private Cloudinary _cloudinary;
            public PhotoService(IConfiguration configuration)
            {
                Configuration = configuration;
                _cloudinarySettings = new();
                var jwtSettings = Configuration.GetSection("CloudinarySettings");
                _cloudinarySettings.CloudName = jwtSettings["CloudName"];
                _cloudinarySettings.ApiKey = jwtSettings["ApiKey"];
                _cloudinarySettings.ApiSecret = jwtSettings["ApiSecret"];
                Account account = new Account(_cloudinarySettings.CloudName
                    , _cloudinarySettings.ApiKey, _cloudinarySettings.ApiSecret
                    );
                _cloudinary = new Cloudinary(account);
            }

            public string AddPhotoForUser(string userId, IFormFile file)
            {
                var uploadResult = new ImageUploadResult();
                if (file.Length > 0)
                {
                    using (var stream = file.OpenReadStream())
                    {
                        var uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(file.Name, stream)
                        };
                        uploadResult = _cloudinary.Upload(uploadParams);
                    }
                }
                string url = uploadResult.Url.ToString();
                string publicId = uploadResult.PublicId;//work with this next time

                return url;
            }
        }
    }

