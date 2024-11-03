using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColaGame : MiniGameBase
{
    //Sadie does not claim repsonsibility for the names of the variables nor the functions

    public bool activelyJerking;
    public Vector2 mousePosition;
    public Vector2 mouseTemp;
    public RaycastHit2D hit;
    public bool successfulJerk;
    public int failedJerks;
    public float jerkTimer;
    [SerializeField] private GameObject colaBottle;

    

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.Raycast(mousePosition, Vector2.zero);
   

    }

    public override void Interaction()
    {
        activelyJerking = true;
        gameCanvas.gameObject.SetActive(true);
        colaBottle.SetActive(true);

        StartCoroutine(WaitToJerk());
    }
    public override void ConfirmCheck()
    {
        if (successfulJerk)
        {
            Debug.Log("Success");
            orderManager.playerLiquidIng.Add(DrinkBase.Liquids.COLA);
        }
        else
        {
            Debug.Log("Fail");
            orderManager.playerLiquidIng.Add(DrinkBase.Liquids.FAIL);
        }
        activelyJerking = false;
        gameCanvas.gameObject.SetActive(false);
        colaBottle.SetActive(false);
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
        if (mousePosition.y != mouseTemp.y && hit.collider != null) //If mouse moved and is over the cola bottle
        {
            successfulJerk = true;

            return;
        }
        else if (mousePosition.y == mouseTemp.y || hit.collider == null) //if mouse is in the same position or is not over the bottle
        {

            
            successfulJerk = false;
            failedJerks++;
            StopAllCoroutines();


            if (failedJerks == 3 * 60)
            {
                successfulJerk = false;
                ConfirmCheck();
            }
            else if (failedJerks % 60 == 0)
            {
                StartCoroutine(WaitToJerk());
            }

        }


    }

    IEnumerator Jerker()
    {
        Debug.Log("jerk timer = " + jerkTimer);
        StartCoroutine(WaitForTempJerk());
        yield return new WaitForSeconds(jerkTimer);


        CheckJerking();
        ConfirmCheck();
    }

    IEnumerator WaitToJerk()
    {
        Debug.Log("Wait to jerk starts");

        yield return new WaitForSeconds(2);
        jerkTimer = Random.Range(5, 11);
        StartCoroutine(Jerker());
        if (activelyJerking)
        {
            
        CheckCollider();



        mouseTemp = mousePosition;

        }
    }
    IEnumerator WaitForTempJerk()
    {
        yield return new WaitForSeconds(0.5f);
        if (activelyJerking)
        {

            mouseTemp = mousePosition;
            StartCoroutine(WaitForTempJerk());
        }
    }
}
