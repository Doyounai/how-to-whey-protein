using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weight : MonoBehaviour
{
    public Vector3 diration;
    public float speed;

    public float rotateSpeed = 2;
    public bool isReturn = false;

    public spawnHitEffect effect;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);
        transform.position += diration * speed * Time.deltaTime;
    }

    public void onHit(Vector3 spoonTipPos)
    {
        diration = transform.position - spoonTipPos;
        diration = diration.normalized;
        isReturn = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("brick"))
        {
            if(isReturn)
            {
                sound.Instance.playSound("WeightHitBrick");
                effect.hitParticle();
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
