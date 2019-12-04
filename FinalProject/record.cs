using System.Diagnostics;
using System;
public class record
{
    public String Name;
    public String Artist;
    public String Album;
    public String Genre;
    public String Size;
    public int Time;
    public int Year;
    public int Plays;

    public static record fromCSV(string csvLine) 
    {
        String[] values = csvLine.Split('\t');
        record newRecord = new record();

        bool result = true;
        
        if(result == true){
            if(values.Length==8){
                newRecord.Name = (values[0]);
                newRecord.Artist = (values[1]);
                newRecord.Album= (values[2]);
                newRecord.Genre = (values[3]);
                newRecord.Size = (values[4]);
                newRecord.Time = Int32.Parse(values[5]);
                newRecord.Year = Int32.Parse(values[6]);
                newRecord.Plays = Int32.Parse(values[7]);
            }
        else{
            Console.WriteLine("Wrong number of elements in csv file");
        }
        }
        else{
            Console.WriteLine("Incorrect data type in csv file");
        }
        return newRecord;
    }

    
}


