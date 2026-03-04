using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PointspopupSpawner 
{
    // Referencia al prefab del popup. Se asigna desde los inicializadores de escena
    private static GameObject _prefab;

    // Método para asignar el prefab desde el inicializador de cada escena
    public static void Init(GameObject prefab)
    {
        _prefab = prefab;
    }

    // Instancia el popup en la posición indicada y le pasa los puntos a mostrar
    // Se le suma Vector3.up * 0.5f para que aparezca ligeramente encima del objeto
    public static void Spawn(int points, Vector3 position)
    {
        if (_prefab == null)
        {
            Debug.LogWarning("PointsPopupSpawner: prefab no asignado.");
            return;
        }

        GameObject popup = Object.Instantiate(_prefab, position + Vector3.up * 0.5f, Quaternion.identity);

        // Llamamos a Setup() para asignar los puntos y arrancar la animación
        popup.GetComponent<PointsPopUp>().Setup(points);
    }
}
