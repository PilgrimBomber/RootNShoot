using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundTest : MonoBehaviour
{
    private bool increase;
    private float maxVolume;
    public float fadeTime;

    private void Awake()
    {
        maxVolume = GetComponent<AudioSource>().volume;
    }


    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject() && GetComponent<AudioSource>().volume <= maxVolume)
            GetComponent<AudioSource>().volume += fadeTime;
        else if (!EventSystem.current.IsPointerOverGameObject() && GetComponent<AudioSource>().volume >= 0)
            GetComponent<AudioSource>().volume -= fadeTime;
    }

}
