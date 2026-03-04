using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsPopUp : MonoBehaviour
{
    // Velocidad a la que sube el texto en el mundo
    [SerializeField] private float _floatSpeed = 1.5f;

    // Tiempo total que dura el popup 
    [SerializeField] private float _duration = 0.8f;

    private TextMeshPro _text;

    private void Awake()
    {
        //TextMeshPro del gameObject
        _text = GetComponent<TextMeshPro>();
    }

    // Recibe los puntos a mostrar y arranca la corrutina
    public void Setup(int points)
    {
        _text.text = points.ToString();
        StartCoroutine(FloatAndFade());
    }

    private IEnumerator FloatAndFade()
    {
        float elapsed = 0f;

        // Guardamos el color original del texto para modificar solo el alpha
        Color startColor = _text.color;

        while (elapsed < _duration)
        {
            elapsed += Time.deltaTime;

            // Movemos el texto hacia arriba cada frame
            transform.position += Vector3.up * _floatSpeed * Time.deltaTime;

            // Calculamos el alpha: va de 1 (opaco) a 0 (transparente) a lo largo de _duration
            float alpha = Mathf.Lerp(1f, 0f, elapsed / _duration);
            _text.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            yield return null; // Esperamos al siguiente frame
        }

        // Una vez terminada la animación, destruimos el GameObject
        Destroy(gameObject);
    }
}
