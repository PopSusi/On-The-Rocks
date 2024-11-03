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
    [SerializeField] private OrderManager orderManager;

    public CustomerController currentCustomer;
    void Start()
    {
        //Test on start
        CustomerInitialize();
    }


    /// <summary>
    /// Spawns in a customer
    /// </summary>
   public void CustomerInitialize()
    {
        customerBase = customerBases[Random.Range(0, customerBases.Length)];
        Debug.Log(customerBase);

        currentCustomer = Instantiate(customerPrefab).GetComponent<CustomerController>();
        customerPrefab.GetComponent<CustomerController>().customerData = customerBase;

        DrinkInitialize();
    }

    /// <summary>
    /// Assigns a drink to the customer
    /// </summary>
    public void DrinkInitialize()
    {
        drinkBase = drinkBases[Random.Range(0, drinkBases.Length)];
        
        currentCustomer.customerData.drinkBase = drinkBase;
        orderManager.drinkBase = drinkBase;
        Debug.Log(currentCustomer.customerData.drinkBase);
    }

    //Once round is over, delete current customer and spawn in new one
    public void RespawnCustomer()
    {
        Destroy(currentCustomer.gameObject);
        CustomerInitialize();
    }
}
