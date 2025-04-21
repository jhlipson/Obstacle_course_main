using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{

    public bool Secondlevel;
    public bool firstlevel;

    // Update is called once per frame
    void Update()
    {
        if (firstlevel)
        {
            if (Input.GetButtonDown("Jump"))
            {
                SceneManager.LoadScene("Main scene"); // get to the main scene. This is only active in the game over scene.
            }
        }
        else if (Secondlevel)
        {
            if (Input.GetButtonDown("Jump"))
            {
                SceneManager.LoadScene("Shoot");
            }
        }
       
    }
}
