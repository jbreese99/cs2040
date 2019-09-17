using System;

namespace Challenge6
{
    class Program
    {
        static void Main(string[] args)
        {
            String firstFile = "";
            String secondFile = "";
            String file = "";
            Boolean repeat = true;

            while (repeat){
                Console.WriteLine("Document Merger\n");

                Console.WriteLine("Enter the name of the first document: ");
                firstFile = verifyDocument(Console.ReadLine());

                Console.WriteLine("Enter the name of the second document: ");
                secondFile = (verifyDocument(Console.ReadLine()));

                file = combineFileNames(firstFile, secondFile);
                combineFiles(firstFile, secondFile, file);

                Console.WriteLine("Would you like to merge two more files (y/n)?");
                if (Console.ReadLine() == "n")
                    repeat = false;
                Console.WriteLine("\n\n\n");
            }
        }

        static String verifyDocument(String docName){
            Boolean isValid = false;
            isValid = System.IO.File.Exists(docName);
            while (isValid == false){
                Console.WriteLine("File does not exist, try again: ");
                docName = Console.ReadLine();
                isValid = System.IO.File.Exists(docName);
            }
            return removeExtension(docName);
        }

        static String removeExtension(String docName){
            return (docName.Substring(0, docName.IndexOf((char)46)));
        }

        static String combineFileNames(String first, String second){
            return first + second + ".txt";
        }

        static void combineFiles(String first, String second, String output){
            int numberOfCharacters = 0;
            try{
                System.IO.File.WriteAllText(output, System.IO.File.ReadAllText(first + ".txt") + System.IO.File.ReadAllText(second + ".txt"));
            } catch (Exception ex) {
                Console.WriteLine(ex);
                Environment.Exit(0);
            } 
            foreach (char c in output)
                numberOfCharacters++;
            Console.WriteLine (output + " was successfully saved. The document contains " + numberOfCharacters + " characters.");
        }
    }
}
