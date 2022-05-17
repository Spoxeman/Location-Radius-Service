using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CitiLocations.Models;
using CitiLocations.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CitiLocations.Controllers
{
    public class LocationsController : Controller
    {



        public async Task<IActionResult> searchjobs(string location, int radius)
        {


            //create location results list to store results
            List<PlacesModel> Lr = new List<PlacesModel>();
            List<string> matchingRadius;
            string joined = null;
          
            int totalRecords_initial = 0;


            await Task.Run(() =>
            {


                if (radius > 0 && location != null)
                {

                    matchingRadius = GetRadius(location.TrimEnd(), radius);
                    joined = string.Join("',", matchingRadius);

                    foreach (var i in matchingRadius)
                    {
                        Lr.Add(new PlacesModel
                        {
                            Name = i

                        });
                    }

                }

                SampleData sample = new SampleData();
                var LocationsList = sample.SamplePlaces.Where(a => a.Item2.Contains(location));


                foreach (var i in LocationsList)
                {
                    Lr.Add(new PlacesModel
                    {
                        Name = i.Item2

                    });
                }

                totalRecords_initial = Lr.Count();


                return Ok(Lr);

            });
            return Ok(Lr);
        }





        public List<string> GetRadius(string placename, int radius)
        {
            SampleData sample = new SampleData();
            var RadiusData = sample.SamplePlaces.ToList();
            List<string> distances = new List<string>();


            var searchedlong = Convert.ToDouble((from u in RadiusData
                                                 where u.Item2.ToUpper() == placename.ToUpper()
                                                 select u.Item4).FirstOrDefault());

            var searchedlat = Convert.ToDouble((from u in RadiusData
                                                where u.Item2.ToUpper() == placename.ToUpper()
                                                select u.Item3).FirstOrDefault());



            double destLat;
            double destLong;

            foreach (Tuple<int,string,double,double> i in RadiusData)
            {
                destLat = Convert.ToDouble(i.Item3);
                destLong = Convert.ToDouble(i.Item4);

                var distance = new Coordinates(searchedlat, searchedlong)
               .DistanceTo(
                   new Coordinates(destLat, destLong),
                   Services.UnitOfLength.Miles
                   
               );
                if (distance <= radius)
                {
                    distances.Add(i.Item2);
                }

            }
            //distances.Add(placename);



            return distances;
        }



    }
}
