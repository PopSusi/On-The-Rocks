using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconSlots : MonoBehaviour
{
    public Image[] icons;
    int iterator = 0;

    public void Awake()
    {
        CustomerController.Icon += NewSlot;
        OrderManager.OrderDone += ResetIterator;
    }

    public void NewSlot(Sprite img)
    {
        icons[iterator].sprite = img;
        icons[iterator].gameObject.SetActive(true);
        iterator++;
    }
    public void ResetIterator()
    {
        iterator = 0;
        foreach(var slots in icons)
        {
            slots.gameObject.SetActive(false);
        }
    }
    ~IconSlots()
    {
        CustomerController.Icon -= NewSlot;
        OrderManager.OrderDone -= ResetIterator;
    }
}
