namespace Molibar.Infrastructure.Extensions.NumberFormatting
{
    public static class NumberFormatExtensions
    {
        public static string ToFormattedString(this double value)
        {
            return value.ToString("#,##0.00;-#,##0.00;");
        }

        public static string ToFormattedString(this int value)
        {
            return value.ToString("#,##0;-#,##0;");
        }
    }
}
