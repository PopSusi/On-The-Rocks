using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    //Player's wins and fails get passed into here

    public List<DrinkBase.Liquids> playerLiquidIng;
    public List<DrinkBase.Accesories> playerAccIng;
    public DrinkBase drinkBase; //Can now access the arrays for drink for comparison
    [SerializeField] private CharacterDrinkManager characterDrinkManager;

    public bool liquidCorrect = false;
    public bool accesoriesCorrect = false;

    /// <summary>
    /// When drink is done, checks to see if drink is correct or incorrect
    /// </summary>
    public void CompareDrinks()
    {
        if (playerLiquidIng.Count == drinkBase.liquidIngredients.Length && playerAccIng.Count == drinkBase.accIngredients.Length)
        {
            //Check if drink has right number of ingredients
            CheckLiquid();
            CheckAccessories();

            //If all ingredients are correct
            if (liquidCorrect && accesoriesCorrect) 
            {
                //Run Success code
                Debug.Log("Success!");
                //Delete this character after a few seconds and respawn new one
                playerLiquidIng.Clear();
                playerAccIng.Clear();
                characterDrinkManager.RespawnCustomer();

            }
        }
        else
        {
            //Fail! 
            //Run fail code
            Debug.Log("Fail");
            playerLiquidIng.Clear();
            playerAccIng.Clear();
            characterDrinkManager.RespawnCustomer();
        }
    } //END Compare Drinks()

    /// <summary>
    /// Checks liquid ingredients
    /// </summary>
    private void CheckLiquid()
    {
        
            for (int i = 0; i < drinkBase.liquidIngredients.Length; i++)
            {
                if (playerLiquidIng[i] == drinkBase.liquidIngredients[i])
                {
                    //Correct!
                    if (i == drinkBase.liquidIngredients.Length - 1)
                    {
                    Debug.Log("Liquid check done");
                        //Run end code for success
                        liquidCorrect = true;
                        break;
                    }
                    else
                    {
                        continue;
                    }

                }
                else
                {
                //Fail!
                //Run end code for fail
                Debug.Log("Fail");
                break;
                }
            }
        
    } //END CheckLiquid()

    private void CheckAccessories()
    {
        for (int i = 0; i < drinkBase.accIngredients.Length; i++)
        {
            if (playerAccIng[i] == drinkBase.accIngredients[i])
            {
                //Correct!
                if (i == drinkBase.accIngredients.Length - 1)
                {
                    Debug.Log("Acc check done");
                    //Run end code for success
                    accesoriesCorrect = true;
                    break;
                }
                else
                {
                    continue;
                }

            }
            else
            {
                //Fail!
                //Run end code for fail
                Debug.Log("Fail");
                break;
            }
        }

    } //END CheckAccesssories()


}
