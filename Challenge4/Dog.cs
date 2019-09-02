using System.Diagnostics;
using System;
public class Dog
{
    public string name;
    public string owner;
    public int age;
    private string tagInfo;
    public Gender gender;
    public Dog(string Name, string Owner, int Age, Gender Gen) 
    {
        this.name = Name;
        this.owner = Owner;
        this.age = Age;
        this.gender = Gen;   
    }

    public void Bark(int numberOfBarks){
        for (int j = 0; j < numberOfBarks; j++)
            Console.WriteLine("Woof!");
    }

    public string GetTag (){
        tagInfo = tagInfo + "If lost, call " + this.owner + ". ";

        if (this.gender == Gender.Male)
        tagInfo = tagInfo + "His ";
        else 
        tagInfo = tagInfo + "Her ";

        tagInfo = tagInfo + "name is " + this.name + " and ";
         
        if (this.gender == Gender.Male)
        tagInfo = tagInfo + "He ";
        else 
        tagInfo = tagInfo + "She ";
        tagInfo = tagInfo + "is " + this.age;
        
        if (this.age == 1)
        tagInfo = tagInfo + " year old.";
        else
        tagInfo = tagInfo + " years old.";

        return tagInfo;    
    }
}


