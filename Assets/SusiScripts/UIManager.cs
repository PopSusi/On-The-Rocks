using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject openBookGO;
    public GameObject closedBookGO;
    public GameObject finalMenu;

    private void Start()
    {
        BookScript.close += CloseBook;
        Page.Closed += CloseBook;
        Spine.Over += GameEnd;
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
    private void GameEnd()
    {
        Time.timeScale = 0f;
        finalMenu.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene("FinalScene");
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
    }
    ~UIManager()
    {
        BookScript.close -= CloseBook;
        Page.Closed -= CloseBook;
        Spine.Over -= GameEnd;
    }
}
