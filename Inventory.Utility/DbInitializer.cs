using Inventory.Models;
using Inventory.Utility.HelperClass;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Inventory.Repositories;
using System.Net.Mail;
using System.Net;

namespace Inventory.Utility
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SuperAdmin _superAdmin;
        private readonly ApplicationDbContext _context;
        private readonly IRoleInventory _roleInventory;

        public DbInitializer(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<SuperAdmin> superAdmin, ApplicationDbContext context, IRoleInventory roleInventory)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _superAdmin = superAdmin.Value;
            _context = context;
            _roleInventory = roleInventory;
        }

        public async Task CreateSuperAdmin()
        {
            AppUser user = new AppUser();
            user.Email = "";
            user.EmailConfirmed = true;
            user.UserName = "";
            var response = await _userManager.CreateAsync(user, _superAdmin.Password); 
            if (response.Succeeded)
            {
                UserProfile userProfile = new UserProfile();
                userProfile.FirstName = "Admin";
                userProfile.LastName = "Admin";
                userProfile.Email = user.Email;
                userProfile.AppUserId = user.Id;
                await _context.UserProfiles.AddAsync(userProfile);
                await _context.SaveChangesAsync();
                await _roleInventory.AddRoleAsync(user.Id);
            }
        }

        public async Task SendEmail(string FromEmail, string FromName, string subject, string message, string toEmail, string toName, string smtpUser, string smtpPassword, string smtpHost, int smtpPort, bool smtpSSL)
        {
            var body = message;
            var messageRequest = new MailMessage();
            messageRequest.To.Add(new MailAddress(toEmail, toName));
            messageRequest.From= new MailAddress(FromEmail, FromName);
            messageRequest.Subject=subject;
            messageRequest.Body=body;
            messageRequest.IsBodyHtml = true;
            using(var smtp = new SmtpClient())
            {
                var cradential = new NetworkCredential
                {
                    UserName = smtpUser,
                    Password = smtpPassword
                };
                smtp.Credentials = cradential;
                smtp.Host = smtpHost;
                smtp.Port = smtpPort;
                smtp.EnableSsl = smtpSSL;
                await smtp.SendMailAsync(messageRequest);
            }
        }

        public async Task<string> UploadFile(List<IFormFile> files, IWebHostEnvironment env, string directory)
        {
            var response = string.Empty;
            var upload = Path.Combine(env.WebRootPath, directory);
            var fileExtension = string.Empty;
            var fileName = string.Empty;
            var filePath = string.Empty;
            if (files.Count > 0)
            {
                foreach (var file in files)
                {
                    fileExtension = Path.GetExtension(file.FileName);
                    fileName = Guid.NewGuid().ToString()+fileExtension;
                    filePath = Path.Combine(upload, fileName);
                    using (var ms = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(ms);
                    }
                    response = fileName;
                }
                
            }
            return response;
        }
    }
}
