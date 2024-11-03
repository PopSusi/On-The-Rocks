using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikminCollision : MonoBehaviour
{
    public PikminGame pikminGame;

    private void Start()
    {
        pikminGame = FindObjectOfType<PikminGame>();
    }

    public void PassToGame()
    {
        pikminGame.CutPickmin();
        if(pikminGame.holdScissor)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
