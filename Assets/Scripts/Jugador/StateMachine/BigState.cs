using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigState : MarioSizeState //estado de mario grande
{
    public BigState(PlayerController player) : base(player) { }

    public override void Enter()
    {
        /* animations.SetForm(1);
        player.SetColliderHeight();*/
    }

    public override void TakenDamage() //cuando el mario grande recibe daño se hace pequeño
    {
        //player.ChangeSizeState(player.smallState);
    }

   
}
