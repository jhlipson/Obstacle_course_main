using UnityEngine;
using TMPro;
public class Shotgun : MonoBehaviour
{
    TextMeshProUGUI AmmoUI;
    public float speed = 10f;
    public Camera Fpscam;
    
    public float firerate = 1f;
    public float nextTimeToFire = 0f;
    public GameObject pelletPrefab;
    public int ammo = 8;
    public int pelletsPerShot = 8;
    public float spreadAngle = 15f;
    public Animator anim;
    public AudioSource shoot;


    void Start()
    {

        GameObject ammoTextObj = GameObject.Find("Ammo_Text");

        // Check if the GameObject was found
        if (ammoTextObj != null)
        {
            AmmoUI = ammoTextObj.GetComponent<TextMeshProUGUI>();
            if (AmmoUI != null)
            {
                // Initialize the ammo UI text
                string ammocount = ammo.ToString();
                AmmoUI.text = "Ammo " + ammocount;
            }
        }

    }
    void Update()
    {
        string ammocount = ammo.ToString();
        AmmoUI.text = "Ammo " + ammocount;
        if (ammo > 0)
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
            {
                ammo -= 1;
                nextTimeToFire = Time.time + 1f / firerate;
                anim.SetBool("Firing", true);
                shoot.Play();
                Shoot();
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                anim.SetBool("Firing", false);
            }
        }
        else
        {
            anim.SetBool("Firing", false);
        }
        
    }



    void Shoot()
    {
        Debug.Log($"Ammo count: {ammo}");

        // Loop through the number of pellets to fire
        for (int i = 0; i < pelletsPerShot; i++)
        {
            // Calculate random spread for each pellet
            float spreadX = Random.Range(-spreadAngle, spreadAngle);
            float spreadY = Random.Range(-spreadAngle, spreadAngle);
            Quaternion pelletRotation = Fpscam.transform.rotation * Quaternion.Euler(spreadX, spreadY, 0);

            // Position the pellet slightly in front of the player
            Vector3 pelletSpawnPosition = Fpscam.transform.position + Fpscam.transform.forward * 0.5f; // 0.5f is a small offset to spawn the pellet slightly in front of the camera

            // Create the pellet and fire it
            GameObject pelletInstance = Instantiate(pelletPrefab, pelletSpawnPosition, pelletRotation);

            // Ensure the pellet has a Rigidbody and apply force to move it
            Rigidbody rb = pelletInstance.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(pelletInstance.transform.forward * speed, ForceMode.Impulse);
            }


            Destroy(pelletInstance, 2f); // Destroy pellet after 2 seconds
        }
    }
}
