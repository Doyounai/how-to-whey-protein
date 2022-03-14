using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour
{
    public string soundName;

    public void play()
    {
        sound.Instance.playSound(soundName);
    }
}
