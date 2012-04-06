namespace Molibar.Infrastructure.Extensions.NumberFormatting
{
    public static class PriceFormatExtensions
    {
        public static string ToFormattedPrice(this double price)
        {
            return price.ToString("£#,##0.00;-£#,##0.00;");
        }

        public static string ToFormattedPrice(this int price)
        {
            return price.ToString("£#,##0;-£#,##0;");
        }
    }
}
