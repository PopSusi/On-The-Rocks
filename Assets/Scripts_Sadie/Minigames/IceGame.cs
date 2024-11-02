using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGame : MiniGameBase
{
    public override void Interaction()
    {
        orderManager.playerAccIng.Add(DrinkBase.Accesories.ICE);
    }
}
