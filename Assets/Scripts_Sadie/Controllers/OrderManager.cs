using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OrderManager : MonoBehaviour
{
    //Player's wins and fails get passed into here

    public List<bool> checks = new List<bool>();
    public DrinkBase drinkBase; //Can now access the arrays for drink for comparison
    [SerializeField] private CharacterDrinkManager characterDrinkManager;

    public bool liquidCorrect = false;
    public bool accesoriesCorrect = false;

    private AudioSource audioSource;

    public delegate void OrderAlerts();
    public static event OrderAlerts OrderDone;
    public delegate void OrderResult(string result);
    public static event OrderResult OrderResultSend;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// When drink is done, checks to see if drink is correct or incorrect
    /// </summary>
    public void CompareDrinks()
    {/*
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
        }*/
        characterDrinkManager.currentCustomer.AttemptCancelSpeech();
        int checkCount = 0;
        foreach (bool booleanCheck in checks)
        {
            if (booleanCheck)
            {
                checkCount++;
            }
        }
        if (checkCount < 2)
        {
            Speak("Mad");
            OrderResultSend("Mad");
            Debug.Log("Mad");
        }
        else if (checkCount == checks.Count)
        {
            Speak("Good");
            OrderResultSend("Good");
            Debug.Log("Good");
        }
        else
        {
            Speak("Meh");
            OrderResultSend("Meh");
            Debug.Log("Meh");
        }
            ResetMetrics();
    } //END Compare Drinks()

    private void ResetMetrics()
    {
        checks.Clear();
    }

    private void Speak(string response)
    {
        switch (response)
        {
            case "Mad":
                if (characterDrinkManager.customerBase.pitch == VoicePitch.High)
                    audioSource.clip = Resources.Load<AudioClip>("Sounds/Angry/ANGY-HIGH");
                if (characterDrinkManager.customerBase.pitch == VoicePitch.Med)
                    audioSource.clip = Resources.Load<AudioClip>("Sounds/Angry/ANGY-MID");
                if (characterDrinkManager.customerBase.pitch == VoicePitch.Low)
                    audioSource.clip = Resources.Load<AudioClip>("Sounds/Angry/ANGY-LOW");
                break;
            case "Meh":
                if (characterDrinkManager.customerBase.pitch == VoicePitch.High)
                    audioSource.clip = Resources.Load<AudioClip>("Sounds/Bad/MEH-HIGH");
                if (characterDrinkManager.customerBase.pitch == VoicePitch.Med)
                    audioSource.clip = Resources.Load<AudioClip>("Sounds/Bad/MEH-MID");
                if (characterDrinkManager.customerBase.pitch == VoicePitch.Low)
                    audioSource.clip = Resources.Load<AudioClip>("Sounds/Bad/MEH-LOW");
                break;
            case "Good":
            default:
                if (characterDrinkManager.customerBase.pitch == VoicePitch.High)
                    audioSource.clip = Resources.Load<AudioClip>("Sounds/Good/LESSGO-HIGH");
                if (characterDrinkManager.customerBase.pitch == VoicePitch.Med)
                    audioSource.clip = Resources.Load<AudioClip>("Sounds/Good/LESSGO-MID");
                if (characterDrinkManager.customerBase.pitch == VoicePitch.Low)
                    audioSource.clip = Resources.Load<AudioClip>("Sounds/Good/LESSGO-LOW");
                break;
        }
        audioSource.Play();
        OrderDone();
    }

    public void Success()
    {
        checks.Add(true);
    }

    public void Fail()
    {
        checks.Add(false);
    }

    /// <summary>
    /// Checks liquid ingredients
    /// </summary>
    /*private void CheckLiquid()
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
    */

}
