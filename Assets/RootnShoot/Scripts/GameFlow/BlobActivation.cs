using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class BlobActivation : MonoBehaviour
{
    public float lightTime;
    private float currentLightTime=0;
    public float lightIntensity;
    private float currentIntensity = 0;
    public Light2D light;
    public void ActivateTheBlob()
    {
        StartCoroutine(IncreaseLightIntensity());
    }

    private IEnumerator IncreaseLightIntensity()
    {
        while(currentLightTime<lightTime)
        {
            currentIntensity = currentLightTime / lightTime * lightIntensity;
            currentLightTime += Time.deltaTime;
            light.intensity = currentIntensity;
            yield return null;

        }

        Debug.Log("Glowing finished");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
