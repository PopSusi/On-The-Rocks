using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OliveGame : MiniGameBase
{
    public bool oliveActive;
    [SerializeField] private Image scissors;
    [SerializeField] private Image demonTail;
    [SerializeField] private float speed;

    [SerializeField] private float maxX;
    [SerializeField] private float minX;
    private bool moveLeft;

    [SerializeField] private float tailOffset;
    

    public override void Interaction()
    {
        gameCanvas.gameObject.SetActive(true);
        oliveActive = true;
        speed = 1000;
    } //END Interaction()

    public override void ConfirmCheck()
    {
        CheckScissorPlacement();
        oliveActive = false;
        gameCanvas.gameObject.SetActive(false);
    } //END ConfirmCheck()

    private void Update()
    {
        if(oliveActive)
        {
            MoveScissors();
        }
        
    } //END Update()

    /// <summary>
    /// Move scissors object back and forth on screen
    /// </summary>
    private void MoveScissors()
    {
        //Set bool to control movement
        //if scissors move to right end, move left
        if (scissors.transform.position.x >= maxX) 
        {
            moveLeft = true;
            //scissors.transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        //If scissors move to left end
        else if(scissors.transform.position.x <= minX)
        {
            moveLeft = false;
            //scissors.transform.Translate(Vector2.left * Time.deltaTime * speed);
        }

        //Control actual movement
        if(moveLeft)
        {
            scissors.transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        else
        {
            scissors.transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        
    } //END MoveScissors()

    /// <summary>
    /// When cutting, check if the scissor is over the tail object
    /// </summary>
    private void CheckScissorPlacement()
    {
        speed = 0;

        //If in range of tail
        if(scissors.rectTransform.position.x <= demonTail.rectTransform.position.x + tailOffset && scissors.rectTransform.position.x >= demonTail.rectTransform.position.x - tailOffset)
        {
            Debug.Log("Success");
            orderManager.playerAccIng.Add(DrinkBase.Accesories.OLIVE);
        }
        else
        {
            Debug.Log("Fail");
            orderManager.playerAccIng.Add(DrinkBase.Accesories.FAIL);
        }


    } //END CheckScissorPlacement()

} //END OliveGame.cs
