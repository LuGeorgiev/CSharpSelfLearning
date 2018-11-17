using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace EstateManagment.Web.Common.Extensions
{
    public static class FormFileExtension
    {
        public static async Task<byte[]> ToByteArrayAsync(this IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);

                return memoryStream.ToArray();
            }
        }
    }
}
