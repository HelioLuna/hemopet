
namespace hemopet.Core.Services.Local.LocalService
{
    public class FileStore
    {
        private static readonly string _EXAMPLES = "examples";

        private string _value;
        public string Value => _value;

        private FileStore(string value)
        {
            _value = value;
        }

        public static FileStore EXAMPLES() { return new FileStore(_EXAMPLES); }
    }
}
