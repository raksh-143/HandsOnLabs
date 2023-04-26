using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using System.Xml.XPath;

namespace EF_Mappings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        private static void ExtractRiversFromXML()
        {
            Geography geography = new Geography();
            var doc = XDocument.Load(@"C:\Users\Adnim\source\repos\Db-Apps-Lab\EF-Mappings\Rivers.xml");
            var allRivers = doc.XPathSelectElements("/rivers/river");
            Rivers2 rivers2 = new Rivers2();
            foreach (var river in allRivers)
            {
                try
                {
                    var name = river.Element("name");
                    var length = river.Element("length");
                    var outflow = river.Element("outflow");
                    if (name == null || length == null || outflow == null)
                    {
                        throw new Exception("Necessary Attributes not present");
                    }
                    else
                    {
                        rivers2.Name = (string)name;
                        rivers2.Length = (int)length;
                        rivers2.Outflow = (string)outflow;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
                var averageDischarge = river.Element("average-discharge");
                var drainageArea = river.Element("drainage-discharge");
                if (averageDischarge != null && drainageArea != null)
                {
                    rivers2.averageDischarge = (int)averageDischarge;
                    rivers2.drainageArea = (int)drainageArea;
                }
                geography.Rivers2.Add(rivers2);
                geography.SaveChanges();
                var countries = river.XPathSelectElements("countries/country");
                foreach (var country in countries)
                {
                    if (country != null)
                    {
                        Countries2 countries2 = new Countries2
                        {
                            Name = (string)country
                        };
                        geography.Countries2.Add(countries2);
                        geography.SaveChanges();
                    }
                }
                Console.WriteLine("Successfully Entered!");
            }
        }

        private static void GetMonasteriesCountryWise()
        {
            Geography obj = new Geography();
            var monasteryByCountry = from c in obj.Countries
                                     orderby c.CountryName
                                     select new { c.CountryName, monasteries = c.Monasteries.OrderBy(m => m.Name).Select(m => m.Name) };
            var root = new XElement("monasteries");
            foreach (var country in monasteryByCountry)
            {
                if (country.monasteries.Count() != 0)
                {
                    var countryElement = new XElement("country");
                    countryElement.Add(new XAttribute("name", country.CountryName));
                    foreach (var monastery in country.monasteries)
                    {
                        var monasteryElement = new XElement("monastery");
                        monasteryElement.Add(new XAttribute("name", monastery));
                        countryElement.Add(monasteryElement);
                    }
                    root.Add(countryElement);
                }
            }
            root.Save("Monasteries Country Wise.xml");
        }

        private static void GetRiversAsJSON()
        {
            Geography obj = new Geography();
            obj.Database.Log = Console.WriteLine;
            var rivers = from r in obj.Rivers
                         orderby r.Length descending
                         select new
                         {
                             r.RiverName,
                             r.Length,
                             Countries = r.Countries.OrderBy(c => c.CountryName).Select(c => c.CountryName)
                         };
            //foreach(var river in rivers)
            //{
            //    Console.WriteLine(river.RiverName);
            //}
            JavaScriptSerializer mySerializer = new JavaScriptSerializer();
            var riversInJSON = mySerializer.Serialize(rivers.ToList());
            File.WriteAllText("Rivers.json", riversInJSON);
        }
        private static void GetAllContinents()
        {
            Geography obj = new Geography();
            var continents = obj.Continents;
            foreach (var continent in continents)
            {
                Console.WriteLine(continent.ContinentName);
            }
        }
    }
}
