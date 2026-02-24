using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsUI : MonoBehaviour
{
    private TextMeshProUGUI points;

    private void Awake()
    {
        points= GetComponent<TextMeshProUGUI>();
        Main.CustomEvents.OnPointsChanged.AddListener(PointsText); //suscribimos al evento de cambiar puntos con el metodo que cambia el texto
    }

    
    private void PointsText()
    {
        points.text = $"{Main.Player.Points:D6}";
    }
}
