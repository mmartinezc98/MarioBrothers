using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Clase encargada de administrar las traducciones de la aplicación.
/// Carga el idioma desde un JSON con una estructura determinada en la carpeta Resources.
/// </summary>

public class I18n
{
    //para buscar rapidamente las traducciones en la memoria
    private Dictionary<string, string> _translationsDictionary = new Dictionary<string, string>();

    // inicializamos el juego con un idioma por defecto
    public I18n(string language = "es")
    {
        this.ChangeLanguage(language);
    }

    /// <summary>
    /// Cambia el idioma actual cargando un nuevo archivo JSON.
    /// </summary>
    /// <param name="language">Nombre del archivo (ej: "es", "en") dentro de Resources/i18n/</param>
    public void ChangeLanguage(string language)
    {
        //cargamos el archivo de la carpeta traductions
        TextAsset contentJson= Traductions.Load<TextAsset>($"Traductions"language);
    }

}
