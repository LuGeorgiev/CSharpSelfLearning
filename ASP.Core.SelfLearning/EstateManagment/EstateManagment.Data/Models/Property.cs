namespace EstateManagment.Data.Models
{
    using Enums;
    using System.Collections.Generic;

    public class Property
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string  Address { get; set; }

        public int Area { get; set; }

        public string Description { get; set; }

        public PropertyType Type { get; set; }

        public int CompanyId { get; set; }

        public virtual Company  Company{ get; set; }

        public virtual ICollection<PropertyRent> PropertyRents { get; set; } = new HashSet<PropertyRent>();
    }
}
