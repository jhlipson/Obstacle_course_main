using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    Animations An;
    PlayerAction pa;
    public CharacterController cc;
    public healthbar health;
    public float speed = 1f;
    public float TimeinGame = 0f;
    public AnimationCurve curve;
    float counter;
    Camera _cam;
    public float jumpforce = 5f; // Jump force
    public float gravity = -9.81f; // Gravity value
    private int jumpCount = 2;
    private Vector3 velocity = Vector3.zero;
    bool isDashing;
    public float dashMulti = 2f; // Dash multiplier
    int dashValue;
    public float dashTime = 0.4f; // Duration of dash
    float timeInDash;
    public float DashCooldown = 1f;
    private float DashCooldownTime = 0f;
    public bool hasDashedInAir = false;
    public float HP = 100f;
    public float currentHP;
    bool isalive = true;
    public PlayerState state;
    public enum PlayerState
    {
        Idle,
        Jumping,
        Running,
        Walking,
        Dashing,
        Dead
    }

    void Start()
    {
        An = FindFirstObjectByType<Animations>(); // automatically assign the animator even if it is not attachec to our gameobject.
        pa = GetComponent<PlayerAction>();
        cc = GetComponent<CharacterController>();
        _cam = GetComponentInChildren<Camera>();
        state = PlayerState.Idle;
        currentHP = HP;
        health.SetMaxHealth(HP);
    }

    void Update()
    {
        TimeinGame = Time.time;
        health.SetHealth(currentHP);
        // If the player is dashing, handle dash logic
        if (!isDashing)
        {
            ManageMovement();
        }
        else
        {

            Vector3 dashDirection = transform.forward * dashValue; // Dash in the direction the player is facing
            cc.Move(dashDirection * speed * dashMulti * Time.deltaTime); // evaluating ou

            timeInDash += Time.deltaTime;

            if (timeInDash >= dashTime)
            {
                isDashing = false;

                timeInDash = 0;
            }
        }
        if (currentHP <= 0)
        {
            isalive = false;
            Debug.Log("You died, LOL");
        }
        if (!isalive)
        {
            state = PlayerState.Dead;
        }
        Check();
    }

    void ManageMovement()
    {
        Vector3 move = pa.GetMoveDirection();
        float extraSpeed = 0f;


        if (cc.isGrounded && pa.IsSprinting())
        {
            
            velocity.y = -2f; // Small negative value to keep the player grounded
            DashCooldownTime += Time.time;
            jumpCount = 2;
            hasDashedInAir = false;
            extraSpeed = 8f;
        } else if(!cc.isGrounded && pa.IsSprinting())
        {
            state = PlayerState.Jumping;
        }  
        


        if (cc.isGrounded && !pa.IsMoving())
        {
            state = PlayerState.Idle;
            // Reset vertical velocity when grounded
            velocity.y = -2f; // Small negative value to keep the player grounded
            DashCooldownTime += Time.time;
            jumpCount = 2;
            hasDashedInAir = false;
    

        }
        else if (cc.isGrounded && pa.IsMoving())
        {
            state = PlayerState.Walking;
            if (pa.IsSprinting())
            {
                state = PlayerState.Running;
            }
                // Reset vertical velocity when grounded
                velocity.y = -2f; // Small negative value to keep the player grounded
            DashCooldownTime += Time.time;
            jumpCount = 2;
            hasDashedInAir = false;
        }

        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            velocity.y = Mathf.Sqrt(jumpforce * -2f * gravity); // Jump logic
            state = PlayerState.Jumping;
            jumpCount -= 1;
        }
        else
        {
            
            velocity.y += gravity * Time.deltaTime;
        }

        // Rotation logic
        Vector3 rot = pa.GetLookRotation();
        transform.Rotate(0, rot.y, 0); // Rotate player around Y-axis
        Quaternion initialCamRot = _cam.transform.rotation;
        _cam.transform.Rotate(rot.x, 0, 0); // Camera pitch

        // Prevent camera from rotating too far from the player’s forward direction
        float angle = Vector3.Angle(transform.forward, _cam.transform.forward);
        if (angle > 75f)
        {
            _cam.transform.rotation = initialCamRot;
        }

        // Combine the horizontal movement and vertical velocity (jump/gravity)
        move = transform.rotation * move; // Apply player rotation to movement
        move.y = velocity.y;

        // Apply movement
        //Debug.Log(move * (speed + extraSpeed) * Time.deltaTime);
        cc.Move(move * (speed + extraSpeed) * Time.deltaTime);



        // Check for dash input (Right Shift key)
        DashChecker(move);
    }

    private void DashChecker(Vector3 moveDirection)
    {
       // state = PlayerState.Dashing;
        if (Input.GetMouseButtonDown(1) && cc.isGrounded)
        {
            state = PlayerState.Dashing;
            isDashing = true;
            if (DashCooldownTime > DashCooldown)
            {
                dashValue = moveDirection.magnitude > 0 ? 1 : 0; // Start dash if the player is moving, otherwise set dash to 0

            }
        }
        else if (Input.GetMouseButtonDown(1) && !cc.isGrounded && !hasDashedInAir)
        {
            state = PlayerState.Dashing;
            if (DashCooldownTime > DashCooldown)
            {
                isDashing = true;
                dashValue = moveDirection.magnitude > 0 ? 1 : 0; // Start dash if the player is moving, otherwise set dash to 0
                hasDashedInAir = true;
            }
        }
    }

    PlayerState GetState()
    {
        return state;
    }
    void Check()
    {
        PlayerState currentPlayerState = GetState();
        switch (currentPlayerState)
        {
            case PlayerState.Idle:
                An.Run(false); //we are turning on and off animations as per state.
                An.Jump(false);
                An.jogging(false);
                An.Dashing(false);
                Debug.Log("we be idle");
                break;
            case PlayerState.Running:
                An.Jump(false);
                An.jogging(false);
                An.Dashing(false);
                An.Run(true);
                break;
            case PlayerState.Jumping:
                An.jogging(false);
                An.Run(false);
                An.Dashing(false); 
                An.Jump(true);
                //code
                break;
            case PlayerState.Walking:
                An.Jump(false);
                An.Run(false);
                An.Dashing(false);
                An.jogging(true);
                break;
            case PlayerState.Dashing:
                An.Run(false);
                An.Jump(false);
                An.jogging(false);
                An.Dashing(true);
                break;
            case PlayerState.Dead:
                SceneManager.LoadScene("GAME OVER");
                break;
            default:
                //code
                break;

        }
    }



}
