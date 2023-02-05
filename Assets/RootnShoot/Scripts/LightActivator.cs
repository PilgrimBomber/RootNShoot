using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightActivator : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.transform.childCount > 0 && collision.gameObject.transform.GetChild(0).TryGetComponent<Light2D>(out Light2D light))
        {
            light.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.transform.childCount>0 && collision.gameObject.transform.GetChild(0).TryGetComponent<Light2D>(out Light2D light))
        {
            light.enabled = false;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
