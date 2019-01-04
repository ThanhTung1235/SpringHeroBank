using System;
using System.Collections.Generic;
using SpringHeroBanking.Entity;
using SpringHeroBanking.Model;
using SpringHeroBanking.Unity;

namespace SpringHeroBanking.Controller
{
    public class Controller
    {
        private SPHAccount account = new SPHAccount();
        private AccontModel model = new AccontModel();
        private Utility utility = new Utility();

        public bool getInfoUser()
        {
            SPHAccount account = RegisterAccount();
            Dictionary<string, string> errors = account.ValidateAccount();
            if (errors.Count > 0)
            {
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }
            }
            else
            {
                account.EncryptPassword();
                model.save(account);
                Console.WriteLine("create success");
                return true;
            }

            return false;
        }

        public void loginUser()
        {
            Console.WriteLine("Enter account infor.");
            Console.WriteLine("Username: ");
            var username = Console.ReadLine();
            Console.WriteLine("Password: ");
            var password = Console.ReadLine();
            SPHAccount account = model.login(username);
            if (account == null)
            {
                Console.WriteLine("ádas");
                return;
            }

            //check password sau khi mã hóa
            if (!account.CheckEncryptedPassword(password))
            {
                Console.WriteLine("Invalid account information.");
                return;
            }

            Console.WriteLine("Login success!");
        }

        public SPHAccount RegisterAccount()
        {
            Console.WriteLine("----------------REGISTER INFOMATION----------------");
            Console.WriteLine("Nhap ten nguoi dung:");
            var name = Console.ReadLine();
            Console.WriteLine("Nhap password");
            var password = Console.ReadLine();
            Console.WriteLine("confirm password");
            var cpassword = Console.ReadLine();
            Console.WriteLine("Nhap ten day du cua ban:");
            var fullname = Console.ReadLine();
            Console.WriteLine("balance:");
            var balance = utility.getDecimal();
            Console.WriteLine("identity:");
            var identity = Console.ReadLine();
            Console.WriteLine("date of birth");
            var dob = Console.ReadLine();
            Console.WriteLine("gender");
            var gender = utility.getNumber();
            Console.WriteLine("address:");
            var address = Console.ReadLine();
            Console.WriteLine("creatAt:");
            var createAt = Console.ReadLine();
            Console.WriteLine("update At:");
            var updateAt = Console.ReadLine();
            Console.WriteLine("Email:");
            var email = Console.ReadLine();
            Console.WriteLine("phone:");
            var phoneNumber = Console.ReadLine();
            Console.WriteLine("status:");
            var status = utility.getNumber();
            var account = new SPHAccount
            {
                Name = name,
                Password = password,
                Cpasword = cpassword,
                Fullname = fullname,
                Balance = balance,
                Identity = identity,
                Dob = dob,
                Gender = gender,
                Address = address,
                CreateAt = createAt,
                UpdateAt = updateAt,
                Email = email,
                PhoneNumber = phoneNumber,
                Status = status,
            };
            return account;
        }

        public void Deposit()
        {
            var utility = new Utility();
            Console.WriteLine("Bạn muốn gửi bao nhiêu tiền :");
            var amount = utility.getDecimal();
            Console.WriteLine("Nội dung giao dịch:");
            var content = Console.ReadLine();
            SPHTransation sphTransation = new SPHTransation()
            {
                Id = Guid.NewGuid().ToString(),
                Content = content,
                Amount = amount,
                SenderAccountNumber = Program.currentSphLoggedAccount.AccountNumber,
                RecevierAccountNumber = Program.currentSphLoggedAccount.AccountNumber,
                Type = SPHTransation.TransactionType.DEPOSIT,
                Status = SPHTransation.ActiveStatus.DONE
            };
            if (model.Deposit(Program.currentSphLoggedAccount, sphTransation))
            {
                Console.WriteLine("Giao dịch thành công");
            }
            else
            {
                Console.WriteLine("Giao dịc h không thành công");
            }
        }

        public void Withdraw()
        {
            var utility = new Utility();
            Console.WriteLine("Bạn muốn gửi bao nhiêu tiền :");
            var amount = utility.getDecimal();
            Console.WriteLine("Nội dung giao dịch:");
            var content = Console.ReadLine();
            SPHTransation sphTransation = new SPHTransation()
            {
                Id = Guid.NewGuid().ToString(),
                Content = content,
                Amount = amount,
                SenderAccountNumber = Program.currentSphLoggedAccount.AccountNumber,
                RecevierAccountNumber = Program.currentSphLoggedAccount.AccountNumber,
                Type = SPHTransation.TransactionType.WITHDRAW,
                Status = SPHTransation.ActiveStatus.DONE
            };
            if (model.Deposit(Program.currentSphLoggedAccount, sphTransation))
            {
                Console.WriteLine("Giao dịch thành công");
            }
            else
            {
                Console.WriteLine("Giao dịch không thành công");
            }
        }

        public void ShowInfoAcc()
        {
            Program.currentSphLoggedAccount = model.login(Program.currentSphLoggedAccount.Name);
            Console.WriteLine("Số tài khoản :" + Program.currentSphLoggedAccount.AccountNumber);
            Console.WriteLine("Tên chủ tài khoản :" + Program.currentSphLoggedAccount.Name);
            Console.WriteLine("Số dư tài khoản hiện tại :" + Program.currentSphLoggedAccount.Balance + "(VND)");
        }
    }
}