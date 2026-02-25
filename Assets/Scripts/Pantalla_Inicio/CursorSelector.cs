using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorSelector : MonoBehaviour
{

    public RectTransform cursor;       // La imagen de la seta/flecha
    public Vector2 offset;             // Offset respecto al botón

    void Update()
    {
        GameObject selected = EventSystem.current.currentSelectedGameObject;

        if (selected != null)
        {
            RectTransform selectedRect = selected.GetComponent<RectTransform>();

            if (selectedRect != null)
            {
                cursor.position = selectedRect.position + (Vector3)offset;
            }
        }
    }
}

