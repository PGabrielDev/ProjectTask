namespace ProjectsTasks.utils
{
    public class PasswordUtils
    {
        public static string HashPw(string password)
        {
            string hashPw = BCrypt.Net.BCrypt.HashPassword(password);
            return hashPw;
        }

        public static bool VerifyPw(string password, string hashPassword)
        {
            bool equals = BCrypt.Net.BCrypt.Verify(password, hashPassword);
            return equals;
        }
    }
}
