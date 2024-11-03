using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Holds ingredients and names for each drink
[CreateAssetMenu]
public class DrinkBase : ScriptableObject
{
    //Liquid ingredients
    public enum Liquids 
    {
        COLA,
        LEMONJUICE,
        FAIL
        
    }

    //Non-Liquid ingredients
    public enum Accesories
    {
        CHERRY,
        ICE,
        OLIVE,
        PIKMIN,
        FAIL
    }

    public enum DrinkName
    {
        DRINK1,
        DRINK2,
        DRINK3
    }

    public Liquids[] liquidIngredients;
    public Accesories[] accIngredients;
    public DrinkName drinkName;

}
