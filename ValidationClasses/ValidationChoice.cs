namespace Assignment1
{
    public class ValidationChoice : IValidationChoice
    {
        public bool IsValidChoice(string ch)
        {
            bool result = int.TryParse(ch, out _);

            return result;
        }
    }
}
