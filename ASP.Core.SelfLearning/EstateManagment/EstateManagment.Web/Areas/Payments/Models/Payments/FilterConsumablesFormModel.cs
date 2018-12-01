﻿using EstateManagment.Services.Common.ValidationAttributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.DataConstants;

namespace EstateManagment.Web.Areas.Payments.Models.Payments
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

        [Display(Name =DisplayShowAll)]
        public bool ShowAll { get; set; } = false;

        public SelectListItem Client { get; set; }
    }
}
