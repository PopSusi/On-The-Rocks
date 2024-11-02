using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Page : MonoBehaviour
{
    public TextMeshProUGUI[] body;
    public TextMeshProUGUI[] head;
    public Image[] icon;
    public IngredientBase[] ingredient;

    public void SetValues()
    {
        //body.text[0] = ingredient[0].bookText; edit Scriptable Object to be string
        //head[0].text = ingredient[0].type.ToString();
        icon[0].sprite = ingredient[0].bookSprite;
        //body.text[1] = ingredient[1].bookText; edit Scriptable Object to be string
        //head[1].text = ingredient[1].type.ToString();
        icon[1].sprite = ingredient[1].bookSprite;
    }
}
