using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelIntro : MonoBehaviour
{
    public GameObject Seed;
    public GameObject Plant;
    public Transform start;
    public Transform restart;
    public Transform target;
    public float flyTime = 5f;
    float currentFlyTime = 0;
    bool isFlying = false;
    public void BeginIntro()
    {
        Seed.SetActive(true);
        Plant.SetActive(false);
        isFlying = true;
        currentFlyTime = 0;
        Seed.transform.position = start.position;
    }

    public void Update()
    {
        if(isFlying)
        {
            Seed.transform.position = start.position + (target.position - start.position) * (currentFlyTime / flyTime);
            currentFlyTime += Time.deltaTime;
            if (currentFlyTime >= flyTime)
            {
                //introFinished;
                Seed.SetActive(false);
                Plant.SetActive(true);
                isFlying = false;
                GameManager.Instance.StartLevel();
            }
        }
        
    }

}
