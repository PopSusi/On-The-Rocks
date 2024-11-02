using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonGame : MiniGameBase
{
    public override void Interaction()
    {
        orderManager.playerLiquidIng.Add(DrinkBase.Liquids.LEMONJUICE);
    }
}
