using System.Security.Cryptography;
using System.Text;

namespace APIMarketList.Infra.CrossCutting.Cryptography
{
    public class EncryptKey
    {
        public byte[]? Key { get; set; }
        public byte[]? IV { get; set; }
    }
}
