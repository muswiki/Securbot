using System;
using System.IO;

namespace SecurBot
{
    class Interaction
    {
        public static string ProfileIcon = "None";
        public static string UserPassword = "";

        public static (string name, string age, string city) AskUserInfo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string name = GetUserInput("What is your name: ");
            string age = GetValidAge();
            string city = GetValidCity();
            Console.ResetColor();

            ChooseIcon();
            SetPassword();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Effects.Typewriter($"\nGreetings {name}! You are {age} years old and hail from {city}.", 40);
            Effects.Typewriter("Cyberville welcomes you — your one stop destination for online safety!", 40);
            Console.ResetColor();

            return (name, age, city);
        }

        // ✅ Fixed: GetUserInput
        public static string GetUserInput(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("! Please enter a valid answer.");
                Console.ResetColor();
                return GetUserInput(prompt);
            }

            return input;
        }

        // ✅ Fixed: GetValidAge
        public static string GetValidAge()
        {
            while (true)
            {
                Console.Write("What is your age: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int age))
                {
                    if (age > 0 && age < 120) return age.ToString();
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a realistic age.");
                Console.ResetColor();
            }
        }

        // ✅ Fixed: GetValidCity
        public static string GetValidCity()
        {
            while (true)
            {
                Console.Write("Which city are you from: ");
                string city = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(city) && city.Length > 2)
                {
                    return city;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("That doesn’t look like a real city. Try again.");
                Console.ResetColor();
            }
        }

        public static void ChooseIcon()
        {
            Console.WriteLine("\nChoose a profile icon:");
            Console.WriteLine("[1] Mouse");
            Console.WriteLine("[2] Cat");
            Console.WriteLine("[3] Fish");
            Console.WriteLine("[4] Bird");

            string choice = Console.ReadLine();
            if (choice == "1") ProfileIcon = "🐭 Mouse";
            else if (choice == "2") ProfileIcon = "🐱 Cat";
            else if (choice == "3") ProfileIcon = "🐟 Fish";
            else if (choice == "4") ProfileIcon = "🐦 Bird";
            else ProfileIcon = "None";
        }

        public static void SetPassword()
        {
            while (true)
            {
                Console.Write("Create a password (min 6 chars): ");
                string pass1 = Console.ReadLine();
                Console.Write("Confirm password: ");
                string pass2 = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(pass1) && pass1.Length >= 6 && pass1 == pass2)
                {
                    UserPassword = pass1;
                    Console.WriteLine("Password set successfully!");
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Passwords do not match or too short. Try again.");
                    Console.ResetColor();
                }
            }
        }

        public static void SaveProfile(string name, string age, string city)
        {
            string path = "profile.txt";
            string content = $"Icon: {ProfileIcon}\nName: {name}\nAge: {age}\nCity: {city}\nPassword: {UserPassword}";
            File.WriteAllText(path, content);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nProfile saved successfully to profile.txt!");
            Console.ResetColor();
        }

        public static void LoadProfile()
        {
            string path = "profile.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("No saved profile found.");
                return;
            }

            Console.Write("Enter your password to load profile: ");
            string entered = Console.ReadLine();

            string[] lines = File.ReadAllLines(path);
            string savedPass = "";
            foreach (string line in lines)
            {
                if (line.StartsWith("Password:"))
                    savedPass = line.Replace("Password:", "").Trim();
            }

            if (entered == savedPass)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nProfile loaded successfully!");
                foreach (string line in lines)
                    Console.WriteLine(line);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect password. Cannot load profile.");
                Console.ResetColor();
            }
        }
    }
}

