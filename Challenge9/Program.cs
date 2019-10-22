using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;


namespace Challenge9
{
    class Program
    {
        static void Main(string[] args)
        {
        if (args.Length != 3) {
            Console.WriteLine("CrimeAnalyzer.exe <crime_csv_file_path> <report_file_path>");
            Console.WriteLine("ERROR: Follow Above Format...");
        }
        else{

            String csvFile = args[1];
            String reportFile = args[2];
            if(File.Exists(csvFile)){
            List<record> records = File.ReadAllLines(csvFile)
                .Skip(1)
                .Select(v => record.fromCSV(v))
                .ToList();
            

            int minYear = ((records.Aggregate((curMin, x) => (curMin == null || (x.year ) < curMin.year ? x : curMin))).year);
            int maxYear = ((records.Aggregate((curMax, x) => (curMax == null || (x.year ) > curMax.year ? x : curMax))).year);
            int period = (maxYear - minYear);
            var yearsLessFifteenKMurders = from record in records where record.murder < 15000 select record;
            var yearsGreatesFiveHundredKRobberies = from record in records where record.robbery > 500000 select record;
            var violentPerCapitaTwentyTen = from record in records where record.year == 2010 select record;
            var averageMurders = from record in records select record;
            var averageMurdersNinetyFourNinetySeven = from record in records where (record.year >= 1994 && record.year <= 1997) select record;
            var averageMurdersTwentyTenTwentyThirteen = from record in records where (record.year >= 2010 && record.year <= 2013) select record;
            var theftNinetyNineOFour = from record in records where (record.year >= 1999 && record.year <= 2004) select record;
            var minimumTheftNinetyNineOFour = ((theftNinetyNineOFour.Aggregate((curMin, x) => (curMin == null || (x.theft ) < curMin.theft ? x : curMin))).theft);
            var maximumTheftNinetyNineOFour = ((theftNinetyNineOFour.Aggregate((curMax, x) => (curMax == null || (x.theft ) > curMax.theft ? x : curMax))).theft);
            var maxMotorVehicle = ((records.Aggregate((curMax, x) => (curMax == null || (x.motVehTheft ) > curMax.motVehTheft ? x : curMax))));

            if (File.Exists(reportFile)){
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(reportFile, true)){
                    

            file.Write("Years murders per year < 15000: ");
            foreach (var i in yearsLessFifteenKMurders){
                file.Write("{0}, ",i.year);
            }

            file.WriteLine("\n");


            file.Write("Robberies per year > 500000: ");
            foreach (var i in yearsGreatesFiveHundredKRobberies){
                file.Write("{0} = {1}, ", i.year, i.robbery);
            }

            file.WriteLine("\n");

            file.Write("Violent crime per capita rate (2010): ");
            foreach (var i in violentPerCapitaTwentyTen){
                file.WriteLine((double)i.violent/(double)i.population);
            }


            int sumMurders = 0;
            foreach (var i in averageMurders){
                sumMurders += i.murder;
            }
            file.WriteLine("\nAverage murder per year (all years): {0}\n", sumMurders);
            sumMurders = 0;


            foreach (var i in averageMurdersNinetyFourNinetySeven){
                sumMurders += i.murder;
            }
            file.WriteLine("Average murder per year (1994-1997): {0}\n", sumMurders);
            sumMurders = 0;

            
            foreach (var i in averageMurdersNinetyFourNinetySeven){
                sumMurders += i.murder;
            }
            file.WriteLine("Average murder per year (2010-2013): {0}\n", sumMurders);


           file.WriteLine("Minimum thefts per year (1999-2004): {0}\n", minimumTheftNinetyNineOFour);
           file.WriteLine("Minimum thefts per year (1999-2004): {0}\n", maximumTheftNinetyNineOFour);
           file.WriteLine("Year of highest number of motor vehicle thefts: {0}\n", maxMotorVehicle.year);


            
            }
            }
            else{
                Console.WriteLine("Failed to open {0}", reportFile);
            }
            }
            else{
                Console.WriteLine("Failed to open {0}", csvFile);
            }




        }  
        }

    }
}
