using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Services.Model.EmailModel;
using Microsoft.AspNetCore.Http;
using SendGrid;

namespace Jadcup.Services.Interface.CommonServiceInterface {
    public interface IImageService {
        Task<String> UploadImage(IFormFile imageFile);
        Task<Response> SendEmail(string SenderAddress, string SenderName, string Subject, string TargetAddress, string TargetName, string HtmlContent, string FileName, IFormFile File);
    }
}