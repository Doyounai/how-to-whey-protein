using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBehavior : MonoBehaviour
{
    [Header("Count Down")]
    public float maxCount;
    public float minCount;
    public float timeNextAction = 0;

    public void randomNextTime()
    {
        timeNextAction = Random.Range(minCount, maxCount);
    }
}