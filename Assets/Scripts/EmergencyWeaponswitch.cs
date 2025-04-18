using UnityEngine;

public class EmergencyWeaponswitch : MonoBehaviour
{
    public GameObject Pistol;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Pistol.SetActive(true);
        }
    }
}
