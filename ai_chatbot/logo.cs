using System;
using System.Drawing;
using System.IO;

namespace ai_chatbot
{
    public class logo
    {
        public logo()
        {
            //start of constructor
            string path_project = AppDomain.CurrentDomain.BaseDirectory;
            string new_path_project = path_project.Replace("bin\\Debug\\", "");

            //combine the project full path and the image name
            string full_path = Path.Combine(new_path_project, "mylogo.jpeg");


            //logo with ASCII
            Bitmap image = new Bitmap(full_path);
            image = new Bitmap(image, new Size(210, 200));

            //for loop(inner and outer)
            for (int height = 0; height < image.Height; height++)
            {
                for (int width = 0; width < image.Width; width++)
                {
                    //now lets work on the asci design
                    Color pixelColor = image.GetPixel(width, height);
                    int color = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                    char ascii_design = color > 200 ? '.' : color > 150 ? '*' : color > 100 ? '0' : color > 50 ? '#' : '@';
                    //Display
                    Console.Write(ascii_design);
                }//end of inner loop
                Console.WriteLine();
            }//end of outer loop
        }//end of constructor


    }
    }
