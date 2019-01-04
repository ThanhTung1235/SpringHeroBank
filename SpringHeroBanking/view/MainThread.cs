using System;
using SpringHeroBanking.Unity;

namespace SpringHeroBanking.view
{
    public class MainThread
    {
        private static Controller.Controller controller = new Controller.Controller();
        private static Utility utility = new Utility();

        public void GenerateMenuDefault()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            while (true)
            {
                Console.WriteLine("----------------Chào mừng bạn đến với ngân hàng CDCC----------------");
                Console.WriteLine("1. Tạo mới tài khoản");
                Console.WriteLine("2. Đăng nhập tài khoản");
                Console.WriteLine("3. Giới thiệu về ngân hàng");
                Console.WriteLine("4. Tư vấn trục tuyến ");
                Console.WriteLine("5. Thoát chương trình");
                Console.WriteLine("Vui lòng nhập lựa chọ của bạn:(1|2|3|4|5)");
                Console.WriteLine("---------------------------------------------------------------------");
                var choice = utility.getNumber();
                switch (choice)
                {
                    case 1:
                        controller.RegisterAccount();
                        break;
                    case 2:
                        controller.loginUser();
                        break;
                    case 3:
                        Console.WriteLine("3. Đăng nhập tài khoản");
                        break;
                    case 4:
                        Console.WriteLine("3. Giới thiệu về ngân hàng");
                        break;
                    case 5:
                        Environment.Exit(1);
                        break;
                }

                Console.WriteLine("Nhấn enter để tiếp tục");
                Console.ReadLine();
                if (Program.currentSphLoggedAccount != null)
                {
                    break;
                }
            }
        }

        public  void GenerateCustomerMenu()
        {
            while (true)
            {
                Console.WriteLine("--------------Ngân hàng CDCC--------------");
                Console.WriteLine("Xin chào quý khách " + Program.currentSphLoggedAccount.Fullname);
                Console.WriteLine("1. Kiếm tra thông tin tài khoản");
                Console.WriteLine("2. Rút tiền.");
                Console.WriteLine("3. Gửi tiền.");
                Console.WriteLine("4. Chuyển tiền.");
                Console.WriteLine("5. Lịch sử giao dịch.");
                Console.WriteLine("6. Đăng xuất.");
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("Hãy nhập lựa chọn của bạn; (1|2|3|4|5|6): ");
                var choice = utility.getNumber();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Thông tin tài khoản");
                        controller.ShowInfoAcc();
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("2. Rút tiền.");
                        controller.Withdraw(); //1
                        break;
                    case 3:
                        Console.WriteLine("3. Gửi tiền.");
                        controller.Deposit(); //2
                        break;
                    case 4:
                        Console.WriteLine("4. Chuyển tiền ");
//                        controller.SenderTransfer();
                        break;
                    case 5:
                        Console.WriteLine("5. Lịch sử dao dịch.");

                        break;
                    case 6:
                        Console.WriteLine("See you again");
                        break;
                }

                if (Program.currentSphLoggedAccount == null)
                {
                    break;
                }
            }
        }
    }
}