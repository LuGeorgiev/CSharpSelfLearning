﻿using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace _03BarracksWars.Core.Commands
{
    public class AddCommand : Command
    {
        [Inject]
        private IRepository repository;
        [Inject]
        private IUnitFactory unitFactory;

        public AddCommand(string[] date, IRepository repository, IUnitFactory unitFactory) : base(date)
        {
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        protected IRepository Repository
        {
            get { return this.repository; }
            private set { this.repository = value; }
        }

        protected IUnitFactory UnitFactory
        {
            get { return this.unitFactory; }
            private set { this.unitFactory = value; }
        }


        public override string Execute()
        {
            string unitType = this.Data[1];
            IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);

            string output = unitType + " added!";
            return output;
        }
    }
}
