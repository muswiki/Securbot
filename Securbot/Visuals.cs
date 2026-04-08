using System;

namespace SecurBot
{
    class Visuals
    {
        public static void ShowMainBanner()
        {
            string title = "Welcome to Cyberville";
            int width = 60;
            int padding = (width - title.Length) / 2;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(new string('=', width));
            Console.WriteLine("|" + new string(' ', padding) + title + new string(' ', width - title.Length - padding - 2) + "|");
            Console.WriteLine(new string('=', width));
            Console.ResetColor();
        }

        public static void ShowProfile(string name, string age, string city)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n================= PROFILE =================");
            Console.WriteLine($" Name : {name}");
            Console.WriteLine($" Age  : {age}");
            Console.WriteLine($" City : {city}");
            Console.WriteLine("===========================================");
            Console.ResetColor();
        }

        public static void ShowSafetyImportance()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n================ INTERNET SAFETY ================");
            Console.WriteLine("Why is it important to stay safe online?");
            Console.WriteLine("- Cybercrime costs the world trillions annually.");
            Console.WriteLine("- Phishing scams target millions of users daily.");
            Console.WriteLine("- Identity theft can damage finances and reputation.");
            Console.WriteLine("- Safe practices protect privacy, security, and wellbeing.");
            Console.WriteLine("=================================================");
            Console.ResetColor();
        }

        internal static void ShowHelpQuestions()
        {
            throw new NotImplementedException();
        }
    }
}
