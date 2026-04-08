using System;
using System.Speech.Synthesis;

namespace SecurBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Launching chatbot...");

            PlayVoiceGreeting();
            Visuals.ShowMainBanner();

            RunChatbot();
        }

        static void PlayVoiceGreeting()
        {
            try
            {
                using (SpeechSynthesizer synth = new SpeechSynthesizer())
                {
                    synth.Speak("Welcome to Cyberville, your one stop destination for online safety.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error with text-to-speech: " + ex.Message);
            }
            Console.WriteLine("Voice greeting finished.\n");
        }

        static void RunChatbot()
        {
            bool running = true;

            while (running)
            {
                var profile = Interaction.AskUserInfo();
                Visuals.ShowProfile(profile.name, profile.age, profile.city);

                bool inMenu = true;
                while (inMenu)
                {
                    // Enhanced menu with colored borders
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n================= MAIN MENU =================");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("[1] Learn why staying safe online is important");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("[2] Get another cyber fact");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("[3] Cybersecurity Help Questions");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[4] Save My Profile");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("[5] Load My Profile");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[6] Exit");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("=============================================");
                    Console.ResetColor();

                    string choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        Visuals.ShowSafetyImportance();
                    }
                    else if (choice == "2")
                    {
                        Effects.ShowRandomFactBubble();
                    }
                    else if (choice == "3")
                    {
                        Visuals.ShowHelpQuestions();
                    }
                    else if (choice == "4")
                    {
                        Interaction.SaveProfile(profile.name, profile.age, profile.city);
                    }
                    else if (choice == "5")
                    {
                        Interaction.LoadProfile();
                    }
                    else if (choice == "6")
                    {
                        running = false;
                        inMenu = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Please select 1–6.");
                        Console.ResetColor();
                    }
                }
            }
        }
    }
}
