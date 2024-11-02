using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Page : MonoBehaviour
{
    public delegate void IngredientSend(IngredientBase ingredient);
    public static event IngredientSend Send;

    public TextMeshProUGUI[] body;
    public TextMeshProUGUI[] head;
    public Image[] icon;
    public IngredientBase[] ingredients;

    public void SetValues()
    {
        //body.text[0] = ingredients[0].bookText; edit Scriptable Object to be string
        //head[0].text = ingredients[0].type.ToString();
        icon[0].sprite = ingredients[0].bookSprite;
        //body.text[1] = ingredients[1].bookText; edit Scriptable Object to be string
        //head[1].text = ingredients[1].type.ToString();
        icon[1].sprite = ingredients[1].bookSprite;
    }
    public void SendEvent(int index)
    {
        Send(ingredients[index]);
    }
}
