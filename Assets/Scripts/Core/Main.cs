using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Main 
{
    public static Il18n Il18n;
    public static CustomEvents CustomEvents;
    public static Config Config;
    public static Player Player;

    // Start is called before the first frame update
    public static void Start()
    {
        CustomEvents = new CustomEvents();
        Player= new Player();
    }

   
}
