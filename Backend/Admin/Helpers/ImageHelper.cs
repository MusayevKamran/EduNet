using AppEntity;
using AppEntity.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;

namespace AppAdmin.Helpers
{
    public class ImageHelper
    {
        EntityContext _context;

        public ImageHelper(EntityContext context)
        {
            this._context = context;
        }

        public void UpdateImage<T>(int Id, IFormFile files, string path, T model)
        {
            var filePath = Path.GetTempFileName();
            var staticPath = Path.Combine("wwwroot", "images", path);
            var staticPathDB = Path.Combine("images", path);
            var fullPath = Path.Combine(staticPathDB, GetUniqueFileName(files.FileName));
            var fullPathCreate = Path.Combine("wwwroot", fullPath);
            var fullPathDB = fullPath.Replace('\\', '/');
            if (model.GetType() == typeof(Article))
            {
                var article = _context.Articles.FirstOrDefault(item => item.Id == Id);
                article.Image = fullPathDB;
                _context.Update(article);
            }
            _context.SaveChanges();

            FileStream fileStream = new FileStream(fullPathCreate, FileMode.Create);
            files.CopyTo(fileStream);
            fileStream.Dispose();
        }

        public void UpdateImage<T>(Guid Id, IFormFile files, string path, T model)
        {
            var filePath = Path.GetTempFileName();
            var staticPath = Path.Combine("wwwroot", "images", path);
            var staticPathDB = Path.Combine("images", path);
            var fullPath = Path.Combine(staticPathDB, GetUniqueFileName(files.FileName));
            var fullPathCreate = Path.Combine("wwwroot", fullPath);
            var fullPathDB = fullPath.Replace('\\', '/');
            if (model.GetType() == typeof(AppUser))
            {
                var BrainStormUser = _context.AppUsers.FirstOrDefault(item => item.Id == Id);
                BrainStormUser.Image = fullPathDB;
                _context.Update(BrainStormUser);
            }

            _context.SaveChanges();

            FileStream fileStream = new FileStream(fullPathCreate, FileMode.Create);
            files.CopyTo(fileStream);
            fileStream.Dispose();
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 10)
                      + Path.GetExtension(fileName);
        }
    }
}
