namespace Currency_converter.Services
{
    using RestSharp;
    using System.Text.RegularExpressions;

    public class ConverterServices : IConverterServices
    {
        public ConverterServices()
        {

        }

        public string Converter(double inputAmount, string formControl, string toControl)
        {
            var response = GetRespons(formControl);

            var velue = getVelue(response.Content, toControl);

            var result = double.Parse(velue) * inputAmount;

            return $"{inputAmount} {formControl} to {result} {toControl}";
        }

        public string ConverterApi(string formControl)
        {
            var response = GetRespons(formControl);

            return response.Content;
        }

        private IRestResponse GetRespons(string formControl)
        {
            var url = $"https://api.exchangeratesapi.io/latest?base={formControl}";
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("0", "0");
            IRestResponse response = client.Execute(request);

            return response;
        }

        private string getVelue(string text, string toControl)
        {
            text = text.Replace("\"", string.Empty);
            System.Console.WriteLine(text);
            string pattern = $"{toControl}:[0-9]*.[0-9]*";

            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(text, pattern, options))
            {
                var velue = m.Value.Substring(4, m.Value.Length-4);
               
                return velue;
            }

            return  "";
        }
    }
}
