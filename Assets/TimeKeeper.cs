using UnityEngine;

public class TimeKeeper : MonoBehaviour
{
    public float CurrentTime; // This will track the elapsed time

    private float startTime; // To track when the timer should start from 0

    void Start()
    {
        startTime = Time.time; // Record the time when the scene starts (or when you reset it)
    }

    void Update()
    {
        // Calculate the elapsed time based on when you reset it, starting from 0
        CurrentTime = Time.time - startTime;
    }

    // Method to reset the custom timer to 0
    public void Reset()
    {
        startTime = Time.time; // Reset the start time to the current time
        CurrentTime = 0f; // Reset the custom timer to 0
    }
}
