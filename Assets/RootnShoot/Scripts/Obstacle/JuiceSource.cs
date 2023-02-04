using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuiceSource : MonoBehaviour
{
    [SerializeField]float JuiceAmount;
    public int ConsumptionLevelNeeded = 0;

    public float Collect()
    {
        Destroy(gameObject, 0.1f);
        return JuiceAmount;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
