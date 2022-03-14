using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spoonBossTIp : MonoBehaviour
{
    public spawnHitEffect effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("weight"))
        {
            if (collision.GetComponent<weight>().isReturn)
                return;

            sound.Instance.playSound("WeightHitSpoon");
            effect.hitParticle();
            collision.GetComponent<weight>().onHit(transform.position);
        }
    }
}
