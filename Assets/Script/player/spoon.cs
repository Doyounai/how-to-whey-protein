using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class spoon : MonoBehaviour
{   
    public Transform start;
    public Transform end;

    public Transform head;
    public Transform low;

    public float factor = 1.0f;

    void Start()
    {
        SetPos(start.position, end.position);
    }

    void Update()
    {
        SetPos(start.position, end.position);
    }

    void SetPos(Vector3 start, Vector3 end)
    {
        var dir = end - start;
        var mid = (dir) / 2.0f + start;
        transform.position = mid;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);

        head.position = this.start.position;
        low.position = this.end.position;
    }
}
