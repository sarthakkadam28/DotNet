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

        public async Task<bool> AddBill(BillModel billModel)

        {
            string query = @"INSERT INTO bill ( CustomerName, TaxAmount, TotalAmount, NetAmount, PaymentMethod, BillDate)
                            VALUES ( @CustomerName, @TaxAmount, @TotalAmount, @NetAmount, @PaymentMethod, @BillDate)";

            MySqlConnection connection = new MySqlConnection(_connectionString);

            MySqlCommand command = new MySqlCommand(query, connection);
            {
                command.Parameters.AddWithValue("@CustomerName", billModel.CustomerName);
                command.Parameters.AddWithValue("@TotalAmount", billModel.TotalAmount);
                command.Parameters.AddWithValue("@BillDate", billModel.BillDate);
                command.Parameters.AddWithValue("@TaxAmount", billModel.TaxAmount);
                command.Parameters.AddWithValue("@PaymentMethod", billModel.PaymentMethod);
                command.Parameters.AddWithValue("@NetAmount", billModel.NetAmount);
            }
            try
            {
                await connection.OpenAsync();
                int result = await command.ExecuteNonQueryAsync();
                if (result > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                await connection.CloseAsync();
            }
            return true;

        }
        public async Task<List<BillDetail>> GetBillDetail()
        {
            List<BillDetail> details = new List<BillDetail>();
            string query = @"select BillId,CustomerName,NetAmount from bill";
            MySqlConnection connection = new MySqlConnection(_connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);
            {
                try
                {
                    await connection.OpenAsync();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        BillDetail billdt = new BillDetail();
                        billdt.BillId = Convert.ToInt32(reader["BillId"]);
                        billdt.CustomerName = reader["CustomerName"].ToString();
                        billdt.NetAmount = Convert.ToInt32(reader["NetAmount"]);
                        details.Add(billdt);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
            return details;
        }
        public async Task<bool> DeleteById(int BillId)
        {
            string query = @"DELETE FROM bill WHERE BillId=@BillId";
            MySqlConnection connection = new MySqlConnection(_connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);
            {
                command.Parameters.AddWithValue("@BillId", BillId);
                try
                {
                    await connection.OpenAsync();
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                finally
                {
                    await connection.CloseAsync();
                }

            }
        }
        public async Task<bool> UpdateBill(int BillId, Bill billModel)
        {
            string query = @"UPDATE bill SET CustomerName=@CustomerName,TotalAmount=@TotalAmount,TaxAmount=@TaxAmount,NetAmount=@NetAmount,PaymentMethod=@PaymentMethod,BillDate=@BillDate WHERE BillId=@BillId";
            MySqlConnection connection = new MySqlConnection(_connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);
            {
                command.Parameters.AddWithValue("@BillId", BillId);
                command.Parameters.AddWithValue("@CustomerName", billModel.CustomerName);
                command.Parameters.AddWithValue("@TotalAmount", billModel.TotalAmount);
                command.Parameters.AddWithValue("@BillDate", billModel.BillDate);
                command.Parameters.AddWithValue("@TaxAmount", billModel.TaxAmount);
                command.Parameters.AddWithValue("@PaymentMethod", billModel.PaymentMethod);
                command.Parameters.AddWithValue("@NetAmount", billModel.NetAmount);
            }
            try
            {
                await connection.OpenAsync();
                int result = command.ExecuteNonQueryAsync().Result;
                if (result > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                connection.CloseAsync();
            }
            return true;
        }
    }
}
