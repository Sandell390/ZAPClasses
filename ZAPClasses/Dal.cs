using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ZAPClasses
{
    public class Dal
    {
        private static string connString = @"Server=172.16.21.31;Database=zap-camp; User Id=sa;Password=Muffin123;";

        public string ConnString { get { return connString; } }

        public Dal()
        {
            //Connect();
        }
        
        void Connect()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("select * from dbo.Customer", connection);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Console.Write($"{reader[i].ToString()} ");
                        }
                        Console.WriteLine();
                    }

                }



            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public List<CampSpot> GetCampSpotsOfType(Revervation.CampType type)
        {
            List<CampSpot> allCampSpots = new List<CampSpot>();

            try
            {
                

                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("select campID from dbo.CampsType where TypeID=@type", connection);

                    cmd.Parameters.Add(new SqlParameter("@type", type));

                    SqlDataReader reader = cmd.ExecuteReader();



                    while (reader.Read())
                    {
                        allCampSpots.Add(new CampSpot(reader[0].ToString()));
                    }


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            

            return allCampSpots;
        }

        public List<CampSpot> GetBookedCampSpots(DateTime startDate, DateTime endDate)
        {
            List<CampSpot> campSpots = new List<CampSpot>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    //where StartDate <= @start and EndDate >= @end
                    SqlCommand cmd = new SqlCommand("select campID from [Booked Camps] where StartDate <= @start and EndDate >= @end", connection);

                    cmd.Parameters.Add(new SqlParameter("@start", startDate.ToString("yyyy-MM-dd")));
                    cmd.Parameters.Add(new SqlParameter("@end", endDate.ToString("yyyy-MM-dd")));


                    SqlDataReader reader = cmd.ExecuteReader();



                    

                    while (reader.Read())
                    {
                        campSpots.Add(new CampSpot(reader[0].ToString()));
                    }


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return campSpots;
        }

    }
}
