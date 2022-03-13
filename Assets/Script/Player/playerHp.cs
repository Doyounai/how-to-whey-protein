using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHp : MonoBehaviour
{
    public SpriteRenderer playerSprite;
    public Color damgeColor;
    public int hp = 3;
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

        if (hp <= 1)
        {
            //die
        }
    }

    public IEnumerator flashColor()
    {
        playerSprite.color = damgeColor;
        yield return  new WaitForSeconds(0.3f);
        playerSprite.color = Color.white;
    }
}
