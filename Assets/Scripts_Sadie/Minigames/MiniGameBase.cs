using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MiniGameBase : MonoBehaviour
{

    //Interaction num/times
    //Ice: 10
    //Cola:5
    //Lemon: 2-4, 4-8
    // Cherry:7



    public enum Type
    {
        ICE,
        CHERRIES,
        COLA,
        LEMON,
        OLIVES,
        PIKMIN,
    }

    private void Start() => Page.Send += LaunchGame;

    public Type gameType;

    public Sprite baseSprite;
    public Sprite interactionSprites;
    public Sprite handSprite;
    public Sprite interactionHands;
    public bool useHands;

    public GameObject baseObj;
    public GameObject hands;

    public int interactionCount;
    [SerializeField] protected OrderManager orderManager;
    [SerializeField] protected Canvas gameCanvas; //game's UI
    public virtual void Interaction() { } //When player loads minigame
    public virtual void ConfirmCheck() { } //Check at end of game
    public void LaunchGame(string game)
    {
        if(game == gameType.ToString())
        {
            Interaction();
        }
    }
    ~MiniGameBase() { 
        Page.Send -= LaunchGame;
    }

}
