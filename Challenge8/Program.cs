using System;
using System.IO;

namespace Challenge8
{
    class Program
    {
        static void Main(string[] args)
        {

        if (args.Length < 3) {
            Console.WriteLine("DocumentMerger2 <input_file_1> <input_file_2> ... <input_file_n> <output_file>");
            Console.WriteLine("Supply a list of text files to merge followed by the name of the resulting merged text file as command line arguments.");
        }
        else{

            String file = args[args.Length-1];

            for(int i = 0; i < args.Length-1; i++){
                combineFiles(args[i], file);
            }

        }  
        }

        static void combineFiles(String first, String saveTo){

             if(File.Exists(first)){
                 try{
                    using (Stream input = File.OpenRead(first))
                    using (Stream output = new FileStream(saveTo, FileMode.Append, FileAccess.Write, FileShare.None)){
                        input.CopyTo(output);
                    }
                 } catch (Exception ex) {
                Console.WriteLine(ex);
                Environment.Exit(0);
            } 
            }
            else{
                 Console.WriteLine("Unable to open file");
            }
        }
    }
}
