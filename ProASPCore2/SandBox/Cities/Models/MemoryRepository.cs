using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cities.Models
{
    public interface IRepository
    { 
        IEnumerable<City> Cities { get; }

        void AddCity(City city);
    }

    public class MemoryRepository : IRepository
    {
        private List<City> cities = new List<City>
        {
            new City { Name="Sofia", Country="Bulgaria", Population = 20000000 },
            new City { Name=" New yourk", Country="USA", Population = 2000000 },
            new City { Name="London", Country="UK", Population = 26000000 },
            new City { Name="Paris", Country="France", Population = 1000000 }
        };

        public IEnumerable<City> Cities 
            => this.cities;

        public void AddCity(City city)
            => this.cities.Add(city);
    }
}
