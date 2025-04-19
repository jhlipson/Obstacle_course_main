using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public BadGuystate currentState;

    private void Start()
    {
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

    public void CheckState()
    {
        BadGuystate currentEnemyState = GetState();
        switch(currentEnemyState)
        {
            case BadGuystate.Idle:

                break;
            case BadGuystate.Detect:

                break;
            case BadGuystate.Follow:

                break;
            case BadGuystate.Attack:

                break;
            case BadGuystate.Dead:

                break;
        }
    }

}
