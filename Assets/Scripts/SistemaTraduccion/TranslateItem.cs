using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Representa un par clave-valor de traducción dentro del JSON.
/// Inicializa las variables de key y value
/// </summary>
/// 
[Serializable] // para que se puedan deserializar los campos del json
public class TranslateItem 
{
    /// <summary>
    /// Identificador único de la traducción (ej: "_jugador").
    /// </summary>
    public string key;

    /// <summary>
    /// Texto traducido que se mostrará al usuario ("1 Jugador"/"1 Player").
    /// </summary>
    public string value;
}
