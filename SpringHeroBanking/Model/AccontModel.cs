using System;
using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using ConsoleApp3.model;
using MySql.Data.MySqlClient;
using SpringHeroBanking.Entity;

namespace SpringHeroBanking.Model
{
    public class AccontModel
    {
        private SPHAccount account = new SPHAccount();

        public Boolean save(SPHAccount account)
        {
            DbConnection.Instance().OpenConnection();
            string sqlString =
                "insert into `account`(username,password,fullname,accountNumber,balance,identityCard,dob,gender,address,createAt,updateAt,email,phoneNumber,status,salt)" +
                " values (@name, @password, @fullname,@accountNumber,@balance,@identity,@dob,@gender,@address,@createAt,@updateAt,@email,@phoneNumber,@status,@salt)";
            MySqlCommand mcd = new MySqlCommand(sqlString, DbConnection.Instance().Connection);
            mcd.Parameters.AddWithValue("@name", account.Name);
            mcd.Parameters.AddWithValue("@password", account.Password);
            mcd.Parameters.AddWithValue("@fullname", account.Fullname);
            mcd.Parameters.AddWithValue("@accountNumber", account.AccountNumber);
            mcd.Parameters.AddWithValue("@balance", account.Balance);
            mcd.Parameters.AddWithValue("@identity", account.Identity);
            mcd.Parameters.AddWithValue("@dob", account.Dob);
            mcd.Parameters.AddWithValue("@gender", account.Gender);
            mcd.Parameters.AddWithValue("@address", account.Address);
            mcd.Parameters.AddWithValue("@createAt", account.CreateAt);
            mcd.Parameters.AddWithValue("@updateAt", account.UpdateAt);
            mcd.Parameters.AddWithValue("@email", account.Email);
            mcd.Parameters.AddWithValue("@phoneNumber", account.PhoneNumber);
            mcd.Parameters.AddWithValue("@status", account.Status);
            mcd.Parameters.AddWithValue("@salt", account.Salt);
            mcd.ExecuteNonQuery();
            DbConnection.Instance().CloseConnection();
            return true;
        }

        public Boolean GetByUsername(string name)
        {
            DbConnection.Instance().OpenConnection();
            string sql = "select * from `account` where name = @name";
            MySqlCommand msc = new MySqlCommand(sql, DbConnection.Instance().Connection);
            msc.Parameters.AddWithValue("@name", name);
            var reader = msc.ExecuteReader();
            var isExit = reader.Read();
            DbConnection.Instance().CloseConnection();
            return isExit;
        }

        public SPHAccount login(string name)
        {
            DbConnection.Instance().OpenConnection();
            string sql = "select * from `account` where username = @name";
            MySqlCommand msc = new MySqlCommand(sql, DbConnection.Instance().Connection);
            msc.Parameters.AddWithValue("@name", name);
            MySqlDataReader mdr = msc.ExecuteReader();
            SPHAccount account = null;
            if (mdr.Read())
            {
                account = new SPHAccount();
                var accountNumber = mdr.GetString("accountNumber");
                var name1 = mdr.GetString("username");
                var password1 = mdr.GetString("password");
                var fullname = mdr.GetString("fullname");
                var balance = mdr.GetDecimal("balance");
                var identity = mdr.GetString("identityCard");
                var dob = mdr.GetString("dob");
                var gender = mdr.GetInt32("gender");
                var address = mdr.GetString("address");
                var createAt = mdr.GetString("createAt");
                var updateAt = mdr.GetString("updateAt");
                var email = mdr.GetString("email");
                var phoneNumber = mdr.GetString("phoneNumber");
                var status = mdr.GetInt32("status");
            }

            DbConnection.Instance().CloseConnection();
            return account;
        }

        public bool Deposit(SPHAccount currentSphLoggedAccount, SPHTransation sphTransation)
        {
            DbConnection.Instance().OpenConnection();
            var transaction = DbConnection.Instance().Connection.BeginTransaction();

            try
            {
                var queryCheckBalance =
                    "select balance from `account` where accountNumber = @accountNumber and status = 1";
                var command = new MySqlCommand(queryCheckBalance, DbConnection.Instance().Connection);
                command.Parameters.AddWithValue("@accountNumber", Program.currentSphLoggedAccount.AccountNumber);
                var reader = command.ExecuteReader();
                decimal currentBalance = 0;
                if (reader.Read())
                {
                    currentBalance = reader.GetDecimal("balance");
                }

                if (sphTransation.Type == SPHTransation.TransactionType.WITHDRAW &&
                    currentBalance < sphTransation.Amount)
                {
                    Console.WriteLine("Số dư tài khoản hiện");
                }

                if (sphTransation.Type == SPHTransation.TransactionType.WITHDRAW)
                {
                    currentBalance -= sphTransation.Amount;
                }

                if (sphTransation.Type == SPHTransation.TransactionType.DEPOSIT)
                {
                    currentBalance += sphTransation.Amount;
                }

                var updateCurrentBalance = 0;
                var updateBalance =
                    "update `account` set balance =@balance where accountNumber =@accountNumber and status =1";
                var updatecmd = new MySqlCommand(updateBalance, DbConnection.Instance().Connection);
                updatecmd.Parameters.AddWithValue("@balance", currentBalance);
                updatecmd.Parameters.AddWithValue("@accountNumber", Program.currentSphLoggedAccount.AccountNumber);
                updateCurrentBalance = updatecmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                DbConnection.Instance().CloseConnection();
            }


            return false;
        }
    }
}