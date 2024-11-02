using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class DrinkBase : ScriptableObject
{
    public enum Liquids
    {
        LIQUID1,
        LIQUID2,
        LIQUID3
    }

    public enum Accesories
    {
        ACC1,
        ACC2,
        ACC3
    }

    public Liquids[] liquidIngredients;
    public Accesories[] accIngredients;

}
