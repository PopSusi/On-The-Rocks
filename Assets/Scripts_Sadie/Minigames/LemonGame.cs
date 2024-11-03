using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonGame : MiniGameBase
{
    [SerializeField] private LemonGuy lemonGuy;

  
    public override void Interaction() 
    {
        lemonGuy.gameObject.SetActive(true);
        lemonGuy.activeLemon = true;
        gameCanvas.gameObject.SetActive(true);
        lemonGuy.countBreaths = 0;
        lemonGuy.countSqueezes = 0;
        lemonGuy.count = 0;
    }
    public override void ConfirmCheck() 
    {
        //StartCoroutine(lemonGuy.WaitToEndTimer());
        lemonGuy.activeLemon = false;
        if (lemonGuy.perfectLemon)
        {
            Debug.Log("Success!");
            //orderManager.playerLiquidIng.Add(DrinkBase.Liquids.LEMONJUICE);
            orderManager.Success();
        }
        else
        {
            Debug.Log("Fail");
            //orderManager.playerLiquidIng.Add(DrinkBase.Liquids.FAIL);
            orderManager.Fail();
        }


        
        //lemonGuy.countBreaths = 0;
        lemonGuy.countSqueezes = 0;
        lemonGuy.count = 0;
        gameCanvas.gameObject.SetActive(false);
        lemonGuy.gameObject.SetActive(false);
        
    }

    
}
