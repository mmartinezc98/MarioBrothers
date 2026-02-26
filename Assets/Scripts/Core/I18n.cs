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
        TextAsset contentJson = Resources.Load<TextAsset>($"i18n/{language}");



        // Si el archivo no existe, evitamos el crash
        if (contentJson == null)
        {
            Debug.LogError($"[i18n] No se encontró el archivo de idioma: Resources/i18n/{language}");
            return;
        }
        try
        {
            // Deserializamos el JSON al objeto de transferencia de datos (DTO)
            TranslationDTO translationsDTO = JsonUtility.FromJson<TranslationDTO>(contentJson.text);

            if (translationsDTO != null && translationsDTO.translations != null)
            {
                // Convertimos la lista del JSON a un diccionario para optimizar el acceso
                this._translationsDictionary = this.ConvertToDictionary(translationsDTO.translations);

                // Notificamos a los componentes interesados (ej: Textos de la UI)
                Main.CustomEvents.OnLanguageChanged?.Invoke();
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"[i18n] Error al parsear el JSON de idioma: {e.Message}");
        }
    }

        /// <summary>
        /// Convierte la lista de items del DTO en un diccionario de búsqueda rápida.
        /// </summary>
    private Dictionary<string, string> ConvertToDictionary(List<TranslateItem> translations)
    {
        Dictionary<string, string> result = new Dictionary<string, string>();

        foreach (var translation in translations)
        {
            // TryAdd evita errores de claves duplicadas en el JSON
            if (!result.TryAdd(translation.key, translation.value))
            {
                Debug.LogWarning($"[i18n] Clave duplicada detectada y omitida: {translation.key}");
            }
        }

        return result;
    }

    /// <summary>
    /// Obtiene el texto traducido. Si la clave no existe, devuelve la propia clave 
    /// para facilitar la identificación de textos faltantes en la UI.
    /// </summary>
    public string Get(string key)
    {
        if (string.IsNullOrEmpty(key)) return string.Empty;

        if (!_translationsDictionary.TryGetValue(key, out string value))
        {
            return key;
        }

        return value;
    }
}


