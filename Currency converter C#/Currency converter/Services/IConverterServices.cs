namespace Currency_converter.Services
{
    using RestSharp;

    public interface IConverterServices
    {
        string Converter(double inputAmount, string formControl, string toControl);

        string ConverterApi( string formControl);
    }
}
