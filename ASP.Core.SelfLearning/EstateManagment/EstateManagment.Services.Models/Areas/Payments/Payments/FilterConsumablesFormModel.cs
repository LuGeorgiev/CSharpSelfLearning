﻿using EstateManagment.Services.Models.Areas.Common.ValidationAttributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.Models.DataConstants;

namespace EstateManagment.Services.Models.Areas.Payments.Payments
{
    public class FilterConsumablesFormModel
    {
        [Required]
        [Display(Name = DisplayStartDate)]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.UtcNow.AddMonths(-1);

        [Required]
        [Display(Name = DisplayEndDate)]
        [DataType(DataType.Date)]
        [AfterDate(nameof(StartDate))]
        public DateTime EndDate { get; set; } = DateTime.UtcNow.AddHours(3);

        [Display(Name = DisplayActiveClients)]
        public IEnumerable<SelectListItem> ActiveClients { get; set; }      

        public bool OnlyCash { get; set; }

        public bool FilterByDeadline { get; set; } = true;

        public SelectListItem Client { get; set; }
    }
}
