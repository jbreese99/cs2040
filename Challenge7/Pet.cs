using System.Diagnostics;
using System;
public class Pet
{
    public string type;
    public string name;
    public string owner;
    public double weight;
    
    public Pet(string Type, string Name, string Owner, double Weight) 
    {
        this.type = Type;
        this.name = Name;
        this.owner = Owner;
        this.weight = Weight;
    }


    public string getTag (){
        return "If lost, call " + this.owner + ". ";
    }
}


