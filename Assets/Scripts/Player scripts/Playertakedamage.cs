using UnityEngine;

public class Playertakedamage : MonoBehaviour
{
    Player player;

    private void Start()
    {
        player = GetComponentInParent<Player>();
    }

 
    public void Damagedealt (float damage)
        { player.currentHP -= damage; }
}
