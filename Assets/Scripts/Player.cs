using UnityEngine;
using System.Collections;
using System.Collections.Generic;  // Fixed the typo
public class Player : MonoBehaviour
{
    PlayerAction pa;
    CharacterController cc;
   public GameObject lol; // game over baby
   public healthbar health;
    public float speed = 1f;
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

    bool godmode;

    [SerializeField] float iFrames;
    float iFrameCounter;

    void Start()
    {
        Cursor.visible = false;

        pa = GetComponent<PlayerAction>();
        cc = GetComponent<CharacterController>();
        _cam = GetComponentInChildren<Camera>();
      
        currentHP = HP;
        health.SetMaxHealth(HP);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Insert))
        {
            godmode = !godmode;
        }
        if(godmode)
        {
            currentHP = HP; 
        } 
        health.SetHealth(currentHP);
        // If the player is dashing, handle dash logic
        if (!isDashing)
        {
            ManageMovement();
        }
        else
        {
            // Dash movement: move the player in the direction they're facing with speed multiplied by dash multiplier
            Vector3 dashDirection = transform.forward * dashValue; // Dash in the direction the player is facing
            cc.Move(dashDirection * speed * dashMulti * Time.deltaTime);

            timeInDash += Time.deltaTime;

            if (timeInDash >= dashTime)
            {
                isDashing = false;
             
                timeInDash = 0;   
            }
        }
        if(currentHP <= 0)
        {
            isalive = false;
            Debug.Log("You died, LOL");
        }
        if (!isalive)
        {
            lol.gameObject.SetActive(true);
        }
    }

    void ManageMovement()
    {
        Vector3 move = pa.GetMoveDirection();
        float extraSpeed = 0f;

        // Handle sprinting logic
        if (pa.IsSprinting())
        {
            extraSpeed = 8f;
        }

        // Jump logic
        if (cc.isGrounded)
        {
            // Reset vertical velocity when grounded
            velocity.y = -2f; // Small negative value to keep the player grounded
            DashCooldownTime += Time.time;
            jumpCount = 2;
            hasDashedInAir = false;
        } 

        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            velocity.y = Mathf.Sqrt(jumpforce * -2f * gravity); // Jump logic
            jumpCount -= 1;
        }
        else
        {
            // Apply gravity when in the air
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
        cc.Move(move * (speed + extraSpeed) * Time.deltaTime);

      

        // Check for dash input (Right Shift key)
        DashChecker(move);
    }

    private void DashChecker(Vector3 moveDirection)
    {
        if (Input.GetMouseButtonDown(1)|| Input.GetButtonDown("Fire2") && cc.isGrounded)
        {
            isDashing = true;
           if(DashCooldownTime > DashCooldown)
            {
                dashValue = moveDirection.magnitude > 0 ? 1 : 0; // Start dash if the player is moving, otherwise set dash to 0
                
            }
        } else if (Input.GetMouseButtonDown(1) || Input.GetButtonDown("Fire2") && !cc.isGrounded && !hasDashedInAir)
        {
            if (DashCooldownTime > DashCooldown)
            {
                isDashing = true;
                dashValue = moveDirection.magnitude > 0 ? 1 : 0; // Start dash if the player is moving, otherwise set dash to 0
                hasDashedInAir = true; 
            }
        }
    }

   
}
