using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IceGame : MiniGameBase
{
    public bool perfectIce;
    public float iceTarget;
    public float iceCount;
    public bool activeIce;

    public void Start()
    {
        //Interaction();
    }

    public override void Interaction()
    {
        StartIce();

    }

    public override void ConfirmCheck()
    {
        if (perfectIce)
        {
            Debug.Log("Success!");
            //orderManager.playerAccIng.Add(DrinkBase.Accesories.ICE);
            orderManager.Success();
        }
        else
        {
            Debug.Log("Fail");
            //orderManager.playerAccIng.Add(DrinkBase.Accesories.FAIL);
            orderManager.Fail();
        }

        gameCanvas.gameObject.SetActive(false);
        activeIce = false;
    }

    public void StartIce()
    {
        activeIce = true;
        iceTarget = Random.Range(10, 31);
        Debug.Log("ice target = " + iceTarget);
        iceCount = 0;
        interactionCount = 0;

        gameCanvas.gameObject.SetActive(true);
    }

    public void OnMouseDown()
    {
        
        if (activeIce)
        {
            interactionCount++;
            Debug.Log(interactionCount);
            checkIce();
        }
        
    }

    public void checkIce()
    {
        if (interactionCount == iceTarget)
        {
            perfectIce = true;
            StartCoroutine(waiter());
            

        }
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(3);
        if (interactionCount != iceTarget)
        {
            perfectIce = false;
        }
        ConfirmCheck();
    }

    }
