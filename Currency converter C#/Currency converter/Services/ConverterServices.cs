namespace Currency_converter.Services
{
    using RestSharp;
    using System.Text.RegularExpressions;

    public class ConverterServices : IConverterServices
    {
        public ConverterServices()
        {

        }

        public string Converter(int inputAmount, string formControl, string toControl)
        {
            var client = new RestClient("https://api.exchangeratesapi.io/latest?base=BGN");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("0", "0");
            IRestResponse response = client.Execute(request);
            var velue = getVelue(response.Content, toControl, inputAmount);

            var result = double.Parse(velue) * inputAmount;

            return $"{inputAmount}{formControl} to {result}{toControl}";
        }

        private string getVelue(string text, string toControl, int inputAmount)
        {
            string pattern = $"{toControl}.: [0-9]*.[0-9]*";

            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(text, pattern, options))
            {
                var velue = m.Value.Substring(6, m.Value.Length-6);
               
                return velue;
            }

            return  "";
        }
    }
}
