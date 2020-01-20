using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Praca_Inzynierska.Models;

namespace Praca_Inzynierska.Services.Interfaces
{
    public interface IImageActorService
    {
        void RemoveImages(IEnumerable<ImageActor> imagesToRemove);
        void RemoveImage(string fileName);
        void RemoveImage(ImageActor imageToRemove);
        void RemoveImages(IEnumerable<string> imagesToRemove);
        List<ImageActor> UploadImagesToServer(IEnumerable<IFormFile> images, Actor actor);
    }
}
