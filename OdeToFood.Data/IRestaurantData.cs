using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetByID(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        int Commit();
        Restaurant Add(Restaurant newRestaurant);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id=1,Name="Scott pizza",Location="Marryland",Cuisine=CuisineType.Italian },
                new Restaurant { Id=2,Name="Chipolate",Location="New Jersey",Cuisine=CuisineType.Mexican },
                new Restaurant { Id=3,Name="The India",Location="New York",Cuisine=CuisineType.Indian },
            };
        }

        public Restaurant GetByID(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName( string name=null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant= restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant !=null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location= updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;

            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }


    }
}
