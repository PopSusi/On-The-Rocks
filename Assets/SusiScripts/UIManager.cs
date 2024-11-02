using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject openBookGO;
    public GameObject closedBookGO;

    private void Start()
    {
        BookScript.close += CloseBook;
    }

    public void OpenBook()
    {
        closedBookGO.SetActive(false);
        openBookGO.SetActive(true);
        Debug.Log("opening menu");
    }
    public void CloseBook()
    {
        closedBookGO.SetActive(true);
        openBookGO.SetActive(false);
        Debug.Log("closing menu");
    }
    ~UIManager()
    {
        BookScript.close -= CloseBook;
    }
}
