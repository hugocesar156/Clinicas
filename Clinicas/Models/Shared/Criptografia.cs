using System;

namespace Clinicas.Models.Shared
{
    public class Criptografia
    {
        public static string TratarCriptografia(string senha)
        {
            try
            {
                var salt = BCrypt.Net.BCrypt.GenerateSalt(12);
                return BCrypt.Net.BCrypt.HashPassword(senha, salt);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static bool ValidarCriptografia(string senha, string hash)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(senha, hash);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
