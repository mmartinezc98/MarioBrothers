using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public Difficult Difficult { get; private set; }
    public string Language { get; private set; }

    public List<string> AvailableLanguages { get; private set; } = new List<string>();

    public Config()
    {

    }

}
