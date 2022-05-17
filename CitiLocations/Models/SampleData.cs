using System;
using System.Collections.Generic;

namespace CitiLocations.Models
{
    public class SampleData
    {

        public List<Tuple<int, string, double, double>> SamplePlaces = new List<Tuple<int, string, double, double>>
           {
              Tuple.Create(1, "Sheffield", 53.383331, -1.466667),
              Tuple.Create(2, "Manchester", 52.489471, -1.898575),
              Tuple.Create(3, "Leicester", 52.633331, -1.133333),
              Tuple.Create(4, "Coventry", 52.408054, -1.510556),
              Tuple.Create(5, "London", 51.509865, -0.118092),
              Tuple.Create(6, "Liverpool", 53.400002, -2.983333),
              Tuple.Create(7, "Birmingham", 52.489471, -1.898575),
              Tuple.Create(1, "Bristol", 50.720806, -1.904755),
              Tuple.Create(2, "Wolverhampton", 52.591370, -2.110748),
              Tuple.Create(3, "Preston", 53.765762, -2.692337),
              Tuple.Create(4, "Bournemouth", 50.720806, -1.904755),
              Tuple.Create(5, "Doncaster", 53.522820, -1.128462),
              Tuple.Create(6, "Bedford", 52.136436, -0.460739),
              Tuple.Create(7, "Basildon", 51.572376, -0.470009)

           };

        
    }
}
