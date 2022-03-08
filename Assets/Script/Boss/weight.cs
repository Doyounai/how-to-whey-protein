using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weight : MonoBehaviour
{
    public Vector3 diration;
    public float speed;

    public float rotateSpeed = 2;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);
        transform.position += diration * speed * Time.deltaTime;
    }
}
