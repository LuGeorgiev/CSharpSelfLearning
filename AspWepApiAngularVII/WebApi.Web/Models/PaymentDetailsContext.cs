using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Web.Models
{
    public class PaymentDetailsContext : DbContext
    {
        public PaymentDetailsContext( DbContextOptions<PaymentDetailsContext> options) 
            : base(options)
        {
        }

        public DbSet<PaymentDetail> PaymentDetails { get; set; }
    }
}
