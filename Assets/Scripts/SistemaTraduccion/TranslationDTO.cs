using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Objeto de Transferencia de Datos (DTO) que representa la estructura raíz del JSON.
/// Se utiliza exclusivamente para el paso intermedio entre el archivo de texto y el diccionario en memoria.
/// </summary>
[Serializable]
public class TranslationDTO
{
    /// <summary>
    /// Lista que coincide con el nombre del array en el archivo JSON ("translations": [...]).
    /// </summary>
    public List<TranslateItem> translations;
}

