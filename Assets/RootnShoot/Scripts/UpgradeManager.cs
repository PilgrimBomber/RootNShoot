using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : SingletonMonoBehaviour<UpgradeManager>
{
    public int hardlockLevel = 0;
    public int softlockLevel = 0;
    public int rootSpeedLevel = 0;
    public int rootStraightLevel = 0;
    public int juiceCostLevel = 0;
    public int visionRangeLevel = 0;//
    public float UpgradePoints=20;
    public List<float> speedValues;
    public List<float> rootSpreadAngles;
    public List<float> rootSpreadProbs;
    public List<float> juiceCostMultiplier;
    public List<float> orthoSizes;
    public List<float> lightRanges;
    public float Speed 
    {
        get 
        {
            return speedValues[rootSpeedLevel];
        }
    }
    public float SpreadAngle 
    {
        get 
        {
            return rootSpreadAngles[rootStraightLevel];
        }
    }
    public float SpreadProb 
    {
        get 
        {
            return rootSpreadProbs[rootStraightLevel];
        }
    }
    public float JuiceMultiplier
    {
        get
        {
            return juiceCostMultiplier[juiceCostLevel];
        }
    }

    public float OrthoSize
    {
        get
        {
            return orthoSizes[visionRangeLevel];
        }
    }

    public float LightRange
    {
        get
        {
            return lightRanges[visionRangeLevel];
        }
    }

}
