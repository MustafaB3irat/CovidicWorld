using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Player Movement
    public float moveSpeed = 10f;
    public float runSpeed = 16f;
    public CharacterController controller;
    public Animator animator;

    //Gravity
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;

    // Jump
    public float jumpHeight = 3f;

    // Update is called once per frame
    void Update()
    {
        checkGrounded();
        movePlayer();
        detectJump();
    }

    void movePlayer()
    {
        float h = Input.GetAxis("Horizontal");
        float f = Input.GetAxis("Vertical");
        float speed = moveSpeed;
       // bool isWalking  = animator.GetBool()

        //setting movement animation dpending on user input
        if (f > 0)
        {
            triggerAnimation("isWalkingForward", true);
        } else
        {
            triggerAnimation("isWalkingForward", false);
        }

        
        if (f < 0)
        {
            triggerAnimation("isWalkingBack", true);
        } else
        {
            triggerAnimation("isWalkingBack", false);
        }



        if (h > 0)
        {
            triggerAnimation("isWalkingRight", true);
        }
        else
        {
            triggerAnimation("isWalkingRight", false);
        }

        if (h < 0)
        {
            triggerAnimation("isWalkingLeft", true);
        }
        else
        {
            triggerAnimation("isWalkingLeft", false);
        }


        if (Input.GetKeyDown(KeyCode.LeftShift) && f > 0)
        {
            speed = runSpeed;
            triggerAnimation("isRunning", true);
        } else 
        {
            triggerAnimation("isRunning", false);
            speed = moveSpeed;
        }

        Vector3 move = transform.right * h + transform.forward * f;

        // get a normal for the surface that is being touched to move along it
        RaycastHit hitInfo;
        Physics.SphereCast(transform.position, controller.radius, Vector3.down, out hitInfo,
                           controller.height / 2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);
        move = Vector3.ProjectOnPlane(move, hitInfo.normal).normalized;

        controller.Move(move * Time.deltaTime * speed);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void checkGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    void detectJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            triggerAnimation("jump", true);
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        } else
        {
            triggerAnimation("jump", false);
        }
    }

    void triggerAnimation(string animationTransitionParameter ,bool isWalkling)
    {
        animator.SetBool(animationTransitionParameter, isWalkling);
    }
}
