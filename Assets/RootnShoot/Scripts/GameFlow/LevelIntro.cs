using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelIntro : MonoBehaviour
{
    public GameObject Seed;
    public Transform start;
    public Transform restart;
    public void BeginIntro()
    {
        Seed.SetActive(true);

    }

    public void Update()
    {

    }

}
