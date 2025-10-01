using MySql.Data.MySqlClient;
using BillMangement.Entities;
using System.Configuration;
using BillMangement.Services;
namespace BillMangement.Repository
{
    public class BillRepository : IBillRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectiostring;
        
        public BillRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectiostring = _configuration.GetConnectionString("DefaultConnection")
                ?? throw new ArgumentNullException("connectionString");
        }
        public async Task<List<Bill>> GetAllBill()
        {
          List<Bill> Bills = new List<Bill>();
            string query = @"select * from bill";
            MySqlConnection connection = new MySqlConnection();
            MySqlCommand command =new MySqlCommand(query, connection);
            try
            {

                //How to fetch data from multiple tables 

                await connection.OpenAsync();
                MySqlDataReader reader = command.ExecuteReader();
                while ( reader.Read())
                {
                    Bill bill = new Bill();
                     int Id = reader.GetInt32("id");
                    string CustomerName= reader.GetString("name");
                     DateTime Date=reader.GetDateTime("date");
                    decimal TotalAmount = reader.GetDecimal("totalamount");
                    decimal TaxAmount = reader.GetDecimal("TaxAmount");
                    decimal NetAmount = reader.GetDecimal("NetAmount");
                    string PaymentMethod=reader.GetString("method");
                    bool Ispad = reader.GetBoolean("IsPad");
                    Bills.Add(bill);
                }
             
            }
            catch(Exception e)
            {
             Console.WriteLine(e.ToString());
            }
            finally
            {
            // connection.Close();
            }
            return Bills;
        }
        public async Task<Bill> GetBillById(int id )
        {
            //string query = @"SELECT * FROM bill WHERE @BillId=id";                           
            //MySqlConnection connection = new MySqlConnection();
            //MySqlCommand command =new MySqlCommand( query, connection);
            //command.Parameters.AddWithValue("@BillId", id);
            //try
            //{
            //    await connection.OpenAsync();
            //    MySqlDataReader reader = command.ExecuteReader();
            //    if(reader.Read())
            //    {
            //        Bill bill = new Bill()
            //        {
            //            BillId = reader.GetInt32("id"),
            //            CustomerName = reader.GetString("name"),
            //            BillDate = reader.GetDateTime("date"),
            //            TotalAmount = reader.GetDecimal("totalamount"),
            //            TaxAmount = reader.GetDecimal("TaxAmount"),
            //            NetAmount = reader.GetDecimal("NetAmount"),
            //            PaymentMethod = reader.GetString("method"),
            //            IsPaid = reader.GetBoolean("IsPad")
            //        }; 
            //        return bill;
            //    }

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //finally
            //{
            //    await connection.CloseAsync();
            //}
            //return new Bill();
            throw new NotImplementedException();
        }
       
    }
}
