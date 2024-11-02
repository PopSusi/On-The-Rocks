using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[CreateAssetMenu]
public class IngredientBase : ScriptableObject
{
    public AudioClip orderSFX;
    public TextMeshProUGUI bookText;
    public Sprite bookSprite;
    public MiniGameBase.Type type;
}
