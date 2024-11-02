using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookScript : MonoBehaviour
{
    public delegate void BookEvent();
    public static event BookEvent close;

    static int pageLeft = 0;
    public GameObject[] pages; //Convert to Page ScriptableObject
    public GameObject leftPage;
    public GameObject rightPage;

    public void LeftTurn()
    {
        if (pageLeft != 0) // if isn't first page
        {
            Vector3 temp = leftPage.transform.position; //save left
            leftPage.transform.position = rightPage.transform.position; //move left to right
            rightPage.transform.position = temp; //change right to left
            //rightPage.GetComponent<Page>().SetValues(); //edit text
            pageLeft--; //update counter
        }
    }
    public void RightTurn()
    {
        if (pageLeft + 1 < 5)//pages.Length)
        {
            Vector3 temp = rightPage.transform.position; //save left
            rightPage.transform.position = leftPage.transform.position; //move left to right
            leftPage.transform.position = temp; //change right to left
            //leftPage.GetComponent<Page>().SetValues(); //edit text
            pageLeft++; //update counter
        }
    }
    public void CloseBook()
    {
        close();
    }
}
