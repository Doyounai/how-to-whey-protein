using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHp : MonoBehaviour
{
    public SpriteRenderer playerSprite;
    public Color damgeColor;
    public int hp = 3;
    public dieManager die;

    public GameObject[] hps;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("weight"))
        {
            Destroy(collision.gameObject);
            damge(1);
        }
    }

    void damge(int hit)
    {
        StartCoroutine(flashColor());
        hp -= 1;
        updateHpInterface();
        sound.Instance.playSound("PlayerHurt");

        if (hp <= 0)
        {
            //die
            die.startDie();
        }
    }

    public IEnumerator flashColor()
    {
        playerSprite.color = damgeColor;
        yield return  new WaitForSeconds(0.3f);
        playerSprite.color = Color.white;
    }

    void updateHpInterface()
    {
        for (int i = 0; i < hps.Length; i++)
        {
            hps[i].SetActive(false);
        }

        for (int i = 0; i < hp; i++)
        {
            hps[i].SetActive(true);
        }
    }
}
