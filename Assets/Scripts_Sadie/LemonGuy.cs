using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonGuy : MonoBehaviour
{

    public int elapsed;
    public int temp;
    public int count;
    public bool isSqueezed;
    public bool perfectLemon;
    public bool activeLemon;

    public int countSqueezes;
    public int countBreaths;

    [SerializeField] private LemonGame lemonGame;



    public void OnMouseDown()
    {
        if (activeLemon)
        {
            StopAllCoroutines();
            if (countBreaths > 0)
            {
                BreatheLemon(); //Checks if previeos breathed long enough
            }

            elapsed = 0;
            isSqueezed = true;
            countSqueezes++;
            StartCoroutine(TimerStart()); //Start squeezing
        }

    }

    public void OnMouseUp()
    {
        if (activeLemon)
        {
            StopAllCoroutines();

            if (countSqueezes > 0)
            {
                SqueezeLemon(); //Checks if previous was squeezed long enough
            }

            isSqueezed = false;
            elapsed = 0;
            countBreaths++;
            StartCoroutine(TimerStart()); //Start breathing
        }


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
        Debug.Log("Squeeze Elapsed = " + elapsed);
        if (2 <= elapsed && elapsed <= 4)
        {
            Debug.Log("Pass round");
            perfectLemon = true;
            count++;

            if (count == lemonGame.interactionCount)
            {
                countBreaths = 0;
                lemonGame.ConfirmCheck();
            }
        }
        else
        {
            perfectLemon = false;
            lemonGame.ConfirmCheck();
        }
    }

    public void BreatheLemon()
    {
        Debug.Log("Breathe Elapsed = " + elapsed);
        if (4 <= elapsed && elapsed <= 8)
        {
            Debug.Log("Pass round");
            perfectLemon = true;
        }
        else
        {
            perfectLemon = false;
            lemonGame.ConfirmCheck();
        }
    }

    /// <summary>
    /// Forces ConfirmCheck to wait to stop all coroutines for input to stop
    /// </summary>
    public IEnumerator WaitToEndTimer()
    {
        yield return new WaitForSeconds(1);
        StopAllCoroutines();
    } //END WaitToEndTimer()
}
