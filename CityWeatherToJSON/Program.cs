using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace CityWeatherToJSON
{
    class MainClass
    {
        public string csvFileName = "/Users/paulhart/GitHubWork/CityWeather/CityWeather.csv";
        public string jsonFileName = "/Users/paulhart/GitHubWork/CityWeather/CityWeather.json";
        public Countries countries;

        public static void Main(string[] args)
        {
            Console.WriteLine("Starting CityWeatherToJSON");
            MainClass mainClass = new MainClass();
            mainClass.run(args);
            Console.WriteLine("Ending CityWeatherToJSON");

        }

        private void run(string[] args)
        {
            this.countries = new Countries(this.csvFileName);
            string jsonString = JsonConvert.SerializeObject(this.countries);
            File.WriteAllText(this.jsonFileName, jsonString);
        }
    }
}
