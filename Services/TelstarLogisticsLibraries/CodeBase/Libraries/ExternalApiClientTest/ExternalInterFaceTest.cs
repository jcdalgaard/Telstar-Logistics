using System.IO;
using System.Net;
using System;
using Xunit;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace ExternalApiClientTest
{
    public class ExternalInterFaceTest
    {


        public string getURL(String urlPassed)
        {

            string html = string.Empty;
            string url =urlPassed;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            return html;
        }
        [Fact]
        public void GetConnectedCitiesTest()
        {

            string html = getURL(@"https://fa-tl-dk1.azurewebsites.net/api/GetConnectedCities/wadai?weight=20&contentType=other");
            string expectedOutput = "{\"provider\":\"\",\"connectedCities\":[{\"cityName\":\"Slavekysten\",\"price\":28.0,\"duration\":28.0},{\"cityName\":\"Congo\",\"price\":24.0,\"duration\":24.0},{\"cityName\":\"Darfur\",\"price\":32.0,\"duration\":32.0},{\"cityName\":\"Darfur\",\"price\":16.0,\"duration\":16.0}]}";

            Console.WriteLine(html);
            Assert.Equal(expectedOutput, html);

        }






        [Fact]
        public void GetContentTypesTest()
        {
            string url = @"https://fa-tl-dk1.azurewebsites.net/api/GetContentTypes";
            string html = getURL(url);


            Console.WriteLine(html);
            Assert.Contains("Live animals", html);
            Assert.Contains("Cautious parcels", html);
            Assert.Contains("Refrigerated goods", html);
            Assert.Contains("Other", html);


            Assert.Contains("legalCategories", html);
            Assert.Contains("illegalCategories", html);



        }
        [Fact]
        public void GetUserType()
        {

            string url = @"https://fa-tl-dk1.azurewebsites.net/api/bookings/user/10";
            string html = getURL(url);
          
            Assert.NotNull(html);

        }
        [Fact]
        public void GetCitiesTest()
        {

            string url = @"https://fa-tl-dk1.azurewebsites.net/api/GetCities";
            string html = getURL(url);

            Assert.Contains("Congo",html);
            Assert.Contains("Tanger", html);
            Assert.Contains("Timbuktu", html);
            Assert.Contains("Amatave", html);
            Assert.Contains("Luanda", html);
            Assert.Contains("Wadai", html);
            Assert.DoesNotContain("Copenhagen", html);

        }


        [Fact]
        public void GetAllBookingsTest()
        {

         
            string url = @"https://fa-tl-dk1.azurewebsites.net/api/bookings/all";
            string html = getURL(url);

          

            Assert.NotNull(html);

        }


        [Fact]
        public void GetMostExpensiveCityTest()
        {
            string url = @"https://fa-tl-dk1.azurewebsites.net/api/cities/mostExpensive";
            string html = getURL(url);

            int idCount = Regex.Matches(html, "value").Count();

            Assert.Equal(5, idCount);   

        }

        [Fact]
        public void GetMostPopularCityTest()
        {
            string url = @"https://fa-tl-dk1.azurewebsites.net/api/cities/mostPopular";
            string html = getURL(url);
            int idCount = Regex.Matches(html, "value").Count();

            Assert.Equal(5, idCount);

        }



        [Fact]
        public void GetMostPopularRouteTest()
        {

            string url = @"https://fa-tl-dk1.azurewebsites.net/api/route/mostPopular";
            string html = getURL(url);


            int idCount = Regex.Matches(html, "city1").Count();
            int idCount2 = Regex.Matches(html, "city2").Count();

            Assert.Equal(5, idCount);
            Assert.Equal(5, idCount2);

        }



    }
}