using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MarioSizeState //CLASE BASE: define la estructura base de todos los estados de mario (enter, exit y taken damage)
{
    #region VARIABLES
    protected PlayerController player;
    protected PlayerAnimations animations;
    #endregion

    public MarioSizeState(PlayerController player)
    {
        this.player = player;
        animations=player.GetComponent<PlayerAnimations>();
    }

    public virtual void Enter() { } //se ejecuta al entrar al estado (para cambiar animaciones y colisiones)
    public virtual void Exit() { } //se ejecuta al salir del esado (OPCIONAL)

    
    public virtual void TakenDamage() { } //define que hace/ocurre a mario cuando recibe daño
}
