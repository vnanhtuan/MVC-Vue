using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Core.Application.Common
{
    public class Utility
    {
        static public bool PasswordCheckSecurity(string password)
        {
            string passwordRegex = @"^(?=(.*\d){1})(?=.*[a-z])(?=.*[A-Z]).{8,}$";

            bool isValid = string.IsNullOrEmpty(password) == false;
            if (isValid)
                isValid = Regex.IsMatch(password, passwordRegex);
            return isValid;
        }
        static public string PasswordEncrypt(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            StringBuilder password = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(input));

                foreach (Byte b in result)
                    password.Append(b.ToString("x2"));
            }

            return password.ToString();
        }

        static public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        static public bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
