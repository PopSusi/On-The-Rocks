using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDrinkManager : MonoBehaviour
{
     public CustomerBase[] customerBases;
    public CustomerBase customerBase;
    [SerializeField] private GameObject customerPrefab;
    public DrinkBase drinkBase;
    public DrinkBase[] drinkBases;

    public CustomerController currentCustomer;
    void Start()
    {
        //Test on start
        CustomerInitialize();
    }



   public void CustomerInitialize()
    {
        customerBase = customerBases[Random.Range(0, customerBases.Length)];
        Debug.Log(customerBase);

        currentCustomer = Instantiate(customerPrefab).GetComponent<CustomerController>();
        customerPrefab.GetComponent<CustomerController>().customerData = customerBase;

        DrinkInitialize();
    }

    public void DrinkInitialize()
    {
        drinkBase = drinkBases[Random.Range(0, drinkBases.Length)];
        currentCustomer.customerData.drinkBase = drinkBase;
    }
}
