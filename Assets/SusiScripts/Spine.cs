using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spine : MonoBehaviour
{
    public int completed;
    public Image blackFill;

    private void Start()
    {
        OrderManager.OrderResultSend += AnalyzeSpineUp;
    }

    private void AnalyzeSpineUp(string result)
    {
        if(result == "Good")
        {
            completed++;
            SpineRefresh();
        }
    }

    public void SpineRefresh()
    {
        //baseheight * 6 - completed / 6 (6 stages total)
        float divider = (6f - completed) / 6f;
        float tempHeight = 200 * divider;
        blackFill.rectTransform.sizeDelta = new Vector2(100, tempHeight);
        Debug.Log(divider);
    }
}
