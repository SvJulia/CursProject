using CursProject.Classes;
using CursProject.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace CursProject.Helpers
{
    class HtmlParser
    {
        private static readonly TourDbDataContext db = DataBase.Context;

        public static bool GetTrips(ComboBoxItem item)
        {
            var url =
                string.Format(
                              "http://exat.ru/touronline/result-v2.php?&departureId=64&lcc={0}&currencyId=3&maxGenDays=22&limit=20&client_id=3v960f5fd1efdf9fb80ea01fa2fff9bc1fa5b3dca1683c02aae293f64a656a3a133020a5ff7d0f6cdb&transportRequired=1&countryFilter=&placeGroupId[]={0}&placeItemId[]={0}&tourTypeId[]=1,2,4,8,32,64,256,512,1024,2048,4096&maxAmount=0&accommodation=1_0&lastDepartureId=1&holder=aHR0cCUzQS8vZXhhdC5ydS8=",
                    item.Value);

            var html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(GetHtml(url));

            var table = html.DocumentNode.Descendants("table").FirstOrDefault(t => t.Attributes.Contains("class") && t.Attributes["class"].Value.Contains("data"));

            if (table == null)
            {
                return false;
            }

            foreach (var tr in table.ChildNodes[3].Descendants("tr"))
            {
                var countryName = item.Text;
                var cityName = tr.ChildNodes[1].ChildNodes[1].InnerText.Trim();
                var hotelName = tr.ChildNodes[3].ChildNodes[0].InnerText.Trim();
                if (hotelName.Length == 0) 
                {
                    continue;
                }
                
                hotelName = hotelName.Split(new [] {"&nbsp;"}, StringSplitOptions.RemoveEmptyEntries)[0];
                var mealType = tr.ChildNodes[7].InnerText.Trim();
                var date = tr.ChildNodes[9].InnerText.Trim();
                var nightName = tr.ChildNodes[11].InnerText.Trim();
                var priceName = tr.ChildNodes[15].ChildNodes[1].InnerText.Trim();


                var country = db.Countries.FirstOrDefault(p => p.Name == countryName);
                if (country == null)
                {
                    country = new Country { Name = countryName };
                    db.Countries.InsertOnSubmit(country);
                    db.SubmitChanges();
                }

                var city = db.Cities.FirstOrDefault(p => p.Name == cityName);
                if (city == null)
                {
                    city = new City { Name = cityName, Country = country };
                    db.Cities.InsertOnSubmit(city);
                    db.SubmitChanges();
                }

                var transport = db.Transports.FirstOrDefault(t => t.Name == "Самолёт");
                if (transport == null)
                {
                    transport = new Transport { Name = "Самолёт", Type = Types.TransportType.Air.ToString() };
                    db.Transports.InsertOnSubmit(transport);
                    db.SubmitChanges();
                }

                var meal = db.Meals.FirstOrDefault(t => t.Type == mealType);
                if (meal == null)
                {
                    var mt = MealType.No;
                    switch (mealType)
                    {
                        case "BB":
                            mt = MealType.BB;
                            break;
                        case "FB":
                            mt = MealType.FB;
                            break;
                        case "HB":
                            mt = MealType.HB;
                            break;
                    }

                    meal = new Meal { Name = mealType, Type = mt.ToString() };
                    db.Meals.InsertOnSubmit(meal);
                    db.SubmitChanges();
                }

                var hotel = db.Hotels.FirstOrDefault(h => h.Name == hotelName);
                if (hotel == null)
                {
                    hotel = new Hotel { Name = hotelName, Type = HotelType.Stars4.ToString() };
                    db.Hotels.InsertOnSubmit(hotel);
                    db.SubmitChanges();
                }

                var tour = db.Tours.FirstOrDefault(t => t.Name == hotelName && t.NameForClients == hotelName && t.City == city);
                if (tour == null)
                {
                    tour = new Tour { City = city, Name = hotelName, NameForClients = hotelName };
                    db.Tours.InsertOnSubmit(tour);
                    db.SubmitChanges();
                }

                int month = 0;
                int.TryParse(date.Split(".".ToCharArray(), StringSplitOptions.None)[1], out month);

                int day = 0;
                int.TryParse(date.Split(".".ToCharArray(), StringSplitOptions.None)[0], out day);

                int nigths = 0;
                int.TryParse(nightName.Split("/".ToCharArray(), StringSplitOptions.None)[1], out nigths);

                int tourPrice = 0;
                int.TryParse(priceName.Substring(0, priceName.Length - 2), out tourPrice);

                var dateDeparture = new DateTime(DateTime.Now.Year, month, day);

                var trip = new Trip
                {
                    Tour = tour,
                    DateDeparture = dateDeparture,
                    DateArival = dateDeparture.AddDays(nigths),
                    Transport = transport,
                    Meal = meal,
                    Hotel = hotel,
                    Amount = 1,
                    MealPrice = 0,
                    HotelPrice = 0,
                    TransportPrice = 0,
                    TourPrice = tourPrice,
                    Nights = nigths
                };

                db.Trips.InsertOnSubmit(trip);
                db.SubmitChanges();
            }

            return true;
        }

        private static string GetHtml(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var receiveStream = response.GetResponseStream();
                StreamReader readStream = response.CharacterSet == null ? 
                    new StreamReader(receiveStream) : 
                    new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                string data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();

                return data;
            }

            return "";
        }
    }
}
