using UnityEngine;
using System.Collections;
using System.Collections.Generic;  // Fixed the typo

public class BurningMode : MonoBehaviour
{
    public bool isBurningModeActive = false;

    public Pistol pistol;
    public Player player;
    PlayerAction _action;
    public Shotgun shotgun;
    public Rifle rifle;
    public SubmachineGun submachinegun;
    public Bullet pellet;
    public Minigun minigun;
    public Bazooka bazooka;
    private float timeBetweenToggles = 0.2f;
    private float lastToggleTime;
    public float burnDamageInterval = 5f;  // How often health decreases
    public float burnDamageAmount = 5f;    // How much health decreases every interval
    private Coroutine burnHealthCoroutine;
    public float stop = 1f;

    void Start()
    {
        player = GetComponent<Player>();    
        _action = GetComponent<PlayerAction>();
      
    }

    void Update()
    {
        if (_action.IsInteracting() && Time.time - lastToggleTime >= timeBetweenToggles)
        {
            ToggleBurningMode();
            lastToggleTime = Time.time;
        }
        if(player.currentHP < stop)
        {
            DeactivateBurningMode();
        }
    }

    void ToggleBurningMode()
    {
        isBurningModeActive = !isBurningModeActive; // Toggle the activation of Burning Mode

        if (isBurningModeActive && player.currentHP > stop)
        {
            ActivateBurningMode();
        }
        else
        {
            DeactivateBurningMode();
        }
    }

    void ActivateBurningMode()
    {
       
        // Adjust player attributes for Burning Mode
        player.speed = 14f;
        player.dashMulti = 18f;
        pistol.damage = 20;
        pistol.firerate = 30f;
        submachinegun.damage = 16;
        submachinegun.firerate = 15f;
        shotgun.pelletsPerShot = 16;
        shotgun.firerate = 2f;
        pellet.damage = 20;
        minigun.damage = 30;
        minigun.firerate = 40f;
        rifle.damage = 70;
        rifle.firerate = 2;
        bazooka.firerate = 2;


        // Start depleting health over time
        if (burnHealthCoroutine == null)
        {
            burnHealthCoroutine = StartCoroutine(DepleteHealthOverTime());
        }

        Debug.Log("Burning mode is active");
    }

    void DeactivateBurningMode()
    {
        // Reset player attributes to normal
        player.speed = 6f;
        player.dashMulti = 10f;
        pistol.damage = 10;
        pistol.firerate = 15f;
        submachinegun.damage = 8;
        submachinegun.firerate = 15f;
        shotgun.pelletsPerShot = 8;
        shotgun.firerate = 1f;
        pellet.damage = 10;
        minigun.damage = 15;
        minigun.firerate = 30f;
        rifle.firerate = 1f;
        rifle.damage = 50;
        bazooka.firerate = 1f;

        // Stop depleting health if Burning Mode is deactivated
        if (burnHealthCoroutine != null)
        {
            StopCoroutine(burnHealthCoroutine);
            burnHealthCoroutine = null;
        }

        Debug.Log("Burning mode is not active");
    }

    IEnumerator DepleteHealthOverTime()
    {
        while (isBurningModeActive)
        {
            // Reduce the player's health while burning mode is active
            player.currentHP -= burnDamageAmount;

            // If health reaches 0 or below, you could stop or handle player death
            if (player.currentHP <= 0)
            {
                player.currentHP = 0;
                Debug.Log("Player has died due to burning damage.");
                // Optionally, handle player death logic here
                break; // Exit the loop when player dies
            }

            yield return new WaitForSeconds(burnDamageInterval);  // Wait for the next interval before reducing health again
        }
    }
}
