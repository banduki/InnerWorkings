namespace InnerWorkingsCodeAssignment
{
    public static class PercentageExtensions
    {
        public static decimal AddPercentage(this decimal value, decimal rate)
        {
            return value * (1 + rate);
        }
    }
}
