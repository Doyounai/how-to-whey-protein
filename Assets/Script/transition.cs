using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transition : MonoBehaviour
{
    int sceneIndex;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void startFade(int index)
    {
        sceneIndex = index;
        animator.SetTrigger("fade");
    }

    public void gotoScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void gotoScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
