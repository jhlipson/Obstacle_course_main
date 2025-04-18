using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public TextMeshProUGUI winnertext;
    Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<Player>();
        //We are only activating this when the Player isn't on. 
    }

    // Update is called once per frame
    void Update()
    {/*
        string minutes = Mathf.Floor(player.TimeinGame / 60).ToString("00");
        //Returns the largest interger smaller or equal to F. 
        //Attempting to access the time of spent in the game and show how long the scene has been going on for.
        string seconds = Mathf.Floor(player.TimeinGame % 60).ToString("00");
        winnertext.text = "Congratulations, you win! Press the space bar to get a better time " + minutes + ":" + seconds; 
        //entering the following string with .ToString's help to try and get a time for the player to chase after.
        if(Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("Main Scene");
            //Once again, we are accessing the scene management. 
            
        } */
    }
}
