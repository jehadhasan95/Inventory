﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Utility
{
    internal interface IDbInitializer
    {
        Task CreateSuperAdmin();
        Task SendEmail(string FromEmail, string FromName,string subject, string Message, string toEmail, string toName,
            string smtpUser,string smtpPassword, string smtpHost, int smtpPort, bool smtpSSL);
        Task<string> UploadFile(List<IFormFile> files, IWebHostEnvironment env, string directory);
    }
}
