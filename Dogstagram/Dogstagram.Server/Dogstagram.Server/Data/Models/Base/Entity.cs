using System;
using System.ComponentModel.DataAnnotations;

namespace Dogstagram.Server.Data.Models.Base
{
    public abstract class Entity : IEntity
    {
        public string  CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

    }
}
