using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;   // Mario
    [SerializeField] private float _smoothSpeed = 5f;
    [SerializeField] private float _offsetX = 2f;

    private float _maxCameraX; // Guarda la posición máxima alcanzada

    private void Start()
    {
        _target= GameObject.FindGameObjectWithTag("Player").transform; //buscamos el objeto con el tag PLayer y se lo asignamos a la camara para que lo siga

        _maxCameraX = transform.position.x; // Inicializa con la posición inicial de la cámara
    }

    private void FixedUpdate()
    {
        // Posición deseada en X según Mario
        float desiredX = _target.position.x + _offsetX;


        // Movimiento suave hacia la posición deseada
        float newX = Mathf.MoveTowards(transform.position.x, desiredX, _smoothSpeed * Time.fixedDeltaTime);

        // Evitar retroceso: la cámara solo puede avanzar si newX > _maxCameraX
        if (newX > _maxCameraX)
        {
            _maxCameraX = newX; // Actualiza el máximo alcanzado
        }

        // La cámara se queda en el máximo alcanzado, nunca retrocede
        transform.position = new Vector3(_maxCameraX, transform.position.y, transform.position.z);
    }

}

