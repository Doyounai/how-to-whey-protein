using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnHitEffect : MonoBehaviour
{
    public Transform hitPototype;

    public void hitParticle()
    {
        Instantiate(hitPototype, transform.position, Quaternion.identity);
    }
}
