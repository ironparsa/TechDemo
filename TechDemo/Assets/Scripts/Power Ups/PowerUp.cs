using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject FirstPersonPlayer;
    public static PlayerMovement PlayerInfo;

    private void Start()
    {
        PlayerInfo = FirstPersonPlayer.GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PowerUpSelector(gameObject);
        }        
    }

    // All powerups are found here.
    public static void PowerUpSelector(GameObject PowerUpObject)
    {
        // Additional Jump GameObject powerup
        if(PowerUpObject.name == "Additional Jump")
        {
            PlayerInfo.timesJumped--;
            Destroy(PowerUpObject);
        }
        // Additional Dash GameObject powerup
        if (PowerUpObject.name == "Additional Dash")
        {
            PlayerInfo.dashCount--;
            Destroy(PowerUpObject);
        }
        
    }
}
