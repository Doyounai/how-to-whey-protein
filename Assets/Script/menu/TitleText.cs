using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleText : MonoBehaviour
{
    public float time;
    public float scaleUp;
    public LeanTweenType easeType;

    private void Start()
    {
        Vector3 to = transform.localScale + (Vector3.one * scaleUp);
        LeanTween.scale(gameObject, to, time).setLoopPingPong().setEase(easeType);
    }
}
