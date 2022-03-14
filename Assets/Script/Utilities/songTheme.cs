using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class songTheme : MonoBehaviour
{
    public string name;

    private void Start()
    {
        sound.Instance.stopSong();
        sound.Instance.playSong(name);
    }
}
