using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using EstateManagment.Data;

namespace EstateManagment.Services.Implementation
{
    public class RentService : BaseService, IRentService
    {
        public RentService(IMapper mapper, EstateManagmentContext db) 
            : base(mapper, db)
        {
        }
    }
}
