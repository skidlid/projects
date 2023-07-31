using System;
using System.IO;

class FileIOExample
{
    static void Main()
    {
        // File Input: Reading data from a file using StreamReader
        string filePath = "input.txt"; // Replace with the path to your input file
        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line); // Display the data read from the file
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file '{0}' could not be found.", filePath);
        }
        catch (IOException ex)
        {
            Console.WriteLine("An error occurred while reading the file: {0}", ex.Message);
        }

        // File Output: Writing data to a file using StreamWriter
        string outputFilePath = "output.txt"; // Replace with the path for your output file
        try
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                string dataToWrite = "Hello, this is some data to be written to the file!";
                writer.WriteLine(dataToWrite); // Writing the data to the file
            }

            Console.WriteLine("Data successfully written to '{0}'.", outputFilePath);
        }
        catch (IOException ex)
        {
            Console.WriteLine("An error occurred while writing to the file: {0}", ex.Message);
        }
    }
}
