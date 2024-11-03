using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Page : MonoBehaviour
{
    public delegate void IngredientSend(MiniGameBase.Type minigame);
    public static event IngredientSend Send;

    public TextMeshProUGUI[] body;
    public Image[] icon;
    public IngredientBase[] ingredients;

    public void SetValues(PageBase page)
    {
        ingredients = page.ingredient;
        body[0].text = ingredients[0].bookText;
        icon[0].sprite = ingredients[0].bookSprite;
        body[1].text = ingredients[1].bookText; 
        icon[1].sprite = ingredients[1].bookSprite;
    }
    public void SendEvent(int index)
    {
        Send(ingredients[index].type);
    }
}
