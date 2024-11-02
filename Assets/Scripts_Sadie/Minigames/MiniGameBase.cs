using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MiniGameBase : MonoBehaviour
{
    public enum Type
    {
        ICE,
        CHERRIES,
        COLA,
        LEMON,
        OLIVES,
        PIKMIN

    }

    public Type gameType;
    public Sprite baseSprite;
    public Sprite[] interactionSprites;
    public GameObject baseObj;
    public int interactionCount;

    public virtual void Interaction() { }
    public virtual void ConfirmCheck() { }

}
