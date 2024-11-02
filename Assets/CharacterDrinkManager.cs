using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDrinkManager : MonoBehaviour
{
     public CustomerBase[] customerBases;
    public CustomerBase customerBase;
    [SerializeField] private GameObject customerPrefab;


    void Start()
    {
        //Test on start
        CustomerInitialize();
    }



   public void CustomerInitialize()
    {
        customerBase = customerBases[Random.Range(0, customerBases.Length)];
        Debug.Log(customerBase);

        Instantiate(customerPrefab);
        customerPrefab.GetComponent<CustomerController>().customerData = customerBase;
    }
}
