using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transition : MonoBehaviour
{
    public static transition Instance;

    public float animationTime;
    public LeanTweenType easeType;

    int sceneIndex;
    //Animator animator;

    RectTransform rect;

    private void Start()
    {
        Instance = this;
        //animator = GetComponent<Animator>();

        rect = GetComponent<RectTransform>();
        //setFullScreenTransition();
        Vector2 to = new Vector2(Screen.width + (rect.sizeDelta.x / 2), rect.sizeDelta.y / 2);
        LeanTween.moveLocal(gameObject, to, animationTime)
            .setEase(easeType);
    }

    void setFullScreenTransition()
    {
        rect.sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    public void startFade(int index)
    {
        sceneIndex = index;
        //animator.SetTrigger("fade");

        transform.localPosition = new Vector2(-(Screen.width), rect.sizeDelta.y / 2);
        LeanTween.moveLocal(gameObject, Vector3.zero, animationTime)
           .setEase(easeType).setOnComplete(gotoScene);
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
