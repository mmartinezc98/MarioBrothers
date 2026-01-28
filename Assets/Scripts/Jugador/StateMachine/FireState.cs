using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireState : MarioSizeState
{
   public FireState(PlayerController player)   : base(player){}

    public override void Enter()
    {
      /*  animations.SetForm(2);
        player.SetColliderHeight(2f); */
    }

    public override void TakenDamage() //cuando mario de fuego recibe daño, cambia a mario grande
    {
       //player.ChangeSizeState(player.bigState);
    }
}
