using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id=1,Name="Scott pizza",Location="Marryland",Cuisine=CuisineType.Italian },
                new Restaurant { Id=1,Name="Chipolate",Location="New Jersey",Cuisine=CuisineType.Mexican },
                new Restaurant { Id=1,Name="The India",Location="New York",Cuisine=CuisineType.Indian },
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName( string name=null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
