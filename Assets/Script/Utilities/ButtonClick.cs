using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public void playSound()
    {
        sound.Instance.playSound("ButtonPress");
    }
}
