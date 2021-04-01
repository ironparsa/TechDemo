using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDash : MonoBehaviour
{
    public GameObject FirstPersonPlayer;
    private PlayerMovement PlayerInfo;

    private void Start()
    {
        PlayerInfo = FirstPersonPlayer.GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            DashNumberIncrease();
        }
    }

    private void DashNumberIncrease()
    {
        PlayerInfo.dashCount--;
        Debug.Log(PlayerInfo.dashCount);
    }
}
