using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;   // Mario
    [SerializeField] private float _smoothSpeed = 5f;
    [SerializeField] private float _offsetX = 2f; // Para que se desplace horizontalmente solo

    private void FixedUpdate()
    {
        // Posición deseada en X
        float newXPosition = _target.position.x + _offsetX;

        // Movimiento suave 
        float newX = Mathf.MoveTowards(transform.position.x, newXPosition, _smoothSpeed * Time.fixedDeltaTime);

        //actualiza la posición solo en el ejex (sin seguir el y)
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
