using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieManager : MonoBehaviour
{
    public GameObject player;
    public spawnHitEffect effect;
    public float dieDelay;
    public GameObject dieText;

    public IEnumerator die()
    {
        dieText.SetActive(true);
        effect.hitParticle();
        Destroy(player);
        yield return new WaitForSeconds(dieDelay);
        transition.Instance.startFade(3);
    }

    public void startDie()
    {
        StartCoroutine(die());
    }
}
