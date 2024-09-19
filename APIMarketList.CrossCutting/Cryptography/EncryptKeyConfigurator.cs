using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Text;

namespace APIMarketList.Infra.CrossCutting.Cryptography
{
    public class EncryptKeyConfigurator : IConfigureOptions<EncryptKey>
    {
        private readonly IConfiguration _configuration;

        public EncryptKeyConfigurator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(EncryptKey options)
        {
            string keyString = _configuration["Cryptography:Key"];
            if (string.IsNullOrEmpty(keyString))
            {
                throw new InvalidOperationException("A chave não está configurada ou está vazia.");
            }
            byte[] keyBytes = Encoding.UTF8.GetBytes(keyString);

            if (keyBytes.Length > 32)
            {
                Array.Resize(ref keyBytes, 32);
            }
            else if (keyBytes.Length < 16)
            {
                throw new InvalidOperationException("A chave deve ter pelo menos 16 bytes.");
            }
            options.Key = keyBytes;

            string ivString = _configuration["Cryptography:IV"];
            if (string.IsNullOrEmpty(ivString))
            {
                throw new InvalidOperationException("O IV não está configurado ou está vazio.");
            }
            byte[] ivBytes = Encoding.UTF8.GetBytes(ivString);
            if (ivBytes.Length != 16)
            {
                throw new InvalidOperationException("O IV deve ter exatamente 16 bytes.");
            }
            options.IV = ivBytes;
        }
    }
}
