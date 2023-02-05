using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade Objekt", menuName = "Upgrade Object")]
public class Upgrade : ScriptableObject
{
    public Sprite icon;
    public string title;
    public string description;
    public int cost;
    public bool purchased;
    public int stage;
    public int maxStage;
    public int upgradeType;

}
