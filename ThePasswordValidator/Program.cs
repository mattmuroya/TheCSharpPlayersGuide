namespace ThePasswordValidator;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Enter password to validate: ");
            Console.WriteLine(PasswordValidator.Validate(
                Console.ReadLine()));
        }
    }
}

static class PasswordValidator
{
    public static bool Validate(string? password)
    {
        if (password == null)
            return false;

        if (password.Length is < 6 or > 13)
            return false;

        var hasUpper = false;
        var hasLower = false;
        var hasDigit = false;

        foreach (var c in password)
        {
            if (char.IsUpper(c)) hasUpper = true;
            if (char.IsLower(c)) hasLower = true;
            if (char.IsDigit(c)) hasDigit = true;
        }

        return hasUpper && hasLower && hasDigit;
    }
}