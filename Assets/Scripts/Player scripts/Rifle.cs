using UnityEngine;
using TMPro;
public class Rifle : MonoBehaviour
{ 
    TextMeshProUGUI AmmoUI;
    public float speed = 10f;
    public Camera Fpscam;
    public float firerate = 0.5f;
    public float nextitmetofire = 0f;
    public GameObject bullet;
    public int damage = 50;
    public int ammo = 7;
    public Animator anim;
    public AudioSource shoot; // all gun audio is taken from Pixabay
                              // Update is called once per frame

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
            if (Input.GetButtonDown("Fire1") && Time.time >= nextitmetofire)
            {
                ammo -= 1;
                nextitmetofire = Time.time + 1f / firerate;
                shoot.Play();
                Shoot();
                anim.SetBool("Firing", true);
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

        Debug.Log($"ammo count {ammo}");
        RaycastHit hit;
        if (Physics.Raycast(Fpscam.transform.position, Fpscam.transform.forward, out hit))
        {
            EnemyTakeDamage target = hit.transform.GetComponent<EnemyTakeDamage>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject Bullet = Instantiate(bullet, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(Bullet, 2f);

        }
    }
}
