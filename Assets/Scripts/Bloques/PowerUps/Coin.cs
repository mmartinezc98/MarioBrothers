using UnityEngine;
using System.Collections;

public class Coin: MonoBehaviour
{
    [SerializeField] private float _riseHeight = 1f;     // Cuánto sube la moneda
    [SerializeField] private float _riseSpeed = 3f;      // Velocidad de subida
    [SerializeField] private float _lifetime = 0.5f;     // Tiempo antes de desaparecer
    [SerializeField] private float _lastSpriteTimer = 0.5f;     // Tiempo antes de cambiar al sprite final
    [SerializeField] private Sprite _endSprite;         //sprite final de la moneda

    private Vector3 startPos; //posicion inicial
    private Vector3 targetPos; //posicion final
    private SpriteRenderer _sr; //cogemos el sprite de la moneda (para cambiarla al final)


    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>(); //cogemos el sprite del objeto para hacer el cambio del sprite final

        startPos = transform.position;    //cogemos la posicion inicial de la moneda
        targetPos = startPos + Vector3.up * _riseHeight; //calculamos la posicion final

        StartCoroutine(RiseAndDisappear());
    }

    #region CORRUTINA DE LA MONEDA
    private IEnumerator RiseAndDisappear()
    {
        // movimiento de la moneda
        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, _riseSpeed * Time.deltaTime);
            yield return null;
        }

        //tempo de espera para cambiar el sprite final
        yield return new WaitForSeconds(_lastSpriteTimer);

        //cambiamos el sprite final de la moneda        
            _sr.sprite = _endSprite;

        //tempo de espera
        yield return new WaitForSeconds(_lifetime);

        //destruimos la moneda
        Destroy(gameObject);
    }

    #endregion
}
