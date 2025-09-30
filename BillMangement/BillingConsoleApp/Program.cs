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

    static async Task Main(string[] args)
    {
        Console.WriteLine("1. Add Bill");
        Console.WriteLine("2. GetAll Bills");
        Console.WriteLine("3. GetBill by ID");
        Console.WriteLine("4. Update Bill");
        Console.WriteLine("5. Delete Bill");
        Console.Write("Choose an option: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                await AddBillAsync();
                break;
            case "2":
                await GetAllBillsAsync();
                break;
            case "3":
                Console.Write("Enter Bill ID: ");
                int id = int.Parse(Console.ReadLine());
                await GetBillByIdAsync(id);
                break;
            case "4":
                Console.Write("Enter Bill ID to update: ");
                int updateId = int.Parse(Console.ReadLine());
                await UpdateBillAsync(updateId);
                break;
            case "5":
                Console.Write("Enter Bill ID to delete: ");
                int deleteId = int.Parse(Console.ReadLine());
                await DeleteBillAsync(deleteId);
                break;

            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }



    static async Task AddBillAsync()
    {
    
       Console.WriteLine("Enter BillId Details:");
        int billId = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Customer Name:");
        string customerName = Console.ReadLine();

        Console.WriteLine("Enter Bill Date (yyyy-MM-dd):");
        DateTime billDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter Payment Method:");
        string paymentMethod = Console.ReadLine();

        Console.WriteLine("Enter Total Amount:");
        decimal totalAmount = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Enter Tax Amount:");
        decimal taxAmount = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Enter Net Amount:");
        decimal netAmount = decimal.Parse(Console.ReadLine());

        var bill = new Bill
        {
            Id = billId,
            CustomerName = customerName,
            Date = billDate,
            PaymentMethod = paymentMethod,
            TotalAmount = totalAmount,
            TaxAmount = taxAmount,
            NetAmount = netAmount,

        };

        string query = @"INSERT INTO bill 
                        (BillId, CustomerName, BillDate, PaymentMethod, TotalAmount, TaxAmount, NetAmount )
                        VALUES (@Id, @CustomerName, @Date, @PaymentMethod, @TotalAmount, @TaxAmount, @NetAmount)";

        using (var connection = new MySqlConnection(connectionString))
        using (var command = new MySqlCommand(query, connection))
        {
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
    }

    static async Task GetAllBillsAsync()
    {
        string query = "SELECT * FROM bill";

        using (var connection = new MySqlConnection(connectionString))
        using (var command = new MySqlCommand(query, connection))
        {
            try
            {
                await connection.OpenAsync();
                using var reader = await command.ExecuteReaderAsync();

            Console.WriteLine("\nAll Bills:");
            while (await reader.ReadAsync())
            {
                Console.WriteLine($"{reader["BillId"]} {reader["CustomerName"]} {reader["TotalAmount"]} {reader["BillDate"]}{reader["PaymentMethod"]} {reader["TaxAmount"]} {reader["NetAmount"]}");

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
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
                Console.WriteLine($"Bill Found" +
                                  $"ID: {reader["BillId"]}\n" +
                                  $"Customer: {reader["CustomerName"]}\n" +
                                  $"Amount: {reader["TotalAmount"]}\n" +
                                  $"Date: {reader["BillDate"]}\n"+
                                  $"Payment Method: {reader["PaymentMethod"]}\n" +
                                  $"Tax Amount: {reader["TaxAmount"]}\n");
            }
            else
            {
                Console.WriteLine("Bill not found");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
    static async Task UpdateBillAsync(int id)
    {
        Console.WriteLine("Enter BillId Details:");
            int billId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Customer Name:");
            string customerName = Console.ReadLine();

            Console.WriteLine("Enter Bill Date:");
            DateTime billDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Payment Method:");
            string paymentMethod = Console.ReadLine();

            Console.WriteLine("Enter Total Amount:");
            decimal totalAmount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter Tax Amount:");
            decimal taxAmount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter Net Amount:");
            decimal netAmount = decimal.Parse(Console.ReadLine());

            var bill = new Bill
        {
            Id = billId,
            CustomerName = customerName,
            Date = billDate,
            PaymentMethod = paymentMethod,
            TotalAmount = totalAmount,
            TaxAmount = taxAmount,
            NetAmount = netAmount,
        };
        string query = @"UPDATE bill SET 
                        CustomerName = @CustomerName, 
                        BillDate = @Date, 
                        PaymentMethod = @PaymentMethod, 
                        TotalAmount = @TotalAmount, 
                        TaxAmount = @TaxAmount, 
                        NetAmount = @NetAmount 
                        WHERE BillId = @Id";
        using var connection = new MySqlConnection(connectionString);
        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", bill.Id);
        command.Parameters.AddWithValue("@CustomerName", bill.CustomerName);
        command.Parameters.AddWithValue(@"Date", bill.Date);
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
                Console.WriteLine("Bill updated successfully.");
            }
            else
            {
                Console.WriteLine("Update failed ");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Update failed: " + ex.Message);
        }
        finally
        {
            await connection.CloseAsync();

        }
    }
    static async Task DeleteBillAsync(int id)
    {
        string query = "DELETE FROM bill WHERE BillId = @Id";

        using var connection = new MySqlConnection(connectionString);
        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", id);

        try
        {
            await connection.OpenAsync();
            int result = await command.ExecuteNonQueryAsync();
            if (result > 0)
            {
                Console.WriteLine("Bill deleted successfully.");
            }
            else
            {
                Console.WriteLine("Delete failed.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Delete failed: " + ex.Message);
        }
        finally
        {
            await connection.CloseAsync();
        }
    }
}
