using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class sceneTransitionManager : MonoBehaviour
{
    public PlayableDirector diredtor;
    public int sceneToGo = 0;

    public void playTransition()
    {
        diredtor.Play();    
    }
    
    public void disblePlayerControl()
    {
        playerController player = FindObjectOfType<playerController>();

        if (player != null)
            player.isCanController = false;
    }

    public void goToScene()
    {
        SceneManager.LoadScene(sceneToGo);
    }
}
