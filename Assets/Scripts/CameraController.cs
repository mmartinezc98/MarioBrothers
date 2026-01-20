using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;   // Mario
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private float offsetX = 2f; // Para que se desplace horizontalmente solo

    private void FixedUpdate()
    {
        // Posición deseada SOLO en X
        float desiredX = target.position.x + offsetX;

        // Movimiento suave 
        float newX = Mathf.MoveTowards(
            transform.position.x,
            desiredX,
            smoothSpeed * Time.fixedDeltaTime
        );

        //actualiza la posición solo en el ejex (sin seguir en el y)
        transform.position = new Vector3(
            newX,
            transform.position.y
            
        );
    }
}
