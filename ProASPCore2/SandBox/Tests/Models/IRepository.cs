﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tests.Models
{
    public interface IRepository
    {
        IEnumerable<Reservation> Reservations { get; }

        Reservation this[int id] { get; }

        Reservation AddReservation(Reservation reservation);

        Reservation UpdateReservation(Reservation reservation);

        void DeleteReservation(int id);
    }
}
