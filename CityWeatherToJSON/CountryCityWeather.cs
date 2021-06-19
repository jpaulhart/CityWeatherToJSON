using System;
using System.Collections.Generic;
using System.IO;

namespace CityWeatherToJSON
{
    /// <summary>
    /// Collection of Countries
    /// </summary>
    public class Countries
    {
        public Countries(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            int lineNo = 0;
            foreach (string line in lines)
            {
                if (lineNo > 0)
                {
                    string[] words = line.Split(',');
                    if (words.Length != 7)
                    {
                        throw new Exception($"Row {lineNo} has an invalid number words: 'line'");
                    }

                    // Build a new country object if necessary
                    Country thisCountry = new Country();
                    if (!countries.ContainsKey(words[1]))
                    {
                        thisCountry.country = words[1];
                        countries.Add(words[1], thisCountry);
                    } else
                    {
                        thisCountry = countries[words[1]];
                    }

                    // Build a new City if necessary
                    City thisCity = new City();
                    if (!thisCountry.cities.ContainsKey(words[0]))
                    {
                        thisCity.city = words[0];
                        thisCountry.cities.Add(words[0], thisCity);
                    }
                    else
                    {
                        thisCity = thisCountry.cities[words[0]];
                    }

                    // Build a new month of weather
                    Weather thisweather = new Weather()
                    {
                        month = int.Parse(words[2]),
                        monthName = words[3],
                        highTemp = int.Parse(words[4]),
                        lowTemp = int.Parse(words[5]),
                        daysOfRain = int.Parse(words[6])
                    };
                    thisCity.weather.Add(thisweather.month, thisweather);

                }
                lineNo++;
            }
        }

        public SortedDictionary<string, Country> countries { get; set; } = new SortedDictionary<string, Country>();

    }

    /// <summary>
    /// Collection of Cities
    /// </summary>
    public class Country
    {
        public Country()
        {
        }

        public string country = "";
        public SortedDictionary<string, City> cities { get; set; } = new SortedDictionary<string, City>();

    }

    /// <summary>
    /// Collection of monthly Weather samples
    /// </summary>
    public class City
    {
        public City()
        {
        }

        public string city = "";
        public SortedDictionary<int, Weather> weather { get; set; } = new SortedDictionary<int, Weather>();

    }

    /// <summary>
    /// Monthly Weather sample
    /// </summary>
    public class Weather
    {
        public Weather()
        {
        }

        public int month { get; set; } = 0;
        public string monthName { get; set; } = "";
        public int highTemp { get; set; } = 0;
        public int lowTemp { get; set; } = 0;
        public int daysOfRain { get; set; } = 0;

    }

}
