using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Data for customer
[CreateAssetMenu]
public class CustomerBase : ScriptableObject
{
    public DrinkBase drinkBase; //Drink customer orders
    public Sprite characterSprite; //Default sprite for character
    public Sprite characterAngrySprite; //Angry sprite for character
    public VoicePitch pitch;
}

public enum VoicePitch
{
    Low,
    Med,
    High
}
