using System;

namespace mw
{
    partial class Player
    {
        internal bool Deposit(long ammount)
        {
            string responds = "";

            try
            {
                responds = con.SimpleHttpPost(homepage + "bank.php", "type=into&amount_put=" + ammount + "&eo=Maak+de+transactie");
            }
            catch (Exception ex)
            {
                Console.WriteLine("E Deposit exception: " + ex.ToString());
            }

            if (responds.Contains("op je bank gezet"))
                return true;
            else
                return false;
        }

        internal bool Withdraw(long ammount)
        {
            string responds = "";

            try
            {
                responds = con.SimpleHttpPost(homepage + "bank.php", "type=off&amount_put=" + ammount + "&eo=Maak+de+transactie");
            }
            catch (Exception ex)
            {
                Console.WriteLine("E Withdraw exception: " + ex.ToString());
            }

            if (responds.Contains("van je bank afgehaald"))
                return true;
            else
                return false;
        }
    }
}
