using UnityEngine;

public class playerController : MonoBehaviour
{
    enum swingStage
    {
        none,
        left,
        right
    }

    [Header("Player")]
    public float speed = 10f;
    public buttonInput leftMoveButton;
    public buttonInput rightMoveButton;

    [Header("Swing Input")]
    public float minSwing = -0.1f;
    public float maxSwing = 0.1f;

    [Header("Swing")]
    public float swingForce = 10f;
    public Transform spoonPivot;
    public bool isSwing = false;
    Rigidbody2D playerRb;
    Rigidbody2D spoonRb;
    checkGround spoonGround;
    checkGround playerGround;
    Rigidbody2D target;
    Transform rotateOriginTransform;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        spoonRb = spoonPivot.GetComponent<Rigidbody2D>();

        playerGround = GetComponent<checkGround>();
        spoonGround = spoonPivot.GetComponent<checkGround>();

        target = spoonRb;
        rotateOriginTransform = transform;
    }

    private void FixedUpdate()
    {
        movementController();
        swingController();
    }

    void swingController()
    {
        rotateRigidBodyAroundPointBy(target, rotateOriginTransform.position, new Vector3(0, 0, 1), -getSwingForce());
    }
    void movementController()
    {
        if (!playerGround.isGround)
        {
            return;
        }

        if (Input.GetKey(KeyCode.A) || leftMoveButton.isButtonDown)
        {
            playerRb.MovePosition(playerRb.position + new Vector2(-1, 0) * speed * Time.fixedDeltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || rightMoveButton.isButtonDown)
        {
            playerRb.MovePosition(playerRb.position + new Vector2(1, 0) * speed * Time.fixedDeltaTime);
        }
    }

    #region swing function
    swingStage getCurrentSwing()
    {
        float accX = Input.acceleration.x;
        if (accX <= minSwing)
            return swingStage.left;
        else if (accX >= maxSwing)
            return swingStage.right;

        return swingStage.none;
    }

    float getSwingForce()
    {
        return (Input.acceleration.x * 10);
    }
    public void onPlayerHitGround()
    {
        if (!isSwing)
            return;

        if (transform.position.x < spoonPivot.position.x && getCurrentSwing() == swingStage.left)
        {
            target = spoonRb;
            rotateOriginTransform = transform;
            isSwing = false;
        }
        if (transform.position.x > spoonPivot.position.x && getCurrentSwing() == swingStage.right)
        {
            target = spoonRb;
            rotateOriginTransform = transform;
            isSwing = false;
        }
    }
    public void onSpoonHitGround()
    {
        if(spoonPivot.position.x < transform.position.x && getCurrentSwing() == swingStage.left)
        {
            target = playerRb;
            rotateOriginTransform = spoonPivot;
            isSwing = true;
        }
        if(spoonPivot.position.x > transform.position.x && getCurrentSwing() == swingStage.right)
        {
            target = playerRb;
            rotateOriginTransform = spoonPivot;
            isSwing = true;
        }
    }
    #endregion
    #region rotateFunction
    public void rotateRigidBodyAroundPointBy(Rigidbody2D rb, Vector3 origin, Vector3 axis, float angle)
    {
        Quaternion q = Quaternion.AngleAxis(angle, axis);
        rb.MovePosition(q * (rb.transform.position - origin) + origin);
        rb.MoveRotation(rb.transform.rotation * q);
    }
    #endregion

}
