using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class MiniGameBase : ScriptableObject
{
    public enum Type
    {
        TYPE1,
        TYPE2,
        TYPE3
    }

    public Type gameType;
    public Sprite baseSprite;
    public Sprite[] interactionSprites;
    public GameObject baseObj;
    public int interactionCount;

    public virtual void Interaction() { }
    public virtual void ConfirmCheck() { }
}
