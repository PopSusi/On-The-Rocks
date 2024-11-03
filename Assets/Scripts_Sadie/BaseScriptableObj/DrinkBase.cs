using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DrinkBase;

//Holds ingredients and names for each drink
[CreateAssetMenu]
public class DrinkBase : ScriptableObject
{
    public enum DrinkName
    {
        DRINK1,
        DRINK2,
        DRINK3
    }

    public IngredientBase[] liquidIngredients;
    public IngredientBase[] accIngredients;
    public DrinkName drinkName;

}
