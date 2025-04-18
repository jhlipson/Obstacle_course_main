using UnityEngine;

public class Weaponpickup : MonoBehaviour
{
    public GameObject Gun;
    public AudioSource fall;
    public AudioSource Equip;
    public bool isspecial;

    private void Start()
    {
        Equip = GameObject.Find("Equip Sound effect").GetComponent<AudioSource>();  
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameObject Weaponholder = GameObject.Find("WeaponHolder"); 
           
            
            if(Weaponholder != null) 
            {
                Gun.transform.SetParent(Weaponholder.transform);
                //setting the gun as a child of the weapon holder so we can access it.
                if(isspecial)
                {
                    fall.Play();
                } else
                {
                    fall = null;
                }
                Equip.Play();
                Destroy(gameObject);
            }
        }
    }
}
