﻿using EstateManagment.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.Models.DataConstants;

namespace EstateManagment.Services.Models.Rents
{
    public class CreateRentModel
    {
        [Required]
        [Range(typeof(decimal), MinPayment, MaxPayment)]
        [Display(Name = DisplayPrice)]
        public decimal MonthlyPrice { get; set; }

        [Required]
        [Display(Name = DisplayStartDate)]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = DisplayEndDate)]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [MaxLength(RentDescriptionMaxLength)]
        [Display(Name = DisplayDescription)]
        public string Description { get; set; }

        [MaxLength(DescriptionMaxLength)]
        [Display(Name = DisplayParkingDecription)]
        public string ParkingSlotDescription { get; set; }

        [Required]
        public int ClientId { get; set; }

        
        public IEnumerable<int> PropertiesIds { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = DisplayCarSlots)]
        public int CarSlots { get; set; }

        [Required]
        [Range(typeof(decimal), MinPayment, MaxPayment)]
        [Display(Name = DisplaySlotPrice)]
        public decimal CarMonthPrice { get; set; }

        [Display(Name = DisplayParkingSoltArea)]
        public ParkingSlotArea CarsArea { get; set; } 

        [Range(0, int.MaxValue)]
        [Display(Name = DisplayBusSlots)]
        public int BusSlots { get; set; }

        [Required]
        [Range(typeof(decimal), MinPayment, MaxPayment)]
        [Display(Name = DisplaySlotPrice)]
        public decimal BusMonthPrice { get; set; }

        [Display(Name = DisplayParkingSoltArea)]
        public ParkingSlotArea BusesArea { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = DisplayTruckSlots)]
        public int TruckSlots { get; set; }

        [Required]
        [Range(typeof(decimal), MinPayment, MaxPayment)]
        [Display(Name = DisplaySlotPrice)]
        public decimal TruckMonthPrice { get; set; }

        [Display(Name = DisplayParkingSoltArea)]
        public ParkingSlotArea TrucksArea { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = DisplayBigTruckSlots)]
        public int BigTruckSlots { get; set; }

        [Required]
        [Range(typeof(decimal), MinPayment, MaxPayment)]
        [Display(Name = DisplaySlotPrice)]
        public decimal BigTruckMonthPrice { get; set; }

        [Display(Name = DisplayParkingSoltArea)]
        public ParkingSlotArea BigTrucksArea { get; set; } 

        [Range(0, int.MaxValue)]
        [Display(Name = DisplayCarCageSlots)]
        public int CarCageSlots { get; set; }

        [Required]
        [Range(typeof(decimal), MinPayment, MaxPayment)]
        [Display(Name = DisplaySlotPrice)]
        public decimal CarCageMonthPrice { get; set; }

        [Display(Name = DisplayParkingSoltArea)]
        public ParkingSlotArea CarCagesArea { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = DisplayOtherSlots)]
        public int OtherSlots { get; set; }

        [Required]
        [Range(typeof(decimal), MinPayment, MaxPayment)]
        [Display(Name = DisplaySlotPrice)]
        public decimal OtherMonthPrice { get; set; }

        [Display(Name = DisplayParkingSoltArea)]
        public ParkingSlotArea OthersArea { get; set; } 
    }
}
