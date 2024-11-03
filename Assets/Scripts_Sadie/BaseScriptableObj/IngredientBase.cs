using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[CreateAssetMenu]
public class IngredientBase : ScriptableObject
{
    public AudioClip orderLowSFX;
    public AudioClip orderMedSFX;
    public AudioClip orderHighSFX;
    public string bookText;
    public Sprite bookSprite;
    public MiniGameBase.Type type;
}
