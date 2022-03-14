using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHp : MonoBehaviour
{
    public int Hp;
    public SpriteRenderer bossSprite;
    public bossDiemanager bossDie;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("weight"))
        {
            if (collision.GetComponent<weight>().isReturn)
            {
                hit();
                Destroy(collision.gameObject);
            }
        }
    }

    void hit()
    {
        Hp -= 1;
        StartCoroutine(flashColor());
        sound.Instance.playSound("BossHurt");

        if (Hp <= 0)
        {
            bossDie.startDie();
        }
    }

    IEnumerator flashColor()
    {
        bossSprite.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        bossSprite.color = Color.white;
    }
}
