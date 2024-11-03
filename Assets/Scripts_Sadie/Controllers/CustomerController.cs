using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    public delegate void SendIcon(Sprite sprite);
    public static event SendIcon Icon;
    public delegate void CustomerAlerts();
    public static event CustomerAlerts LeftScreen;


    public CustomerBase customerData;
    public List<IngredientBase> ingredients = new List<IngredientBase>();
    public Coroutine animateCoroutine;
    public Coroutine speakCoroutine;
    private float driftTime;
    private float elapsedTime;
    private AudioSource audioSource;

    private SpriteRenderer sprite;


    /*WTF is happening in game
    Player starts game (UI)
    Customer is instantiated with data (data is filled in w customer base yippee (DONE)
    Player recieves customer's order (UI) (customer order is stored in customer base as a spawn of drink SO) (GREYBOX DONE ISH)
    Depending on Drink SO passed to some order manager ig, new Ui is loaded 
    Drink So spawn holds list of ingredients (DONE)
    Each ingredient is listed in array of ingredients by enum type (DONE)
    Based on the enum, associated w an ingtredient (DONE)
    Book is loaded in w/ info on apages (DONE)
    Player clicks through pages to find the drink recipe (DONE)
    Ingredients on side or somewhere, doesn't matter what page s up question mark? (DONE)
    When click on ingredients, launches minigame by passing ingredient enum into a fmanager, interaction called on minigame by this
    Making me wonder if we need the ingredient class or just use minigames?
    That should all be passed through a manager, order manager?
    On game end, checks if fail or pass
    If fail, put fail into the list, if pass, pass enum for ingredient from drink base
    When player clicks button for done drink, checks the drink liquid and accessories arrays against the accumulatedingredient lists player has made
    Display mad if anything messes up, else get point in a score manager
    Delete customer, instantiate new customer with new order, repeat yippee me when gameplay loop
    */
    public void Initialize()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = customerData.characterSprite;
        OrderManager.OrderDone += DriftOut;
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
            transform.position = Vector3.Lerp(new Vector3(-15f, 3f, 0f), new Vector3(0f, 3f, 0f), Mathf.SmoothStep(0.0f, 1.0f, t)); //ease in ease out
            yield return null;
        }
        animateCoroutine = null;
        speakCoroutine = StartCoroutine("SpeakRepeat");
        yield return null;
    }

    private void DriftOut()
    {
        StartCoroutine("DriftOutCustomer");
    }

    private IEnumerator DriftOutCustomer()
    {
        float t = 0.0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / 2; // length of slide in
            transform.position = Vector3.Lerp(new Vector3(0f, 3f, 0f), new Vector3(15f, 3f, 0f), Mathf.SmoothStep(0.0f, 1.0f, t));
            yield return null;
        }
        animateCoroutine = null;
        LeftScreen();
        Destroy(gameObject);
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
        switch (customerData.pitch) {
            case VoicePitch.Low:
                audioSource.clip = ing.orderLowSFX;
                break;
            case VoicePitch.Med:
            default:
                audioSource.clip = ing.orderMedSFX;
                break;
            case VoicePitch.High:
                audioSource.clip = ing.orderHighSFX;
                break;
        }
        audioSource.Play();
        Icon(ing.bookSprite);
    }

    public void AttemptCancelSpeech()
    {
        if (speakCoroutine != null) StopCoroutine(speakCoroutine);
    }

    ~CustomerController()
    {
        OrderManager.OrderDone -= DriftOut;
    }
}
