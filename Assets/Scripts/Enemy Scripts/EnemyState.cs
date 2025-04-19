using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public BadGuystate currentState;
    Enemy enemy;
    private void Start()
    {
        enemy = GetComponent<Enemy>();  
        currentState = BadGuystate.Idle; 
    }

   
    public enum BadGuystate
    {
        Idle,
        Detect,
        Follow,
        Attack,
        Dead,
    }

    public BadGuystate GetState ()
    {
        return currentState;
    }

    public void SetState(BadGuystate newstate)
    { 
        currentState = newstate;    
    }


    public void CheckState()
    {
     
        switch(currentState)
        {
            case BadGuystate.Idle:
                enemy.walking(true);
                enemy.Follow(false);
                break;
            case BadGuystate.Detect:

                break;
            case BadGuystate.Follow:
                Debug.Log("is this being called");
                enemy.walking(false);
                enemy.Follow(true);
                break;
            case BadGuystate.Attack:

                break;
            case BadGuystate.Dead:

                break;
        }
    }

}
