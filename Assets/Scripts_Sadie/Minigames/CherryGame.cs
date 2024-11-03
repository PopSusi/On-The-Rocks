using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryGame : MiniGameBase
{
    
    [SerializeField] private CherryGuy cherryGuy;

    public override void Interaction() 
    {
        interactionCount = Random.Range(5, 10);
        gameCanvas.gameObject.SetActive(true);
        cherryGuy.gameObject.SetActive(true);
        cherryGuy.cherryActive = true;
        
    }

    public override void ConfirmCheck()
    {
        //Runs on spacebar
        if(cherryGuy.secondsHeld == interactionCount)
        {
            Debug.Log("Success!");
            orderManager.playerAccIng.Add(DrinkBase.Accesories.CHERRY);
        }
        else
        {
            Debug.Log("Fail");
            orderManager.playerAccIng.Add(DrinkBase.Accesories.FAIL);
        }

        gameCanvas.gameObject.SetActive(false);
        cherryGuy.gameObject.SetActive(false);
        cherryGuy.cherryActive = false;
    }

   

}
