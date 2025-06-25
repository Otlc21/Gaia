
using CsvHelper;
using MySql.Data.MySqlClient;
using System.Formats.Asn1;
using System.Globalization;

namespace FazTudo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                await ImportarBaseAeroportosAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadLine();
        }

        private static async Task ImportarBaseAeroportosAsync()
        {
            string connectionString = "Server=localhost;Port=3306;Database=gaia;Uid=gaia;Pwd=123456;CharSet=utf8mb4;";
            string fileUrl = "https://raw.githubusercontent.com/jpatokal/openflights/master/data/airports.dat";
            string tempFile = "airports.dat";

            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine("Baixando arquivo...");
                var data = await client.GetByteArrayAsync(fileUrl);
                File.WriteAllBytes(tempFile, data);
            }

            List<Airport> airports = new List<Airport>();
            List<AirportName> airportNames = new List<AirportName>();

            using (var reader = new StreamReader(tempFile))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                //csv.Configuration.HasHeaderRecord = false;
                //csv.Configuration.BadDataFound = null;

                while (csv.Read())
                {
                    string iata = csv.GetField(4)?.Trim();
                    if (string.IsNullOrEmpty(iata) || iata == "\\N")
                        continue; // Ignorar aeroportos sem código IATA

                    var airport = new Airport
                    {
                        IATA = iata,
                        ICAO = csv.GetField(5)?.Trim(),
                        Latitude = double.TryParse(csv.GetField(6), NumberStyles.Any, CultureInfo.InvariantCulture, out double lat) ? lat : 0,
                        Longitude = double.TryParse(csv.GetField(7), NumberStyles.Any, CultureInfo.InvariantCulture, out double lon) ? lon : 0,
                        TimezoneOffset = float.TryParse(csv.GetField(9), NumberStyles.Any, CultureInfo.InvariantCulture, out float tz) ? tz : 0,
                        TZ_DB = csv.GetField(11)?.Trim()
                    };
                    airports.Add(airport);

                    var name = new AirportName
                    {
                        Culture = "en-US",
                        Name = csv.GetField(1)?.Trim(),
                        City = csv.GetField(2)?.Trim(),
                        Country = csv.GetField(3)?.Trim()
                    };
                    airportNames.Add(name);
                }
            }

            Console.WriteLine($"Total de aeroportos válidos: {airports.Count}");

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                for (int i = 0; i < airports.Count; i++)
                {
                    try
                    {
                        var airport = airports[i];

                        string insertAirport = @"INSERT INTO Airport (IATA, ICAO, Latitude, Longitude, TimezoneOffset, TZ_DB) 
                                         VALUES (@IATA, @ICAO, @Lat, @Lon, @Tz, @TzDb);
                                         SELECT LAST_INSERT_ID();";

                        using (MySqlCommand cmd = new MySqlCommand(insertAirport, conn))
                        {
                            cmd.Parameters.AddWithValue("@IATA", airport.IATA);
                            cmd.Parameters.AddWithValue("@ICAO", airport.ICAO);
                            cmd.Parameters.AddWithValue("@Lat", airport.Latitude);
                            cmd.Parameters.AddWithValue("@Lon", airport.Longitude);
                            cmd.Parameters.AddWithValue("@Tz", airport.TimezoneOffset);
                            cmd.Parameters.AddWithValue("@TzDb", airport.TZ_DB);

                            airport.Id = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        var name = airportNames[i];

                        string insertName = @"INSERT INTO AirportName (AirportId, Culture, Name, City, Country) 
                                      VALUES (@AirportId, @Culture, @Name, @City, @Country);";

                        using (MySqlCommand cmd = new MySqlCommand(insertName, conn))
                        {
                            cmd.Parameters.AddWithValue("@AirportId", airport.Id);
                            cmd.Parameters.AddWithValue("@Culture", name.Culture);
                            cmd.Parameters.AddWithValue("@Name", name.Name);
                            cmd.Parameters.AddWithValue("@City", name.City);
                            cmd.Parameters.AddWithValue("@Country", name.Country);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                }

                Console.WriteLine("Importação concluída com sucesso!");
            }
        }

        class Airport
        {
            public int Id { get; set; }
            public string IATA { get; set; }
            public string ICAO { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public float TimezoneOffset { get; set; }
            public string TZ_DB { get; set; }
        }

        class AirportName
        {
            public string Culture { get; set; }
            public string Name { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
        }
    }
}
