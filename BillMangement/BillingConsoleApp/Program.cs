//using MySql.Data.MySqlClient;
//namespace BillingConsoleApp
//{
//    public class Bill
//    {

//        public int BillId { get; set; }
//        public string CustomerName { get; set; }
//        public DateTime BillDate { get; set; }
//        public decimal TotalAmount { get; set; }
//        public decimal TaxAmount { get; set; }
//        public decimal DiscountAmount { get; set; }
//        public decimal NetAmount { get; set; }
//        public string PaymentMethod { get; set; }
//        public bool IsPaid { get; set; }

//    }
//    public class Program
//    {
//        string connection = "server=localhost;port=3306;user=root;password=password;database=assessmentdb";
//        public async Task<List<Bill>> GetAllBill()
//        {
//            List<Bill> Bills = new List<Bill>();
//            string query = @"select * from bill";
//            MySqlConnection connection = new MySqlConnection();
//            MySqlCommand command = new MySqlCommand(query, connection);
//            try
//            {
//                await connection.OpenAsync();
//                MySqlDataReader reader = command.ExecuteReader();
//                while (reader.Read())
//                {
//                    Bill bill = new Bill();
//                    int Id = reader.GetInt32("id");
//                    string CustomerName = reader.GetString("name");
//                    DateTime Date = reader.GetDateTime("date");
//                    decimal TotalAmount = reader.GetDecimal("totalamount");
//                    decimal TaxAmount = reader.GetDecimal("TaxAmount");
//                    decimal NetAmount = reader.GetDecimal("NetAmount");
//                    string PaymentMethod = reader.GetString("method");
//                    bool Ispad = reader.GetBoolean("IsPad");
//                    Bills.Add(bill);
//                }

//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }
//            finally
//            {
//                connection.Close();
//            }
//            return Bills;
//        }
//        public static void main(string[] args)
//        {
//            Program get = new Program();
//            get.GetAllBill();
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

class Bill
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public DateTime Date { get; set; }
    public string PaymentMethod { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal NetAmount { get; set; }
    public bool IsPaid { get; set; }
}

class Program
{
    static string connectionString = "server=localhost;port=3306;user=root;password=password;database=billMethod";

    static async void Main(string[] args)
    {
        Console.WriteLine("1. Add Bill");
        Console.WriteLine("2. GetAll Bills");
        Console.WriteLine("3. GetBill by ID");
        Console.Write("Choose an option: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case 1:
                await AddBillAsync();
                break;
            case 2:
                await GetAllBillsAsync();
                break;
            case 3:
                Console.Write("Enter Bill ID: ");
                int id = int.Parse(Console.ReadLine());
                await GetBillByIdAsync(id);
                break;
            case 4:
               await UpdateBillAsync();
                break;
            case 5:
                await DeleteBillAsync();
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

    static async Task InsertBillAsync()
    {
        var bill = new Bill
        {
            Console.WriteLine("Enter BillId Details:"),
            BillId = int.Parse(Console.ReadLine()),
            Console.WriteLine("Enter Customer Name"),
            CustomerName= Console.ReadLine(),
            Console.WriteLine("Enter Bill Date"),
            BillDate=DateTime.Parse(Console.ReadLine()),
            Console.WriteLine("Enter Payment Method"),
            PaymentMethod=Console.ReadLine(),
            Console.WriteLine("Enter Total Amount"),
            TotalAmount=decimal.Parse(Console.ReadLine()),
            Console.WriteLine("Enter Tax Amount"),
            TaxAmount=decimal.Parse(Console.ReadLine()),
            Console.WriteLine("Enter Net Amount"),
            NetAmount=decimal.Parse(Console.ReadLine()),

        };

        string query = @"INSERT INTO bill 
                        (BillId, CustomerName, BillDate, PaymentMethod, TotalAmount, TaxAmount, NetAmount )
                        VALUES (@Id, @CustomerName, @Date, @PaymentMethod, @TotalAmount, @TaxAmount, @NetAmount)";

        using (var connection = new MySqlConnection(connectionString)) ;
        using (var command = new MySqlCommand(query, connection)) ;

        command.Parameters.AddWithValue("@Id", bill.Id);
        command.Parameters.AddWithValue("@CustomerName", bill.CustomerName);
        command.Parameters.AddWithValue("@Date", bill.Date);
        command.Parameters.AddWithValue("@PaymentMethod", bill.PaymentMethod);
        command.Parameters.AddWithValue("@TotalAmount", bill.TotalAmount);
        command.Parameters.AddWithValue("@TaxAmount", bill.TaxAmount);
        command.Parameters.AddWithValue("@NetAmount", bill.NetAmount);


        try
        {
            await connection.OpenAsync();
            int result = await command.ExecuteNonQueryAsync();
            if (result > 0)
            {
                Console.WriteLine("Bill inserted successfully.");
            }
            else
            {
                Console.WriteLine("Insert failed.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Insert failed: " + ex.Message);
        }
        finally
        {
            await connection.CloseAsync();
        }
    }

    static async Task GetAllBillsAsync()
    {
        string query = "SELECT * FROM bill";

        using var connection = new MySqlConnection(connectionString);
        using var command = new MySqlCommand(query, connection);

        try
        {
            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();

            Console.WriteLine("\nAll Bills:");
            while (await reader.ReadAsync())
            {
                Console.WriteLine($"{reader["BillId"]} - {reader["CustomerName"]} - {reader["TotalAmount"]}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static async Task GetBillByIdAsync(int id)
    {
        string query = "SELECT * FROM bill WHERE BillId = @Id";

        using var connection = new MySqlConnection(connectionString);
        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", id);

        try
        {
            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                Console.WriteLine($"\nBill Found:\n" +
                                  $"ID: {reader["BillId"]}\n" +
                                  $"Customer: {reader["CustomerName"]}\n" +
                                  $"Amount: {reader["TotalAmount"]}\n" +
                                  $"Date: {reader["BillDate"]}");
            }
            else
            {
                Console.WriteLine("Bill not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
