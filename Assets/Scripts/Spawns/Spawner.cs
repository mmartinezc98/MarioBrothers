using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabMario;

    [Header("CheckPoints")] //asignamos los checkpoints (triggers) 
    [SerializeField] private Transform spawnerPoint;
    [SerializeField] private Transform checkpoint1;
    [SerializeField] private Transform checkpoint2;
    
    


    private void Awake()
    {
        // Si no hay checkpoint guardado, usamos el punto de spawn
        if (Main.LastCheckPoint == default)
        {
            Main.LastCheckPoint = CheckPointEnum.Spawn;
        }

        Vector3 spawnPos = GetSpawnPosition(Main.LastCheckPoint);        


        var mario = GameObject.FindAnyObjectByType<PlayerController>();

        if (mario == null)
        {
            Instantiate(this._prefabMario, spawnPos, Quaternion.identity); //si no existe mario instancia el prefab      
        }
        else
        {
            //movemos la camara a la posicion de mario directamente manteniendo su posicion en z
            Camera.main.transform.position = new Vector3(spawnPos.x, spawnPos.y, Camera.main.transform.position.z);

            mario.transform.position = spawnPos; //si existe crea a mario en la posicion que hemos elegido con el Spawner

            
        }
       
    }
    

    private Vector3 GetSpawnPosition(CheckPointEnum id)
    {
        switch (id)
        {
            case CheckPointEnum.Spawn:
                return spawnerPoint.position;
            case CheckPointEnum.Checkpoint1:
                return checkpoint1.position;
            case CheckPointEnum.Checkpoint2:
                return checkpoint2.position;            
            default:
                return spawnerPoint.position;
        }
    }


}
