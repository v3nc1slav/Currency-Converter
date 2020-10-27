namespace Currency_converter.Services
{
    public interface IConverterServices
    {
        string Converter(int inputAmount, string formControl, string toControl);
    }
}
