namespace Currency_converter.Services
{
    public interface IConverterServices
    {
        string Converter(double inputAmount, string formControl, string toControl);
    }
}
