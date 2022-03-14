using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossDiemanager : MonoBehaviour
{
    public GameObject boss;
    public spawnHitEffect effect;
    public float dieDelay;
    public GameObject bossDieText;

    IEnumerator die()
    {
        Destroy(boss);
        effect.hitParticle();
        bossDieText.SetActive(true);
        yield return new WaitForSeconds(dieDelay);
        transition.Instance.startFade(4);
    }

    public void startDie()
    {
        StartCoroutine(die());
    }
}
