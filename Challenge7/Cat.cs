using System.Diagnostics;
using System;

public class Cat : Pet{
    public Cat(String Name, String Owner, double Weight) : base ("Cat", Name, Owner, Weight) {
    }

    public String meow(int numberOfMeows){
        String meows = new String ("");
        for (int j = 0; j < numberOfMeows; j++)
           meows = meows + "meow.";
        return meows;
    }

}