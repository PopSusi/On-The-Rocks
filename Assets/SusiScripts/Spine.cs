using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spine : MonoBehaviour
{
    public delegate void GameAlerts();
    public static event GameAlerts Over;


    public int completed;
    public Image blackFill;

    private void Start()
    {
        OrderManager.OrderResultSend += AnalyzeSpineUp;
    }

    private void AnalyzeSpineUp(string result)
    {
            completed++;
            SpineRefresh();
    }

    public void SpineRefresh()
    {
        //baseheight * 5 - completed / 5 (5 stages total)
        float divider = (5f - completed) / 5f;
        float tempHeight = 167 * divider;
        blackFill.rectTransform.sizeDelta = new Vector2(100, tempHeight);
        Debug.Log(divider);
        if (completed == 5) Over();
    }
}
