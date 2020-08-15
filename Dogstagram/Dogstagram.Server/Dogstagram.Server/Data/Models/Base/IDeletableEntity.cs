using System;

namespace Dogstagram.Server.Data.Models.Base
{
    public interface IDeletableEntity : IEntity
    {
        public DateTime? DeletedOn { get; set; }

        public string DeletedBy { get; set; }

        public bool IsDeleted { get; set; } 
    }
}
