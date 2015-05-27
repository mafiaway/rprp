using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mw
{
    class Program
    {
        private static Player player;
        private static bool debugOn = true;

        static void Main(string[] args)
        {

            player = new Player();

            string username = "";// fill these in
            string password = "";// to start

            Login(username, password);

            Sleep(4000);
            BankWithdraw(15000);
            Sleep(2000);
            BankDeposit(7500);

            Console.ReadKey();
        }

        private static void Sleep(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }

        private static void Debug(string message)
        {
            if (debugOn)
                Console.WriteLine(message);
        }

        private static bool Login(string name, string pass)
        {
            bool b = player.Login(name, pass);
            if (b)
                Debug("Login successfull");
            else
                Debug("Login failed");
            return b;

        }
        
//         //does not work yet
//         private static bool Logout()
//         {
//             bool b = player.Logout();
//             if (b)
//                 Debug("Logout successfull");
//             else
//                 Debug("Logout failed");
//             return b;
//         }

        private static bool BankDeposit(int ammount)
        {
            bool b = player.Deposit(ammount);
            if (b)
                Debug("Je hebt " + ammount + " op je bank gestort");
            else
                Debug("You don't have enough cash");
            return b;
        }

        private static bool BankWithdraw(int ammount)
        {
            bool b = player.Withdraw(ammount);
            if (b)
                Debug("Je hebt " + ammount + " van je bank afgehaald.");
            else
                Debug("You don't have enough balance.");
            return b;
        }
    }
}
