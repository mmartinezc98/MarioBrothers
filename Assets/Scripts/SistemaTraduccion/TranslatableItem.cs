using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Componente para textos de TextMeshPro que se actualizan automáticamente
/// cuando cambia el idioma del sistema.
/// </summary>
[RequireComponent(typeof(TextMeshProUGUI))]
public class TranslatableItem : MonoBehaviour
{
    private TextMeshProUGUI _text;

    [Tooltip("Clave técnica que coincide con el JSON (ej: '_jugador')")]
    [SerializeField] private string _key;

    private void Awake()
    {
        this._text = GetComponent<TextMeshProUGUI>(); //asignamos al texto el componenete textmeshpro

        // Nos suscribimos al evento de cambio de idioma.
        // Al usar UnityEvents, cada vez que se invoque 'OnLanguageChanged', 
        // este objeto ejecutará UpdateText().
        Main.CustomEvents.OnLanguageChanged.AddListener(UpdateText);
    }

    void Start()
    {
        // Forzamos la primera actualización al inicio para mostrar el idioma actual.
        this.UpdateText();
    }

    /// <summary>
    /// Consulta el diccionario global y actualiza el visual
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private void UpdateText()
    {
        if (this._text == null) 
        {
            return;        
        }

        //cogemos la traduccion(si no hay devuelve la key)
        string translatedValue = Main.I18n.Get(this._key);

        //ponemos la traduccion en la caja de texto
        this._text.text = translatedValue;
    }

    /// <summary>
    /// Siempre debemos desuscribirnos de eventos globales cuando el objeto se destruye para 
    /// evitar fugas de memoria o errores de referencia nula.
    /// </summary>
    private void OnDestroy()
    {
        if (Main.CustomEvents != null)
        {
            Main.CustomEvents.OnLanguageChanged.RemoveListener(UpdateText);
        }
    }
}
