using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace ZAPFrameLibrary
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

        /// <summary>
        /// Gets all CampSpots of a type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get all booked CampSpots from the database
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<CampSpot> GetBookedCampSpots(DateTime startDate, DateTime endDate)
        {
            List<CampSpot> campSpots = new List<CampSpot>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    
                    SqlCommand cmd = new SqlCommand("select campID from [Booked Camps] where (StartDate <= @start and EndDate >= @start) or (StartDate >= @start and EndDate >= @end) or (StartDate >= @start and EndDate <= @end)", connection);

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

        public void InsertCustomer(Customer customer)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("[dbo].[CreateCustomer]", connection);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Email", customer.Eamil));
                    cmd.Parameters.Add(new SqlParameter("@FirstName", customer.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", customer.LastName));
                    cmd.Parameters.Add(new SqlParameter("@Address", customer.Address));
                    cmd.Parameters.Add(new SqlParameter("@PhoneNr", customer.TelefonNr));

                    cmd.ExecuteNonQuery();
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public int InsertRevervation(Revervation revervation)
        {
            int ID = 0;
            try
            {

                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("[dbo].[CreateReservation]", connection);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@CustomerEmail", revervation.Customer.Eamil));
                    cmd.Parameters.Add(new SqlParameter("@Type", revervation.Type));
                    cmd.Parameters.Add(new SqlParameter("@StartDate", revervation.StartDate.ToString("yyyy-MM-dd")));
                    cmd.Parameters.Add(new SqlParameter("@EndDate", revervation.EndDate.ToString("yyyy-MM-dd")));
                    cmd.Parameters.Add(new SqlParameter("@Adult", revervation.Adult));
                    cmd.Parameters.Add(new SqlParameter("@Child", revervation.Child));
                    cmd.Parameters.Add(new SqlParameter("@Dog", revervation.Dog));
                    cmd.Parameters.Add(new SqlParameter("@CampID", revervation.Camp.Id));
                    cmd.Parameters.Add(new SqlParameter("@OrderID", 0));

                    cmd.Parameters["@OrderID"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                     ID = int.Parse(cmd.Parameters["@OrderID"].Value.ToString());

                    Console.WriteLine($"ID: {ID}");

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return ID;
        }

        public void InsertAddition(Revervation revervation)
        {
            for (int i = 0; i < revervation.Additions.Count; i++)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connString))
                    {
                        connection.Open();

                        SqlCommand cmd = new SqlCommand("insert into OrderAddition (AddonID, OrderID, Amount) values (@Addon, @Order, @Amount)", connection);

                        cmd.Parameters.Add(new SqlParameter("@Addon", (int)revervation.Additions[i].Type));
                        cmd.Parameters.Add(new SqlParameter("@Order", revervation.OrderID));
                        cmd.Parameters.Add(new SqlParameter("@Amount", revervation.Additions[i].Amount));

                        cmd.ExecuteNonQuery();
                    }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            
        }

    }
}
