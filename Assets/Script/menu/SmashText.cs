using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashText : MonoBehaviour
{
    public float time;
    public float heightTo;
    public LeanTweenType easeType;

    private void Start()
    {
        Vector3 to = transform.localPosition + (Vector3.up * heightTo);
        LeanTween.moveLocal(gameObject, to, time).setLoopPingPong().setEase(easeType);
    }
}
