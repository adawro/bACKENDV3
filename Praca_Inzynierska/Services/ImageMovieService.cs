using Microsoft.AspNetCore.Http;
using Praca_Inzynierska.Models;
using Praca_Inzynierska.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska.Services
{
    public class ImageMovieService : IImageService
    {
        public void RemoveImage(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);

            try
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);
                else
                    throw new Exception($"Nie znaleziono zdjecia o nazwie {fileName}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoveImage(ImageMovie imageToRemove)
        {
            RemoveImage(imageToRemove.FileName);
        }

        public void RemoveImages(IEnumerable<ImageMovie> imagesToRemove)
        {
            foreach (var image in imagesToRemove) RemoveImage(image);
        }

        public void RemoveImages(IEnumerable<string> imagesToRemove)
        {
            foreach (var image in imagesToRemove) RemoveImage(image);
        }

        public List<ImageMovie> UploadImagesToServer(IEnumerable<IFormFile> images, Movie movie)
        {
            var uploadedImagesModels = new List<ImageMovie>();

            if (images == null)
                return uploadedImagesModels;

            var imagesFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images");

            if (!Directory.Exists(imagesFolderPath))
                throw new Exception("Nie znaleziono folderu wwwroot/images na serwerze.");

            foreach (var image in images)
            {
                var fileExtension = "." + image.FileName.Split(".")[image.FileName.Split(".").Length - 1];
                var fileName = Guid.NewGuid() + fileExtension;
                var filePath = Path.Combine(imagesFolderPath, fileName);

                try
                {
                    using (var bits = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(bits);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Problem przy dodawaniu pliku {fileName}. {ex.Message}");
                }

                var newImage = new ImageMovie { FileName = fileName, Movie = movie };
                uploadedImagesModels.Add(newImage);
            }

            return uploadedImagesModels;
        }
    }
}
