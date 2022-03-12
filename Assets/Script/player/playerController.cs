using UnityEngine;

/*  =====================================================
*
*                       _oo0oo_
*                      o8888888o
*                      88" . "88
*                      (| -_- |)
*                      0\  =  /0
*                    ___/`---'\___
*                  .' \|     |// '.
*                 / \|||  :  |||// \
*                / _||||| -:- |||||- \
*               |   | \\  -  /// |   |
*               | \_|  ''\---/''  |_/ |
*               \  .-\__  '-'  ___/-. /
*             ___'. .'  /--.--\  `. .'___
*          ."" '<  `.___\_<|>_/___.' >' "".
*         | | :  `- \`.;`\ _ /`;.`/ - ` : | |
*         \  \ `_.   \_ __\ /__ _/   .-` /  /
*     =====`-.____`.___ \_____/___.-`___.-'=====
*                       `=---='
*
*     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
*
*               Buddha Bless:  "No Bugs"
*
*/

public class playerController : MonoBehaviour
{
    enum swingStage
    {
        none,
        left,
        right
    }

    [HideInInspector]
    public bool isCanController = true;

    [Header("Player")]
    public float speed = 10f;
    public buttonInput leftMoveButton;
    public buttonInput rightMoveButton;

    [Header("Swing Input")]
    public float minSwing = -0.1f;
    public float maxSwing = 0.1f;
    public bool isPc = false;

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
        if (!isCanController)
            return;

        checkGroundSpoon();
        movementController();
        swingController();
    }

    void checkGroundSpoon()
    {
        if (isSwing)
            return;

        if(spoonGround.isGround)
        {
            if (spoonPivot.position.x < transform.position.x && getCurrentSwing(getSwingForce()) == swingStage.left)
            {

                target = playerRb;
                rotateOriginTransform = spoonPivot;
                isSwing = true;
            }
            if (spoonPivot.position.x > transform.position.x && getCurrentSwing(getSwingForce()) == swingStage.right)
            {
                target = playerRb;
                rotateOriginTransform = spoonPivot;
                isSwing = true;
            }
        }
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
    swingStage getCurrentSwing(float accX)
    {
        //float accX = Input.acceleration.x;
        if (accX < minSwing)
            return swingStage.left;
        else if (accX > maxSwing)
            return swingStage.right;

        return swingStage.none;
    }

    float getSwingForce()
    {
        //float pcForce = 5;
        //
        //if (isPc)
        //    if (Input.GetKey(KeyCode.LeftArrow))
        //        return -1 * pcForce;
        //    else if (Input.GetKey(KeyCode.RightArrow))
        //        return 1 * pcForce;
        //    else
        //        return 0;

        if (isPc)
        {
            float screenCenter = Screen.width / 2;
            float mousePosX = Input.mousePosition.x;

            return (mousePosX - screenCenter) / 90;
        }

        return (Input.acceleration.x * 10);
    }
    #endregion
    #region groundCheck
    public void onPlayerHitGround()
    {
        //if (!isSwing)
        //    return;
        target = spoonRb;
        rotateOriginTransform = transform;
        isSwing = false;

        //if (transform.position.x < spoonPivot.position.x && getCurrentSwing(getSwingForce()) == swingStage.left)
        //{
        //    target = spoonRb;
        //    rotateOriginTransform = transform;
        //    isSwing = false;
        //}
        //if (transform.position.x > spoonPivot.position.x && getCurrentSwing(getSwingForce()) == swingStage.right)
        //{
        //    target = spoonRb;
        //    rotateOriginTransform = transform;
        //    isSwing = false;
        //}
    }
    public void onSpoonHitGround()
    {
        if(spoonPivot.position.x < transform.position.x && getCurrentSwing(getSwingForce()) == swingStage.left)
        {
            target = playerRb;
            rotateOriginTransform = spoonPivot;
            isSwing = true;
        }
        if(spoonPivot.position.x > transform.position.x && getCurrentSwing(getSwingForce()) == swingStage.right)
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
