using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using SpringHeroBanking.Unity;

namespace SpringHeroBanking.Entity
{
    public class SPHAccount
    {
        private string _username;
        private string _password;
        private string _fullname;
        private string _accountNumber;
        private decimal _balance;
        private string _dob;
        private int _gender;
        private string _identity;
        private string _createAt;
        private string _updateAt;
        private string _email;
        private string _address;
        private string _phoneNumber;
        private string _salt;
        private int _status;
        private string _cpasword;


        private Hash _hash = new Hash();

        public string Cpasword
        {
            get => _cpasword;
            set => _cpasword = value;
        }

        public string Salt
        {
            get => _salt;
            set => _salt = value;
        }

        public string Fullname
        {
            get => _fullname;
            set => _fullname = value;
        }

        public string Identity
        {
            get => _identity;
            set => _identity = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string Address
        {
            get => _address;
            set => _address = value;
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => _phoneNumber = value;
        }

        public string Name
        {
            get => _username;
            set => _username = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public string AccountNumber
        {
            get => _accountNumber;
            set => _accountNumber = value;
        }

        public decimal Balance
        {
            get => _balance;
            set => _balance = value;
        }

        public string Dob
        {
            get => _dob;
            set => _dob = value;
        }

        public int Gender
        {
            get => _gender;
            set => _gender = value;
        }

        public string CreateAt
        {
            get => _createAt;
            set => _createAt = value;
        }

        public string UpdateAt
        {
            get => _updateAt;
            set => _updateAt = value;
        }

        public int Status
        {
            get => _status;
            set => _status = value;
        }


        public void EncryptPassword()
        {
            if (string.IsNullOrEmpty(_password))
            {
                throw new ArgumentNullException("Password is null or empyt.");
            }

            _password = _hash.EncryptString(_password, _salt);
        }

        public void createAccountNumber()
        {
            _accountNumber = Guid.NewGuid().ToString(); //uinque
        }

        public void createSalt()
        {
            _salt = Guid.NewGuid().ToString().Substring(0, 7);
        }

        public Boolean CheckEncryptedPassword(string password)
        {
            //Đã mã hóa password nhập vào kèm muối,trả về một chuỗi đã mã hóa
            var checkPassword = _hash.EncryptString(password, _salt);
            //so sánh 2 Chuỗi  đã mã hóa
            return checkPassword == _password;
        }


        public Dictionary<string, string> ValidateAccount()
        {
            var error = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(this._username))
            {
                error.Add("name", "Tài khoản không thể bỏ trống");
            }
            else if (this._username.Length < 6)
            {
                error.Add("name", "Tài khoản không ngắn hơn 6 ký tự");
            }

            if (string.IsNullOrEmpty(this._password))
            {
                error.Add("password", "Mật khẩu không được để trống");
                ;
            }
            else if (this._password.Length < 8)
            {
                error.Add("pasword", "Mật khẩu phải có 8 ký tự");
            }

            if (string.IsNullOrEmpty(this._fullname))
            {
                error.Add("fullName", "Không dduojc bỏ trống trường này");
            }

            if (this._balance < 0)
            {
                error.Add("balance", "Số dư tài khoản không đủ");
            }

            if (this._phoneNumber.Length < 10)
            {
                error.Add("phoneNumber", "Số điện thoại phải có độ dài lớn hơn 10 chữ số");
            }


            return error;
        }

        public override string ToString()
        {
            return "accountNumber" + this._accountNumber + "\t name" + this._username + "\t password" + this._password +
                   "\t balance" + this._balance
                   + "\t dob" + this._dob + "\t gender" + this._gender + "\t identity " + this._identity +
                   "\t createAt" +
                   this.CreateAt
                   + "\t updateAt" + this._updateAt + "\t email " + this._email + "\t address" + this._address +
                   "\t phone" + this._phoneNumber
                   + "\t status" + this._status;
        }

        public SPHAccount()
        {
        }

        public SPHAccount(string username, string password, string fullname, string salt, string accountNumber,
            decimal balance,
            string dob, int gender, string identity, string at, string updateAt, string email, string address,
            string phoneNumber, int status)
        {
            _username = username;
            _password = password;
            _fullname = fullname;
            _accountNumber = accountNumber;
            _balance = balance;
            _dob = dob;
            _gender = gender;
            _identity = identity;
            _createAt = at;
            _updateAt = updateAt;
            _email = email;
            _address = address;
            _phoneNumber = phoneNumber;
            _salt = salt;
            _status = status;
        }
    }
}