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
            Console.WriteLine("MusicPlaylistAnalyzer <music_playlist_file_path> <report_file_path>");
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
            
            var songsOverTwoHundredPlays = from record in records where record.Plays > 200 select record;
            var alternativeSongs = from record in records where record.Genre == "Alternative" select record;
            var hipHopRap = from record in records where record.Genre == "Hip-Hop/Rap" select record;
            var welcomeToTheFishbowl = from record in records where record.Album == "Welcome to the Fishbowl" select record;
            var beforeSeventy = from record in records where record.Year <1970 select record;
            var longerThanEightyFive = from record in records where record.Name.Length > 85 select record;
            var songLongestTime = from record in records where record.Time == (from re in records select re.Time).Max() select record;

            if (File.Exists(reportFile)){
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(reportFile, true)){
                    

            file.Write("Songs with over 200 plays: \n");

            foreach (var i in songsOverTwoHundredPlays){
                file.Write("Name: {0}, Artist: {1}, Album: {2}, Genre: {3}, Size: {4}, Time: {5}, Year: {6}, Plays: {7}\n",i.Name, i.Artist, i.Album, i.Genre, i.Size, i.Time, i.Year, i.Plays);
            }


            int numberAlternative = 0;
            foreach (var i in alternativeSongs){
                numberAlternative++;
            }
            file.WriteLine("\nNumber of alternative songs: {0}\n", numberAlternative);

            int  numberHipHopRap = 0;
            foreach (var i in hipHopRap){
                numberHipHopRap++;
            }
            file.WriteLine("Number of Hip-Hop/Rap songs: {0}\n", numberHipHopRap);
 

            file.Write("Songs in Welcome to the Fishbowl: \n");

            foreach (var i in welcomeToTheFishbowl){
                file.Write("Name: {0}, Artist: {1}, Album: {2}, Genre: {3}, Size: {4}, Time: {5}, Year: {6}, Plays: {7}\n\n",i.Name, i.Artist, i.Album, i.Genre, i.Size, i.Time, i.Year, i.Plays);
            }

            file.Write("Songs before 1970: \n");

            foreach (var i in beforeSeventy){
                file.Write("Name: {0}, Artist: {1}, Album: {2}, Genre: {3}, Size: {4}, Time: {5}, Year: {6}, Plays: {7}\n",i.Name, i.Artist, i.Album, i.Genre, i.Size, i.Time, i.Year, i.Plays);
            }

            file.Write("\nSongs Titles Longer Than 85 Characters: \n");
            
            foreach (var i in longerThanEightyFive){
                file.Write("Name: {0}", i.Name);
            }

            foreach (var i in songLongestTime){
                file.Write("\n\nLongest Song: \nName: {0}, Artist: {1}, Album: {2}, Genre: {3}, Size: {4}, Time: {5}, Year: {6}, Plays: {7}\n",i.Name, i.Artist, i.Album, i.Genre, i.Size, i.Time, i.Year, i.Plays);
            }
            
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
