using System;

namespace Challenge5
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean valid = false;
            String projName = "";
            String actName = "";
            String final = "";

            while (!valid){
                projName = getProj();
                valid = isValid(projName);
            }

            valid = false;

            while (!valid){
                actName = getAct();
                valid = isValid(actName);
            }
            
            projName = filter(projName);
            actName = filter(actName);
            projName = projName.Replace(" ", "%20");
            actName = actName.Replace(" ", "%20");
            final = "https://companyserver.com/content/" + projName + "/files/" + actName + "/" +actName + "Report.pdf";
            Console.WriteLine("Here is your link \n" + final);
        }

        static String getProj(){
            Console.WriteLine("Enter the project name: ");
            return Console.ReadLine(); 
        }

        static String getAct(){
            Console.WriteLine("Enter the activity name: ");
            return Console.ReadLine();
        }

        static Boolean isValid(String input){
            foreach (char c in input){
                if((((int)c) > 0) && (((int)c) < 32) || (((int)c) == 127)){
                    Console.WriteLine("Invalid Input!");
                    return false;
                }
            }
            return true;
        }

        static String filter(String input){
            int [] badCharacters = new int [] {59, 47, 63, 58, 64, 38, 61, 41, 36, 44, 60, 62, 35, 37, 34, 123, 124, 125, 92, 94, 91, 93, 39};
            foreach (char c in input){
                for (int i = 0; i < badCharacters.Length; i++){
                    if (((int)c) == badCharacters[i]){
                        input = input.Replace(c.ToString(), ("%"+((int)(c)).ToString("X")));
                    }
                }
            }
            return input;
        }
    }
}
