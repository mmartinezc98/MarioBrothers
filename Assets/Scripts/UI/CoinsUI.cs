using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsUI : MonoBehaviour
{
    private TextMeshProUGUI coins;

    private void Awake()
    {
        coins= GetComponent<TextMeshProUGUI>();
        Main.CustomEvents.OnCoinsChange.AddListener(CoinsText); //nos suscribimos al evento con el metodo para actualizar el texto de las monedas
        
    }

    private void CoinsText()
    {
       coins.text=$"{Main.Player.Coins:D2}";  //actualizamos el texto
    }
}
