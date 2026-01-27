using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Estados de los bloques
public enum BlockState{Idle, Bumped, Used, Broken}

public abstract class BlockBase : MonoBehaviour
{
    [SerializeField] protected BlockState state = BlockState.Idle; //seteamos el estado inicial del bloque a idle

    [Header("Bump Settings")]
    [SerializeField] private float _bumpHeight = 0.15f;   // altura a la que sube el bloque (target)
    [SerializeField] private float _bumpSpeed = 8f;       // velocidad a la que se mueve

    private Vector3 _originalPosition;
    private bool _isBumping = false;

    protected virtual void Awake()
    {
        _originalPosition = transform.localPosition; //cogemos la posicion inicial del bloque 
    }

    public virtual void HitFromBelow(GameObject hitter)
    {
        if (state != BlockState.Idle || _isBumping)
            return;

        state = BlockState.Bumped;
        _isBumping = true;

        StartCoroutine(BumpRoutine(hitter)); //iniciamos la corrutina
    }


    #region CORRUTINA PARA EL BUMP DEL BLOQUE
   
    private IEnumerator BumpRoutine(GameObject hitter)
    {
        //Subida del bloque
        Vector3 targetPos = _originalPosition + Vector3.up * _bumpHeight;

        while (Vector3.Distance(transform.localPosition, targetPos) > 0.001f)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, _bumpSpeed * Time.deltaTime);
            yield return null;
        }

        //Se ejecuta la lóquica del bloque
        OnHit(hitter);

        //bajada del bloque
        while (Vector3.Distance(transform.localPosition, _originalPosition) > 0.001f)
        {
            transform.localPosition = Vector3.MoveTowards(
                transform.localPosition,
                _originalPosition,
                _bumpSpeed * Time.deltaTime
            );
            yield return null;
        }

        //se cambia el estado de bumping a false y se vuelve a setear como idle
        _isBumping = false;

        if (state == BlockState.Bumped)
        {
            state = BlockState.Used;
            OnBecomeUsed();
        }
    }
    #endregion

    //que hacen los bloques al darles
    protected abstract void OnHit(GameObject hitter); 

    //para cambiar el sprite, desctivar collider etc
    protected virtual void OnBecomeUsed()
    {

    }
    
}


