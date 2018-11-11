using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.DataConstants;

namespace EstateManagment.Services.ServiceModels.Companies
{
    public class CompanyModel
    {   
        public int Id { get; set; }


        [Display(Name = DisplayCompanyName)]
        public string Name { get; set; }


        [Display(Name = DisplayAddress)]
        public string Address { get; set; }


        [Display(Name = DisplayBulstat)]
        public string Bulstat { get; set; }
    }
}
