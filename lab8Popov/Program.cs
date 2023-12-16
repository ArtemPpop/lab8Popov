public class Program
{
    public static void Main()
    {
        CommunalPay[] payments = RandPay(10);

        Console.WriteLine("Платежи за последние три месяца:");

        DateTime threeMonths = DateTime.Now.AddMonths(-3);

        foreach (var payment in payments)
        {
            if (payment.PaymentDate >= threeMonths)
            {
                int decadeNumber = (payment.PaymentDate.Day - 1) / 10 + 1;
                Console.WriteLine($"Номер счёта {payment.AccountNumber} ,Плательщик: {payment.ConsumerName}, Номер декады: {decadeNumber},"+ 
                    $" Дата платежа: {payment.PaymentDate}, Сумма платежа: {payment.PaymentAmount:F2}");
            }
        }
    }

    public static CommunalPay[] RandPay(int count)
    {
        CommunalPay[] payments = new CommunalPay[count];
        Random rand = new Random();

        for (int i = 0; i < count; i++)
        {
            DateTime paymentDate = DateTime.Now.AddMonths(-3).AddDays(rand.Next(90));
            payments[i] = new CommunalPay
            {
                AccountNumber = rand.Next(1000000000),
                ConsumerName = i + 1,
                Service =  i,
                AmountCharged = rand.Next(100, 500),
                PaymentDate = paymentDate,
                PaymentAmount = rand.NextDouble() * 10000
            };
        }

        return payments;
    }
}
public class CommunalPay
{
    public int AccountNumber { get; set; }
    public int ConsumerName { get; set; }
    public int Service { get; set; }
    public double AmountCharged { get; set; }
    public DateTime PaymentDate { get; set; }
    public double PaymentAmount { get; set; }
}