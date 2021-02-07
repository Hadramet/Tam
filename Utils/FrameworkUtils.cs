using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NAudio.Wave;
using Tam.webapp.Models;

namespace Tam.webapp.Utils
{
    public static class FrameworkUtils
    {
        public static async Task<bool> UploadFile(IFormFile Local, Track song)
        {
            //Validating not null Local file
            if (Local != null && Local.Length > 0)
            {
                var fileName = Path.GetFileName(Local.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    @"wwwroot\media",
                    fileName);
                var relativePath = Path.Combine(@"/media/",
                    fileName);
                song.LocalSource = relativePath;
                var artist = fileName.Split('-');
                song.AddedDate = DateTime.Now;
                song.Artist = artist[0];
                song.Title = artist.Length > 0
                    ? "VA"
                    : artist[1];
                await using (var fileStream = new FileStream(filePath,
                    FileMode.Create))
                {
                    await Local.CopyToAsync(fileStream);
                }

                var reader = new Mp3FileReader(filePath);
                var duration = reader.TotalTime.ToString();
                song.Duration = TimeSpan.Parse("00:" + duration.Split(':')[0] + ":" + duration.Split(':')[1]);

                return true;
            }
            return false;
        }
    }
}
