using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundTest : MonoBehaviour
{
    private bool increase;
    private float minVolume;

    private void Awake()
    {
        minVolume = GetComponent<AudioSource>().volume;
    }


    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject() && GetComponent<AudioSource>().volume < 1)
            GetComponent<AudioSource>().volume += Time.deltaTime/3;
        else if (!EventSystem.current.IsPointerOverGameObject() && GetComponent<AudioSource>().volume > minVolume)
            GetComponent<AudioSource>().volume -= Time.deltaTime/3;
    }

}
