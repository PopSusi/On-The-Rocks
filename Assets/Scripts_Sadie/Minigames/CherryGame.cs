using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryGame : MiniGameBase
{
    
    [SerializeField] private CherryGuy cherryGuy;

    public override void Interaction() 
    {
        interactionCount = 7;
        gameCanvas.gameObject.SetActive(true);
        cherryGuy.gameObject.SetActive(true);
        cherryGuy.GetComponent<SpriteRenderer>().sprite = baseSprite;
        cherryGuy.cherryActive = true;
        
    }

    public override void ConfirmCheck()
    {
        
        //Runs on spacebar
        if(cherryGuy.secondsHeld == interactionCount)
        {
            Debug.Log("Success!");
            //orderManager.playerAccIng.Add(DrinkBase.Accesories.CHERRY);
            orderManager.Success();
            StartCoroutine(FadeOut());
        }
        else
        {
            Debug.Log("Fail");
            //orderManager.playerAccIng.Add(DrinkBase.Accesories.FAIL);
            orderManager.Fail();
            StartCoroutine(FadeOut());

        }

        
    }

   private IEnumerator FadeOut()
    {
        Debug.Log("Fade out start");
        yield return new WaitForSeconds(1);
        gameCanvas.gameObject.SetActive(false);
        cherryGuy.gameObject.SetActive(false);
        cherryGuy.cherryActive = false;
    }

}
