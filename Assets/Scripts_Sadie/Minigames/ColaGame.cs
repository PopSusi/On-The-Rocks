using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColaGame : MiniGameBase
{
    public bool activelyJerking;
    public Vector2 mousePosition;
    public Vector2 mouseTemp;
    public RaycastHit2D hit;
    public bool successfulJerk;
    public int failedJerks;
    public float jerkTimer;

    // Start is called before the first frame update
    void Start()
    {
        Interaction();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        CheckJerking();
        /*if(activelyJerking)
        { 
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(mousePosition.y);
            CheckCollider();
            CheckJerking();
            mouseTemp = mousePosition;
            if (failedJerks > 3)
            {
                successfulJerk = false;
                ConfirmCheck();
            }
        }*/

    }

    public override void Interaction()
    {
        activelyJerking = true;
        //WaitToJerk();
        //Jerker();
        StartCoroutine(WaitToJerk());
        StartCoroutine(WaitForTempJerk());
    }
    public override void ConfirmCheck()
    {
        if (successfulJerk)
        {
            Debug.Log("Success");
        }
        else
        {
            Debug.Log("Fail");
        }
        activelyJerking = false;
        StopAllCoroutines();
    }

    public void CheckCollider()
    {
        //hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (hit.collider != null)
        {

        //Debug.Log(hit.collider.name);
        }
    }

    public void CheckJerking()
    {
        if (mousePosition.y != mouseTemp.y && hit.collider != null)
        {
            successfulJerk = true;
            //ConfirmCheck();
            return;
        }
        else if (mousePosition.y == mouseTemp.y || hit.collider != null)
        {
            successfulJerk = false;
            mouseTemp = mousePosition;
            failedJerks ++;
            StopAllCoroutines();
            
            //WaitToJerk();
            //Jerker();
            if(failedJerks == 3 * 60)
            {
                successfulJerk = false;
                ConfirmCheck();
            }
            else if(failedJerks % 60 == 0)
            {
                StartCoroutine(WaitToJerk());
            }
            
        }
        

    }

    IEnumerator Jerker()
    {
        jerkTimer = Random.Range(5,11);
        Debug.Log("jerk timer = " + jerkTimer);
        yield return new WaitForSeconds(jerkTimer);
        //CheckCollider();

        //CheckJerking();
        ConfirmCheck();
    }

    IEnumerator WaitToJerk()
    {
        Debug.Log("Wait to jerk starts");
        //yield return new WaitForSeconds(10);
        //StartCoroutine(Jerker());
        yield return new WaitForSeconds(2);
        StartCoroutine(Jerker());
        if (activelyJerking)
        {
            //mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(mousePosition.y);
            /*if (failedJerks > 3)
            {
                successfulJerk = false;
                ConfirmCheck();
            }*/
            CheckCollider();

            CheckJerking();

            //mouseTemp = mousePosition;
            mouseTemp = mousePosition;

        }
    }
    IEnumerator WaitForTempJerk()
    {
        yield return new WaitForSeconds(0.5f);
        mouseTemp = mousePosition;
        StartCoroutine(WaitForTempJerk());
    }
}
