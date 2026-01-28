using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallState : MarioSizeState //estado de mario pequeño
{
    public SmallState(PlayerController player) : base(player) { }

    public override void Enter() //a entrar en este estado cambiamos las animaciones de mario pequeño y ajustamos el collider
    {
       /* animations.SetForm(0);
        player.SetColliderHeight();*/
        
    }
    public override void TakenDamage() //cuando es pequeño y recibe daño muere (TO-DO: logica de animaciones y tal)
    {
        base.TakenDamage();
    }
}
