using UnityEngine;
using TMPro;
public class SubmachineGun : MonoBehaviour
{
    TextMeshProUGUI AmmoUI;
    public float speed = 10f;
    public Camera Fpscam;
    public float firerate = 20f;
    public float nextitmetofire = 0f;
    public GameObject bullet;
    public int damage = 8;
    public int ammo = 24;
    public Animator anim;
    public AudioSource shoot;
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
            if (Input.GetButton("Fire1") && Time.time >= nextitmetofire)
            {
                ammo -= 1;
                nextitmetofire = Time.time + 1f / firerate;
                Shoot();
                shoot.Play();
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

