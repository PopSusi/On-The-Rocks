using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CharacterDrinkManager : MonoBehaviour
{
    private CustomerBase[] customerBases;
    public CustomerBase customerBase;
    [SerializeField] private GameObject customerPrefab;
    private DrinkBase[] drinkBases;
    public DrinkBase drinkBase;
    [SerializeField] private OrderManager orderManager;

    public CustomerController currentCustomer;
    void Start()
    {
        //Test on start
        CustomerInitialize();
        CustomerController.LeftScreen += RespawnCustomer;
    }


    /// <summary>
    /// Spawns in a customer
    /// </summary>
   public void CustomerInitialize()
    {
        customerBases = Resources.LoadAll<CustomerBase>("Customers");
        customerBase = customerBases[UnityEngine.Random.Range(0, customerBases.Length)];
        Debug.Log(" new customer");

        currentCustomer = Instantiate(customerPrefab, new Vector3(-15, 0, 0), quaternion.identity).GetComponent<CustomerController>();
        customerPrefab.GetComponent<CustomerController>().customerData = customerBase;
        OrderManager.OrderDone += currentCustomer.DriftOut;
        DrinkInitialize();
    }

    /// <summary>
    /// Assigns a drink to the customer
    /// </summary>
    public void DrinkInitialize()
    {
        drinkBases = Resources.LoadAll<DrinkBase>("Drinks");
        drinkBase = drinkBases[UnityEngine.Random.Range(0, drinkBases.Length)];
        
        currentCustomer.customerData.drinkBase = drinkBase;
        Debug.Log(currentCustomer.customerData.drinkBase);
        currentCustomer.Initialize();
    }

    //Once round is over, delete current customer and spawn in new one
    public void RespawnCustomer()
    {
        OrderManager.OrderDone -= currentCustomer.DriftOut;
        Destroy(currentCustomer.gameObject);
        CustomerInitialize();
    }
    ~CharacterDrinkManager()
    {
        CustomerController.LeftScreen -= CustomerInitialize;
    }
}
