

using System;
using System.Collections.Generic;

namespace ai_chatbot
{//start of namespace


    public class prompt_user : voice_logo
    {//start of class

        //declare a variable for user_name
        private string user_name;

                    // Dictionary to store cybersecurity knowledge
        private Dictionary<string, List<string>> knowledgeBase;


        public prompt_user()
        {//start of constructor

            // Initialize the knowledge base
            InitializeKnowledgeBase();


            //calling the welcome message method
            welcome_message();

            //calling the get_user_name method
            get_user_name();

            //  Calling the method to ask cybersecurity questions
            AskCybersecurityQuestion();


        }//end of constructor

        //method for getting user_name

        private void welcome_message()
        {//start of welcome meassage method

            Console.WriteLine();
            //set the color for the welcome message to make it more interactive
            Console.ForegroundColor = ConsoleColor.Blue;
            //welcome message
            Console.WriteLine("==========================================================");
            Console.WriteLine("||        WELCOME TO THE CYBERSECURITY CHATBOT!!        ||");
            Console.WriteLine("==========================================================");



        }//end of welcome message method
        private void get_user_name()
        {
            //cerating color for the chatbot message to make it more interactive
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("ChatBot :-> ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Please enter your name:");
           

            //create color for the user input to make it more interactive
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("User :-> ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            user_name = Console.ReadLine();
           
            //check if usert_name is empty
            if (string.IsNullOrWhiteSpace(user_name))
            {
                //make the warning message red to show that it is an error
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ChatBot :-> Please enter a valid name.");
                get_user_name(); // Recursively call until a valid name is entered
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"ChatBot :->");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($" Hi, {user_name}! Welcome to the cybersecurity chatbot!!");
                
                 Console.ForegroundColor = ConsoleColor.White;
                Console.Write("ChatBot :->");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(" How can I assist you today?");
            }
        }
        // Method to initialize the cybersecurity knowledge base
        private void InitializeKnowledgeBase()
        {//start of method
            knowledgeBase = new Dictionary<string, List<string>>
            {
                {"password", new List<string>{
                    "STRONG PASSWORDS: ",
                    "• Use 12+ characters",
                    "• Mix UPPER/lowercase, numbers, symbols",
                    "• Never reuse passwords",
                    "• Use password manager (LastPass, Bitwarden)",
                    "BAD: 123456, password",
                    "GOOD: Tr0ub4dor&3Rex!"
                }},
                {"phishing", new List<string>{
                    "PHISHING ATTACKS:",
                    "• NEVER click links in suspicious emails",
                    "• Check sender email address carefully",
                    "• Hover over links (don't click) to see URL",
                    "• Banks NEVER ask for passwords by email",
                    "• 'Urgent' + 'Click here' = SCAM!",
                    "Verify by calling official number"
                }},
                {"2fa", new List<string>{
                    "TWO-FACTOR AUTHENTICATION:",
                    "• Enable everywhere (Google, email, bank)",
                    "• SMS is OK, but app-based (Google Auth) better",
                    "• Hardware keys (YubiKey) = BEST",
                    "• Even if password stolen, hacker needs 2nd factor"
                }},
                {"help", new List<string>{
                    "AVAILABLE TOPICS:",
                    "• password - Strong password tips",
                    "• phishing - Spot phishing emails",
                    "• 2fa - Two-factor authentication",
                    "• quit - Exit chatbot"
                }}
            };
        }//end of method

        // Method to handle cybersecurity questions
        private void AskCybersecurityQuestion()
        {//start of method 
            while (true)

            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("User :-> ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                string userInput = Console.ReadLine()?.ToLower().Trim();

                if (userInput == "quit" || userInput == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("ChatBot :-> Stay safe online!");
                    break;
                }

                if (userInput == "help")
                {
                    ShowTopic("help");
                }
                else
                {
                    string response = GenerateResponse(userInput);
                    if (response != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("ChatBot :->");
                        Console.ResetColor();
                        Console.WriteLine(response);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ChatBot :-> Not sure about that. Type 'help' for topics!");
                        Console.ResetColor();
                    }
                }
            }
        }//end of method 

        // Method to generate a response based on user input
        private string GenerateResponse(string userInput)
        {
            // Check for keywords in user input
            foreach (var topic in knowledgeBase)
            {
                if (userInput.Contains(topic.Key))
                {
                    return string.Join(" ", knowledgeBase[topic.Key]);
                }
            }

            // Handle specific questions
            if (userInput.Contains("how") && userInput.Contains("password"))
            {
                return string.Join(" ", knowledgeBase["password"]);
            }
            if (userInput.Contains("what") && userInput.Contains("phishing"))
            {
                return string.Join(" ", knowledgeBase["phishing"]);
            }
            if (userInput.Contains("why") && userInput.Contains("2fa"))
            {
                return string.Join(" ", knowledgeBase["2fa"]);
            }

            // Default response
            return null;
        }

        // Method to show a topic from the knowledge base
        private void ShowTopic(string topic)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("ChatBot :->");
            Console.ResetColor();

            foreach (string line in knowledgeBase[topic])
            {
                Console.WriteLine("   " + line);
            }
        }




    }//end of class



}//end of namespace