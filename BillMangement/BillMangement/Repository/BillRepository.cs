using MySql.Data.MySqlClient;
using BillMangement.Entities;
using System.Configuration;
using BillMangement.Services;
namespace BillMangement.Repository
{
    public class BillRepository : IBillRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public BillRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection")
                                ?? throw new InvalidOperationException("Missing connection string 'DefaultConnection'");

            Console.WriteLine($"_connectiostring:: {_connectionString}");
        }

        public async Task<List<Bill>> GetAllBill()
        {
            List<Bill> Bills = new List<Bill>();
            string query = @"select * from bill";
            MySqlConnection connection = new MySqlConnection(_connectionString);

            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {

                //How to fetch data from multiple tables 

                await connection.OpenAsync();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    
                    Bill bill = new Bill();
                    bill.BillId = Convert.ToInt32(reader["BillId"]);
                    bill.CustomerName = reader["CustomerName"].ToString();
                    bill.BillDate = Convert.ToDateTime(reader["BillDate"]);
                    bill.TotalAmount = Convert.ToDecimal(reader["TotalAmount"]);
                    bill.TaxAmount = Convert.ToDecimal(reader["TaxAmount"]);
                    bill.NetAmount = Convert.ToDecimal(reader["NetAmount"]);
                    bill.PaymentMethod = reader["PaymentMethod"].ToString();
                    Bills.Add(bill);
                }

            }
            catch (Exception e)

            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                connection.Close();
            }
            return Bills;
        }

        public async Task<Bill> AddBill(Bill bill)

        {
            string query = @"INSERT INTO bill (BillId, CustomerName, TaxAmount, TotalAmount, NetAmount, PaymentMethod)
                            VALUES (@BillId, @CustomerName, @TaxAmount, @TotalAmount, @NetAmount, @PaymentMethod)";

            MySqlConnection connection = new MySqlConnection(_connectionString);

            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@BillId", bill.BillId);
            command.Parameters.AddWithValue("@CustomerName", bill.CustomerName);
            command.Parameters.AddWithValue("@TotalAmount", bill.TotalAmount);
            command.Parameters.AddWithValue("@TaxAmount", bill.TaxAmount);
            command.Parameters.AddWithValue("@PaymentMethod", bill.PaymentMethod);
            command.Parameters.AddWithValue("@NetAmount", bill.NetAmount);

            try
            {
                await connection.OpenAsync();
                int result = await command.ExecuteNonQueryAsync();
                if (result <= 0)
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                await connection.CloseAsync();
            }
            return bill;

        }
    }
}
