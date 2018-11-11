using AutoMapper;
using EstateManagment.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstateManagment.Services.Implementation
{
     public abstract class BaseService
    {
        private readonly EstateManagmentContext _db;
        private readonly IMapper _mapper;

        protected BaseService(IMapper mapper, EstateManagmentContext db)
        {
            this._mapper = mapper;
            this._db = db;
        }

        public EstateManagmentContext Db => this._db;

        public IMapper Mapper => this._mapper;
    }
}
