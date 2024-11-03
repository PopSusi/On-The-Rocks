using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CherryGuy : MonoBehaviour
{
    public bool cherryActive;
    public int secondsHeld;
    [SerializeField] private CherryGame cherryGame;



    private void OnMouseDown()
    {
        StartCoroutine(RunTimer());
        GetComponent<SpriteRenderer>().sprite = cherryGame.interactionSprites;
    }

    private void OnMouseUp()
    {
        StopAllCoroutines();
        //Temp
        cherryGame.ConfirmCheck();
        GetComponent<SpriteRenderer>().sprite = cherryGame.baseSprite;
    }


    private IEnumerator RunTimer()
    {
        Debug.Log("Run timer");
        yield return new WaitForSeconds(1);
        secondsHeld++;


        StartCoroutine(RunTimer());
    }



}
