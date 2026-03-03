using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mario/SoundLibrary")]
public class SoundLibrary : ScriptableObject
{
    [Header("Player")]
    public AudioClip smallStatejump;
    public AudioClip bigStatejump;
    public AudioClip fireball;
    public AudioClip powerUp;
    public AudioClip damage;
    public AudioClip death;
    public AudioClip grow;
    


    [Header("Items")]
    public AudioClip coin;
    public AudioClip oneUp;
    public AudioClip pipeDown;

    [Header("Enemies")]
    public AudioClip stomp;

    [Header("UI")]
    public AudioClip click;
    public AudioClip gameOver;
    public AudioClip pause;

}


