namespace EstateManagment.Data.Models
{
    using System;
    public class Contract
    {
        public int Id { get; set; }

        public DateTime UploadData { get; set; } = DateTime.UtcNow;

        public byte[] ScannedContract { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
