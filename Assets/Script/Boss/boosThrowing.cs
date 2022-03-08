using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boosThrowing : bossBehavior
{
    [Header("Throwing")]
    public Transform player;
    public float throwRange;
    //throwing
    public float minSpeed;
    public float maxSpeed;
    public Transform weightPototype;

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(player.position, new Vector3(throwRange, 2f));
    }

    private void Update()
    {
        timeNextAction -= Time.deltaTime;

        if(timeNextAction <= 0f)
        {
            randomNextTime();
            Throw();
        }
    }

    void Throw()
    {
        Transform weight = Instantiate(weightPototype, transform.position, Quaternion.identity);
        float speed = Random.Range(minSpeed, maxSpeed);

        weight.GetComponent<weight>().diration = getThrowDiraction();
        weight.GetComponent<weight>().speed = speed;
    }

    Vector2 getThrowDiraction()
    {
        float randdomPosX = Random.Range(-(player.position.x + (throwRange / 2)), (player.position.x + (throwRange / 2)));
        Vector3 result = new Vector3(randdomPosX, player.position.y) - transform.position;
        result = result.normalized;
        return result;
    }
}
