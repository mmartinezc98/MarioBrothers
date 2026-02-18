using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public CheckPointEnum checkpointID;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Main.LastCheckPoint = checkpointID;
            Debug.Log("Checkpoint activado: " + checkpointID);

        }
    }
}
