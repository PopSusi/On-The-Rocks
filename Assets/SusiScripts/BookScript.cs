using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookScript : MonoBehaviour
{
    public delegate void BookEvent();
    public static event BookEvent close;

    public static int pageLeft = 0;
    public PageBase[] pages; //Convert to Page ScriptableObject
    public GameObject leftPage;
    public GameObject rightPage;

    private void Start()
    {
        pages = Resources.LoadAll<PageBase>("Pages");
        SendValues();
    }
    public void LeftTurn()
    {
        if (pageLeft != 0) // if isn't first page
        {
            //Vector3 temp = leftPage.transform.position; //save left
            //leftPage.transform.position = rightPage.transform.position; //move left to right
            //rightPage.transform.position = temp; //change right to left
            pageLeft--; //update counter
            SendValues();
        }
        Debug.Log(pageLeft);
    }
    public void RightTurn()
    {
        if (pageLeft + 1 < pages.Length)//pages.Length)
        {
            //Vector3 temp = rightPage.transform.position; //save left
            //rightPage.transform.position = leftPage.transform.position; //move left to right
            //leftPage.transform.position = temp; //change right to left
            pageLeft++; //update counter
            SendValues();
        }
        Debug.Log(pageLeft);
    }
    private void SendValues()
    {
        leftPage.GetComponent<Page>().SetValues(pages[pageLeft]); //edit text
        rightPage.GetComponent<Page>().SetValues(pages[pageLeft + 1]); //edit text
    }

    public void CloseBook()
    {
        close();
    }
}
