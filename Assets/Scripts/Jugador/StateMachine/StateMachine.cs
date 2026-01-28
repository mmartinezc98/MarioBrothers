using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine //se encarga de gestionar los estados y  y de llamar al AnimationController de mario para cambiar las aniamciones
{
    public MarioSizeState CurrentState { get; private set; }

    public void InitialState( MarioSizeState startState) //inicializamos la maquina de estados con un estado inicial
    {
        CurrentState = startState;
        startState.Enter();
    }

    public void ChangeState(MarioSizeState newState) //salimos del estado inicial y cambiamos al nuevo estado
    {
        CurrentState.Exit(); //salimos del estado
        CurrentState = newState; //asignamos el nuevo estado
        newState.Enter(); //entramos en el nuevo estado
    }


}
    
