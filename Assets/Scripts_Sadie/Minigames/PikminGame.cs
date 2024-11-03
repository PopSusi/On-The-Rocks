using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PikminGame : MiniGameBase
{
    public bool pikminActive;
    [SerializeField] private Image pikminPrefab;
    [SerializeField] private Button scissor;
    [SerializeField] private int maxPikmin;
    public bool holdScissor;
    private Vector2 mousePos;
    private int numPickminCut;

    [Header("Spawn variables")]
    [SerializeField] private float maxX;
    [SerializeField] private float maxY;
    [SerializeField] private float minX;
    [SerializeField] private float minY;



    private void Update()
    {
        if(pikminActive)
        {
            if(holdScissor)
            {
                MoveScissor();
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                ConfirmCheck();
            }
        }
    }


    public override void Interaction()
    {
        interactionCount = 5;
        pikminActive = true;
        gameCanvas.gameObject.SetActive(true);
        SpawnPikmin();
       
    } //END Interaction()

    public override void ConfirmCheck()
    {
        if(numPickminCut == interactionCount)
        {
            //orderManager.playerAccIng.Add(DrinkBase.Accesories.PIKMIN);
            orderManager.Success();
        }
        else
        {
            // orderManager.playerAccIng.Add(DrinkBase.Accesories.FAIL);
            orderManager.Fail();
        }

        holdScissor = false;
        pikminActive = false;
        gameCanvas.gameObject.SetActive(false);
    } //END ConfirmCheck()

    /// <summary>
    /// Spawn pikmin images into scene
    /// </summary>
    private void SpawnPikmin()
    {
        for(int i = 0; i < maxPikmin; i++)
        {
            Vector2 _spawnPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Instantiate(pikminPrefab, _spawnPos, pikminPrefab.transform.rotation, gameCanvas.gameObject.transform);
        }
    } //END SpawnPikmin()

    /// <summary>
    /// Enable state to allow scissor to follow player mouse
    /// </summary>
    public void GrabScissor()
    {
        holdScissor = true;
    } //END GrabScissor() 

    /// <summary>
    /// Make scissor button follow the cursor
    /// </summary>
    private void MoveScissor()
    {
        mousePos = Input.mousePosition;
        scissor.transform.position = mousePos;
    } //END MoveScissor()

    public void CutPickmin()
    {
        if(holdScissor)
        {
            Debug.Log("Cut pikmin");
            numPickminCut++;
        }
    }

}
