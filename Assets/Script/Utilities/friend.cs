using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friend : MonoBehaviour
{
    [Header("Friend Idle")]
    public GameObject mFriend;
    public float frindIdleheight;
    public float friendIdleTime;

    [Header("Dialogue Scaling Animation")]
    public GameObject dialogue;
    public float scalingTime;
    public LeanTweenType scaleEase;

    LTDescr dialogueScaleId;
    Vector3 originScale;

    [Header("Dialogue Idle Animation")]
    public float idleTime;
    public float dialogueTo;
    public LeanTweenType dialogueEase;

    private void Start()
    {
        LeanTween.scale(mFriend, mFriend.transform.localScale + (Vector3.up * frindIdleheight), friendIdleTime).setLoopPingPong();

        Vector3 to = dialogue.transform.localPosition + new Vector3(0, dialogueTo, 0);
        LeanTween.moveLocal(dialogue, to, idleTime).setEase(dialogueEase).setLoopPingPong();

        originScale = dialogue.transform.localScale;
        dialogue.transform.localScale = Vector3.zero;
        hideDialogue();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueActive();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueInActive();
        }
    }

    void dialogueActive()
    {
        if (dialogueScaleId != null)
            LeanTween.cancel(dialogueScaleId.uniqueId);

        dialogue.gameObject.SetActive(true);
        dialogueScaleId = LeanTween.scale(dialogue, originScale, scalingTime).setEase(scaleEase);
    }
    
    void dialogueInActive()
    {
        if (dialogueScaleId != null)
            LeanTween.cancel(dialogueScaleId.uniqueId);

        dialogueScaleId = LeanTween.scale(dialogue, Vector3.zero, scalingTime).setEase(scaleEase).setOnComplete(hideDialogue);
    }

    void hideDialogue()
    {
        dialogue.SetActive(false);
    }
}
