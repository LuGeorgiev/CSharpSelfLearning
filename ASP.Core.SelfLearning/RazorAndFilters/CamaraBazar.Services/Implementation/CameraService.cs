using CamaraBazar.Data;
using CamaraBazar.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace CamaraBazar.Services.Implementation
{

    public class CameraService : ICameraService
    {
        private readonly CameraBazarDbContext db;

        public CameraService(CameraBazarDbContext db)
        {
            this.db = db;
        }

        public void Create(
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
            string userId)
        {
            //Another approach
            //LightMetering lightMetering = lightMeterings.First();
            //foreach (var lightMeterValue in lightMeterings.Skip(1))
            //{
            //    lightMetering |= lightMeterValue;
            //}

            var camera = new Camera
            {
                Make = make,
                Model = model,
                Price = price,
                Quantity = quantity,
                MinShutterSpeed = minShuterSpeed,
                MaxShutterSpeed = maxShutterSpeed,
                MinISO = minIso,
                MaxISO = maxIso,
                IsFullFrame = isFullFramed,
                VideoReslution = videoResolution,
                LightMeterings = (LightMetering)lightMeterings.Cast<int>().DefaultIfEmpty().Sum(),
                Description = description,
                ImageUrl = imgUrl,
                UserId = userId
            };

            this.db.Add(camera);
            this.db.SaveChanges();
        }

        public bool Edit(int id,
            CameraMakeType make,
            string model, 
            decimal price, 
            int quantity, 
            int minShuterSpeed, 
            int maxShutterSpeed, 
            MinISO minIso, 
            int maxIso, 
            bool 
            isFullFramed, 
            string videoResolution, 
            IEnumerable<LightMetering> lightMeterings, 
            string description, 
            string imgUrl, 
            string userId)
        {
            var camera = this.db.Cameras
                .FirstOrDefault(x => x.Id == id && x.UserId == userId);

            if (camera==null)
            {
                return false;
            }

            //ETC.

            
            return true;
        }

        public bool Exists(int id, string userId)
            => this.db.Cameras.Any(c => c.Id == id && c.UserId == userId);
    }
}
