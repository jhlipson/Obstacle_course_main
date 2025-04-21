using UnityEditor.Timeline;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public BadGuystate currentState;
    public GameObject[] music;
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
                music[0].SetActive(true);
                music[1].SetActive(false);
                enemy.walking(true);
                Debug.Log("Walking Again");
                break;
            case BadGuystate.Detect:
                music[1].SetActive(true);
                music[0].SetActive(false);
                enemy.Detect(true);
                break;
            case BadGuystate.Follow:
                Debug.Log("is this being called");
                music[1].SetActive(true);
                music[0].SetActive(false);
                enemy.Follow(true);
                break;
            case BadGuystate.Attack:
                enemy.Shoot(true);
                music[1].SetActive(true);
                music[0].SetActive(false);
                break;
            case BadGuystate.Dead:
                enemy.Death(true);  
                break;
        }
    }

}
