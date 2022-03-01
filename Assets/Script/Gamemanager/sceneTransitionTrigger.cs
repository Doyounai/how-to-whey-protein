using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneTransitionTrigger : MonoBehaviour
{
    public sceneTransitionManager _manager;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _manager.gameObject.SetActive(true);
            _manager.playTransition();
        }
    }
}
