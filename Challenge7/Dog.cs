using System.Diagnostics;
using System;


public class Dog : Pet{
    public Dog(String Name, String Owner, double Weight) : base ("Dog", Name, Owner, Weight) {
    }

    public String bark(int numberOfBarks){
        String barks = new String ("");
        for (int j = 0; j < numberOfBarks; j++)
           barks = barks + "bark!";
        return barks;
    }

}

