using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonGame : MiniGameBase
{
    int elapsed;
    int temp;
    int count;
    bool isSqueezed;
    bool perfectLemon;
    bool activeLemon;
    // Start is called before the first frame update
    void Start()
    {
        Interaction();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public override void Interaction() 
    {
        activeLemon = true;
    }
    public override void ConfirmCheck() 
    {

        activeLemon = false;
        if (perfectLemon)
        {
            Debug.Log("Success!");
        }
        else
        {
            Debug.Log("Fail");
        }
    }

    public void OnMouseDown()
    {
        StopAllCoroutines();
        BreatheLemon();
        elapsed = 0;
        StartCoroutine(TimerStart());
    }

    public void OnMouseUp()
    {
        StopAllCoroutines();
        SqueezeLemon();
        elapsed = 0;
        StartCoroutine(TimerStart());
    }

    private IEnumerator TimerStart()
    {
        Debug.Log("time:" + elapsed);
        yield return new WaitForSeconds(1);
        elapsed++;

        StartCoroutine(TimerStart());
    }

    

    public void SqueezeLemon()
    {
        if (2 <= elapsed && elapsed <= 4)
        {
            perfectLemon = true;
            count++;
        }
        else
        {
            perfectLemon = false ;
            ConfirmCheck();
        }
    }

    public void BreatheLemon()
    {
        if(4 <= elapsed && elapsed <= 8)
        {
            perfectLemon = true;
        }
        else
        {
            perfectLemon = false;
            ConfirmCheck();
        }
    }
}
