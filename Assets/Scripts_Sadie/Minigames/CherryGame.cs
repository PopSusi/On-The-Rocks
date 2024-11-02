using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryGame : MiniGameBase
{
    public override void Interaction()
    {
        orderManager.playerAccIng.Add(DrinkBase.Accesories.CHERRY);
    }
}
