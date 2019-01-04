using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using ConsoleApp3.model;
using MySql.Data.MySqlClient;
using SpringHeroBanking.Entity;

namespace SpringHeroBanking.Model
{
    public class TransactionModel
    {
        private string server = "localhost";
        private string nameDB = "transation";
        private string userName = "root";
        private string password = "";

        public void saveDB(SPHTransation transation)
        {
            var cnnString = string.Format("Server={0};Database={1};Uid={2};Pwd={3};SslMode=none", server,
                nameDB, userName, password);
            var con = new MySqlConnection();
            con.Open();
            MySqlCommand msd = new MySqlCommand(
                "insert into students(id,amount,content,senderAccountNumber,recevierAccountNumber,type,createAt,status) " +
                " values(@id, @amount, @content,@senderAccountNumber,@senderAccountNumber,@type,@createAt,@status)",
                con);
            msd.Parameters.AddWithValue("@id", transation.Id);
            msd.Parameters.AddWithValue("@amount", transation.Amount);
            msd.Parameters.AddWithValue("@content", transation.Content);
            msd.Parameters.AddWithValue("@senderAccountNumber", transation.SenderAccountNumber);
            msd.Parameters.AddWithValue("@recevierAccountNumber", transation.RecevierAccountNumber);
            msd.Parameters.AddWithValue("@type", transation.Type);
            msd.Parameters.AddWithValue("@createAt", transation.CreateAt);
            msd.Parameters.AddWithValue("@status", transation.Status);
            msd.ExecuteNonQuery();
            con.Clone();
        }
    }
}