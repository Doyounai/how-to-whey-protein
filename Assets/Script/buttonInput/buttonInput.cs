using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttonInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isDown = false;

    public bool isButtonDown { get { return isDown; } }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDown = false;
    }
}
