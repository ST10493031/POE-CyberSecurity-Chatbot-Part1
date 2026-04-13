
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Media;
namespace ai_chatbot
{//start of namespace
    public class voice_logo
    {//start of class

        //auto get the path directory
        private string full_path = AppDomain.CurrentDomain.BaseDirectory;


        public voice_logo()
        {//start of constuctor 

            // calling sound method
            greeting();

            // calling the asci method to display the logo in the console
            //asci();

        }//end of constructor

        //methond to play sound
        private void greeting()
        { //start of method
            //checking if the patg is auto collected
            Console.WriteLine(full_path);

            //replace the \bin\Debug
            string correct_path = full_path.Replace(@"\bin\Debug\", @"\greet.wav");

            //checking if audio found
            Console.WriteLine(correct_path);

            //use the sound player class to play the auido
            //creating an instance for the soundplay class
            //with an object name greet

            SoundPlayer greeting = new SoundPlayer(correct_path);
            //then play the sound using the play method
            greeting.Play();



        }



       
        }
    }

            
            
    
            
        
    



    

    
   
