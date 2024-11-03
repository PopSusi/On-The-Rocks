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
        }
        else
        {
            Debug.Log("Fail");
        }
        activeIce = false;
    }

    public void StartIce()
    {
        activeIce = true;
        iceTarget = Random.Range(10, 31);
        Debug.Log(iceTarget);
        iceCount = 0;
    }

    public void OnMouseDown()
    {
        Debug.Log("RAH");
        if (activeIce)
        {
            iceCount++;
            Debug.Log(iceCount);
            checkIce();
        }
        
    }

    public void checkIce()
    {
        if (iceCount == iceTarget)
        {
            perfectIce = true;
            StartCoroutine(waiter());
            

        }
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(3);
        if (iceCount != iceTarget)
        {
            perfectIce = false;
        }
        ConfirmCheck();
    }

    }
