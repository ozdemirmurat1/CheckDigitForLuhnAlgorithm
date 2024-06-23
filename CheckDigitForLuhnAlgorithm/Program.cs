namespace CheckDigitForLuhnAlgorithm
{
    // Mustafa Bükülmez hocamıza teşekkür ederim.
    internal class Program
    {
        static void Main(string[] args)
        {
            CardLuhnAlgorithm("4836749597193824");
        }

        static string CheckCardNumber(string text)
        {
            text = text.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", "").Replace("_", "");
            return text;
        }

        static bool CardLengthControl(string cardNo)
        {
            if(cardNo.Length==16)
                return true;
            else return false;
        }

        static bool CheckNumericValueControl(string value)
        {
            foreach(char chr in value)
            {
                if(!Char.IsNumber(chr)) return false;
            }

            return true;
        }

        static int AddNumberDigits(int sayi)
        {
            int toplam = 0;
            //while (sayi>0)
            //{
            //    toplam += sayi % 10;
            //    sayi /= 10;
            //}

            if (sayi >= 10)
                toplam = sayi - 9;
            else
                toplam = sayi;

            return toplam;
        }

        static bool CardLuhnAlgorithm(string cardNo)
        {
            cardNo=CheckCardNumber(cardNo);

            if(CardLengthControl(cardNo)==false)
                return false;
            else if(CheckNumericValueControl(cardNo)==false) 
                return false;
            else
            {
                int sum_double = 0;
                int sum_odd = 0;

                for (int i = 0; i < cardNo.Length; i++)
                {
                    int eleman = Convert.ToInt32(cardNo[i].ToString());
                    if (i % 2 == 0)
                        sum_double += AddNumberDigits(eleman * 2);
                    else
                        sum_odd += eleman;
                }
                int result = (sum_odd + sum_double) % 10;

                if (result == 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
