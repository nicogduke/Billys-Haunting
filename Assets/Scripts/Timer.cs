using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float targetTime = 5.0f;

    public GameObject block;
    public Vector3 blockSpawn;

    void Update()
    {

        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }

    }

    void timerEnded()
    {
        Instantiate(block, blockSpawn, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
