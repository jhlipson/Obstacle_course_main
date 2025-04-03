using UnityEngine;
public class Animations : MonoBehaviour
{
    public Animator anim;
    Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<Player>(); // Get the player script so we don't have to put it there ourselves. Be lazy, be better.
    }

    // Update is called once per frame
    void Update()
    {
        if(player.enabled == false) // If the player is not there, then the animator will default to the Idle animation for the end of the game.
        {
            Run(false); // We are accessing all of these and turning them on and off via the Player Script.
            Jump(false);
            jogging(false);
            Dashing(false);
        }
    }

    public void Run(bool isrunning)
    {
        if(isrunning)
        {
            
            anim.SetBool("isRunning", true);
           
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    public void Jump(bool isjumping)
    {
        if(isjumping)
        {
            
         
            
            anim.SetBool("isJumping", true);
        } else
        {
            anim.SetBool("isJumping", false);
        }
    }

    public void jogging (bool isjogging)
    {
        if (isjogging)
        {
         
            anim.SetBool("isJogging", true);
                
        } else
        {
            anim.SetBool("isJogging", false);
        }
    }

    public void Dashing(bool isDashing)
    {
        if(isDashing)
        {
            
            anim.SetBool("isDashing", true);    
        } else
        {
            anim.SetBool("isDashing", false);
        }
    }
        
}
