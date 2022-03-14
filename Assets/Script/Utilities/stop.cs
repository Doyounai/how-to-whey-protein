using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stop : MonoBehaviour
{
    public void releaseTime()
    {
        Time.timeScale = 1;
    }

    public void pasuse()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void unPasuse()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
