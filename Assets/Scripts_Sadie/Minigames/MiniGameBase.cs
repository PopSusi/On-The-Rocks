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
        PIKMIN,

    }

    public Type gameType;
    public Sprite baseSprite;
    public Sprite[] interactionSprites;
    public GameObject baseObj;
    public int interactionCount;
    [SerializeField] protected OrderManager orderManager;
    [SerializeField] protected Canvas gameCanvas; //game's UI

    public virtual void Interaction() { } //When player loads minigame
    public virtual void ConfirmCheck() { } //Check at end of game

}
