using Microsoft.AspNetCore.Http;
using Praca_Inzynierska.Models;
using System.Collections.Generic;

namespace Praca_Inzynierska.Services.Interfaces
{
    public interface IImageMovieService
    {
        void RemoveImages(IEnumerable<ImageMovie> imagesToRemove);
        void RemoveImage(string fileName);
        void RemoveImage(ImageMovie imageToRemove);
        void RemoveImages(IEnumerable<string> imagesToRemove);
        List<ImageMovie> UploadImagesToServer(IEnumerable<IFormFile> images, Movie movie);
    }
}

