using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    public CustomerBase customerData;
    public List<IngredientBase> ingredients = new List<IngredientBase>();
    public Coroutine animateCoroutine;
    private float driftTime;
    private float elapsedTime;
    private AudioSource audioSource;


    /*WTF is happening in game
    Player starts game (UI)
    Customer is instantiated with data (data is filled in w customer base yippee (DONE)
    Player recieves customer's order (UI) (customer order is stored in customer base as a spawn of drink SO) (GREYBOX DONE ISH)
    Depending on Drink SO passed to some order manager ig, new Ui is loaded 
    Drink So spawn holds list of ingredients (DONE)
    Each ingredient is listed in array of ingredients by enum type (DONE)
    Based on the enum, associated w an ingtredient
    Book is loaded in w/ info on apages
    Player clicks through pages to find the drink recipe
    Ingredients on side or somewhere, doesn't matter what page s up question mark?
    When click on ingredients, launches minigame by passing ingredient enum into a fmanager, interaction called on minigame by this
    Making me wonder if we need the ingredient class or just use minigames?
    Minigame must return an enum type and apply it to an array/List(s) that can then be compared?
    That should all be passed through a manager, order manager?
    On game end, checks if fail or pass
    If fail, put fail into the list, if pass, pass enum for ingredient from drink base
    When player clicks button for done drink, checks the drink liquid and accessories arrays against the accumulatedingredient lists player has made
    Display mad if anything messes up, else get point in a score manager
    Delete customer, instantiate new customer with new order, repeat yippee me when gameplay loop
    */
    public void Initialize()
    {
        audioSource = GetComponent<AudioSource>();
        animateCoroutine = StartCoroutine("DriftInCustomer");
        foreach (var ing in customerData.drinkBase.accIngredients) {
            ingredients.Add(ing);
        }
        foreach (var ing in customerData.drinkBase.liquidIngredients)
        {
            ingredients.Add(ing);
        }
    }

    private IEnumerator DriftInCustomer()
    {
        float t = 0.0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / 2; // length of slide in
            transform.position = Vector3.Lerp(new Vector3(-15f, 0f, 0f), new Vector3(0, 0, 0), Mathf.SmoothStep(0.0f, 1.0f, t)); //ease in ease out
            yield return null;
        }
        animateCoroutine = null;
        StartCoroutine("SpeakRepeat");
        yield return null;
    }
    private IEnumerator DriftOutCustomer()
    {
        float t = 0.0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / 2; // length of slide in
            transform.position = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(15, 0, 0), Mathf.SmoothStep(0.0f, 1.0f, t));
            yield return null;
        }
        animateCoroutine = null;
        yield return null;
    }

    private IEnumerator SpeakRepeat()
    {
        foreach(IngredientBase ing in ingredients)
        {
            yield return new WaitForSeconds(1f);
            Speak(ing);
        }
    }

    private void Speak(IngredientBase ing)
    {
        audioSource.clip = ing.orderSFX;
        audioSource.Play();
    }
}
