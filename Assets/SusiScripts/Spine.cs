using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spine : MonoBehaviour
{
    public int completed;
    public Image blackFill;

    public void SpineUp()
    {
        //baseheight * 6 - completed / 6 (6 stages total)
        float divider = (6f - completed) / 6f;
        float tempHeight = 200 * divider;
        blackFill.rectTransform.sizeDelta = new Vector2(100, tempHeight);
        Debug.Log(divider);
    }
    private void OnValidate()
    {
        SpineUp();
    }
}
