using System.Text;

namespace hemopet.Core.Services.Remote.RequestProvider
{
    public class Endpoint
    {

#if DEBUG
        private static readonly string BASE_URL = "http://localhost:8080/";
#else
        private static readonly string BASE_URL = "http://186.249.52.148:3000/";
#endif

        private static readonly string EXAMPLE = "example";

        private string _value;

        public string Value => _value;

        private Endpoint(string value)
        {
            if (!value.Contains(BASE_URL)) _value = BASE_URL + value;
            else _value = _value + value;
        }

        public Endpoint AddParam(string key, object value)
        {
            StringBuilder urlBuilder = new StringBuilder(this.Value);
            if (!urlBuilder.ToString().Contains("?")) urlBuilder.Append("?");

            urlBuilder.Append(key);
            urlBuilder.Append("=");
            urlBuilder.Append(value);
            urlBuilder.Append("&");

            return new Endpoint(urlBuilder.ToString());
        }

        public Endpoint AddToUrl(string url)
        {
            StringBuilder urlBuilder = new StringBuilder(this.Value);
            urlBuilder.Append(url);

            return new Endpoint(urlBuilder.ToString());
        }

        public static Endpoint Example() { return new Endpoint(EXAMPLE); }

    }
}
