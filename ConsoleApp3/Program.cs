using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the folder path where the images are located:");
            string folderPath = Console.ReadLine();

            if (Directory.Exists(folderPath))
            {
                string[] imageFiles = Directory.GetFiles(folderPath);
                foreach (var imageFile in imageFiles)
                {
                    try
                    {
                        // Load the image
                        using (Image image = Image.FromFile(imageFile))
                        {
                            // Convert the file name to a PNG file
                            string pngFileName = Path.ChangeExtension(imageFile, ".png");

                            // Save the image as PNG format
                            image.Save(pngFileName, ImageFormat.Png);

                            Console.WriteLine($"Converted: {imageFile} -> {pngFileName}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error converting {imageFile}: {ex.Message}");
                    }
                }
            }
            else
            {
                Console.WriteLine("The specified folder does not exist.");
            }

            Console.WriteLine("Conversion complete.");
        }
    }
}
