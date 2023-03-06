using System.Security.Cryptography;
using System.Text;

namespace Infraestructure.Utilities
{
    public class Utilities
    {
        private  SHA256 _sha256;
        public Utilities()
        {
            _sha256 = SHA256.Create();
        }
        public  string encriptarPassword(string pass)
        {
            if(pass != null)
            {
                byte[] bytes = _sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                string hashedPass = builder.ToString();

                return hashedPass;
            }

            return "pass vacio";
        }
    }
}
