namespace EstateManagment.Data.Models
{

    using System.Collections.Generic;

    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Address { get; set; }

        public string Bulstat { get; set; }
        
        public string AccountableName { get; set; }

        public string ContactName { get; set; }

        public string Telephone { get; set; }

        public string Notes { get; set; }

        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<ClientRent> ClientRents { get; set; } = new HashSet<ClientRent>();


    }
}
