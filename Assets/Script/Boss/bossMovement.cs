using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMovement : bossBehavior
{
    [Header("Movement")]
    public float walkRange;
    public float smooth = 0.8f;

    private Vector2 destination;
    private Vector2 originPosition;

    public void OnDrawGizmosSelected()
    {
        Vector3 size = new Vector3(walkRange, 3f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
    }

    private void Start()
    {
        timeNextAction = maxCount;
        destination = transform.position;
        originPosition = transform.position;
    }

    public void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, destination) <= 0.5f)
        {
            onStand();
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, destination, smooth);
        }
    }

    void onStand()
    {
        timeNextAction -= Time.deltaTime;

        if(timeNextAction <= 0f)
        {
            randomDestination();
            randomNextTime();
        }
    }

    void randomDestination()
    {
        float newPosX = Random.Range(-(originPosition.x + (walkRange / 2)), (originPosition.x + (walkRange / 2)));
        destination = new Vector2(newPosX, transform.position.y);
    }
}
