using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSource : MonoBehaviour
{
    public float UpgradePoints;

    public float Collect()
    {
        Destroy(gameObject, 0.1f);
        return UpgradePoints;
    }
}
