using System;
using System.Threading;

namespace SecurBot
{
    class Effects
    {
        public static void Typewriter(string message, int delay = 50)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        static string[] facts = {
            "Did you know? Using a password manager prevents weak password reuse.",
            "Cyber fact: Phishing emails often create urgency to trick you.",
            "Tip: Enable two-factor authentication (2FA) for stronger security.",
            "App to try: Authy or Google Authenticator for login codes.",
            "Fun fact: HTTPS websites encrypt your data — always look for the padlock!"
        };

        public static void ShowRandomFactBubble()
        {
            Random rand = new Random();
            int index = rand.Next(facts.Length);
            string fact = facts[index];

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  .--------------------------------.");
            Console.WriteLine("  | " + fact.PadRight(30) + " |");
            Console.WriteLine("  '--------------------------------'");
            Console.ResetColor();

            Thread.Sleep(2000);

            // Clear bubble after showing
            Console.SetCursorPosition(0, Console.CursorTop - 3);
            for (int i = 0; i < 3; i++)
            {
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop + 1);
            }
        }
    }
}
