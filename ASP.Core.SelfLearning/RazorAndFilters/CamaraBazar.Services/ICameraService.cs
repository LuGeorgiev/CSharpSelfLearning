
namespace CamaraBazar.Services
{
    using Data.Models;
    using System.Collections.Generic;

    public interface ICameraService
    {
        void Create(
            CameraMakeType make,
            string model,
            decimal price,
            int quantity,
            int minShuterSpeed,
            int maxShutterSpeed,
            MinISO minIso,
            int maxIso,
            bool isFullFramed,
            string videoResolution,
            IEnumerable< LightMetering> lightMeterings,
            string description,
            string imgUrl,
            string userId);

        bool Edit(int id,
            CameraMakeType make,
            string model,
            decimal price,
            int quantity,
            int minShuterSpeed,
            int maxShutterSpeed,
            MinISO minIso,
            int maxIso,
            bool isFullFramed,
            string videoResolution,
            IEnumerable<LightMetering> lightMeterings,
            string description,
            string imgUrl,
            string userId);

        bool Exists(int id, string userId);
    }
}
