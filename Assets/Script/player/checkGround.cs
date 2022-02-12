using UnityEngine.Events;
using UnityEngine;

public class checkGround : MonoBehaviour
{
    public UnityEvent onGroundAction;
    public bool isGround = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGround = true;
            onGroundAction.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGround = false;
        }
    }
}
