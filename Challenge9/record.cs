using System.Diagnostics;
using System;
public class record
{
    public int year;
    public int population;
    public int violent;
    public int murder;
    public int rape;
    public int robbery;
    public int aggAssault;
    public int propCrime;
    public int burglary;
    public int theft;
    public int motVehTheft;

    public static record fromCSV(string csvLine) 
    {
        String[] values = csvLine.Split(',');
        record newRecord = new record();

        bool result = true;
        foreach (String i in values){
            if (Int32.TryParse(i, out int output) == false)
                result = false;
        }

        if(result == true){
            if(values.Length==11){
                newRecord.year = Int32.Parse(values[0]);
                newRecord.population = Int32.Parse(values[1]);
                newRecord.violent= Int32.Parse(values[2]);
                newRecord.murder = Int32.Parse(values[3]);
                newRecord.rape = Int32.Parse(values[4]);
                newRecord.robbery = Int32.Parse(values[5]);
                newRecord.aggAssault = Int32.Parse(values[6]);
                newRecord.propCrime = Int32.Parse(values[7]);
                newRecord.burglary = Int32.Parse(values[8]);
                newRecord.theft = Int32.Parse(values[9]);
                newRecord.motVehTheft = Int32.Parse(values[10]);
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


