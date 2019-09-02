using System;

namespace Challenge3
{
    class Program
    {
        static void Main(string[] args)
        {
            String docName;
            String contents;

            Console.WriteLine("Document \n");

            Console.WriteLine("Enter the name of the document here:\n");
            docName = Console.ReadLine() + ".txt";

            Console.WriteLine("Enter the contents of the documet here: \n");
            contents =Console.ReadLine();

            System.IO.File.WriteAllText(docName, contents);

            try {
                System.IO.File.WriteAllText(docName, contents);
            } catch (Exception ex) {
                Console.WriteLine(ex);
            } 

             Console.WriteLine(docName + " was successfully saved The document contains " + contents.Length + " characters" );
        }
    }
}
