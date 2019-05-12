using App.DomainModels.SSOT;
using HeyRed.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace App.Admin.Helpers
{
    public static class FileHelper
    {

        public static string SaveFile(IFormFile file, FileConfig config, DomainModels.SSOT.FileType type,string relativePath)
        {
            if (file.Length <= 0)
            {
                throw new Exception("there is no content in uploaded file.");
            }

            var date = DateTime.Now;
            //var relativePath = $"{type}/{date.Year}/{date.Month}/{date.Day}";
            var folderPath = Path.Combine(relativePath, "UploadFiles");

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var filepath = Path.Combine(folderPath, fileName);

            using (var fileStream = new FileStream(filepath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            //Check Mime Type
            var allowedExtensions = new List<string>
            {
                "image/png",
                "image/tiff",
                "image/jpeg",
                "image/bmp",
                "image/gif",
            };

            if (type == DomainModels.SSOT.FileType.file)
            {
                allowedExtensions.Add("application/msword");
                allowedExtensions.Add("application/zip");
                allowedExtensions.Add("application/x-rar-compressed");
                allowedExtensions.Add("application/pdf");
                allowedExtensions.Add("application/vnd.openxmlformats-officedocument.wordprocessingml.document");
            }

            var mimeType = MimeGuesser.GuessMimeType(filepath);

            if (allowedExtensions.Contains(mimeType))
                return fileName;


            try
            {
                File.Delete(filepath);
            }
            catch (IOException)
            {

            }

            throw new Exception("فایل مورد نظر غیر مجاز می‌باشد");
        }

        public static void DeleteFile(string Image, FileConfig config, DomainModels.SSOT.FileType fileType, string relativePath)
        {
            var folderPath = Path.Combine(relativePath, "UploadFiles");

            File.Delete(folderPath + Image);
        }
    }
}
