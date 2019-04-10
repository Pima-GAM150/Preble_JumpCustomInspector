using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGraph : MonoBehaviour
{

    public GameObject playerCharacter;
    Rigidbody playerRigidbody;

    #region Jump Info

    [SerializeField]
    private int jumpTimer = 0;
    [SerializeField]
    private bool isAirborne;
    [SerializeField]
    private bool isGrounded;
    [SerializeField]
    private RaycastHit hit;
    public float gravityForce;
    public float upwardForce;
    public float timerLimit;
    //public float jumpArchForce;

    Vector3 jump;
    Vector3 gravity;
    Vector3 unGravity;

    #endregion

    public static AnimationCurve jumpCurve;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = playerCharacter.GetComponent<Rigidbody>();
        jump = new Vector3(0, upwardForce, 0);
        gravity = new Vector3(0, gravityForce, 0);
        unGravity = new Vector3(0, 0, 0);
        isAirborne = false;
        playerRigidbody.velocity = gravity;
    }

    // Update is called once per frame
    void Update()
    {
        CheckAirborne(isAirborne);
        CheckGrounded();
        if (isAirborne)
        {
            isGrounded = false;
        }
        if (isGrounded)
        {
            playerRigidbody.velocity = unGravity;
            jumpTimer = 0;
        }
        if (!isAirborne && jumpTimer < timerLimit)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                playerRigidbody.velocity = jump;
                Debug.Log("Upward Force is: " + upwardForce.ToString());
            }
        }
        else if (!isGrounded && jumpTimer >= timerLimit)
        {
            playerRigidbody.velocity = gravity;
            Debug.Log("Gravity is: " + gravityForce.ToString());
        }
        if (isAirborne)
        {
            jumpTimer++;
        }
        //jumpArchForce = playerRigidbody.velocity.y;
    }

    /*void Jump()
    {
        playerRigidbody.velocity = jump;
        jumpTimer++;
    }*/

    bool CheckAirborne(bool airborneBool)
    {
        if (playerRigidbody.velocity.y != 0)
        {
            isAirborne = true;
        }
        else
        {
            isAirborne = false;
        }
        return isAirborne;
    }

    void CheckGrounded()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f))
        {
            //Debug.Log("Touching ground");
            if (hit.transform.position.y < playerRigidbody.transform.position.y)
            {
                //Debug.Log("Player is grounded");
                isGrounded = true;
            }
        }
    }
}
