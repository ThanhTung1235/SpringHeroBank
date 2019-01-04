using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using SpringHeroBanking.Entity;
using SpringHeroBanking.Model;
using SpringHeroBanking.Unity;
using SpringHeroBanking.view;

namespace SpringHeroBanking
{
    class Program
    {
        public static SPHAccount currentSphLoggedAccount;
        

        static void Main(string[] args)
        {
            var mainThread = new MainThread();
            if (currentSphLoggedAccount == null)
            {
                mainThread.GenerateMenuDefault();
            }
            else
            {
                mainThread.GenerateCustomerMenu();
            }

        }

        
    }
}