using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpJump : MonoBehaviour
{
    public GameObject FirstPersonPlayer;
    private PlayerMovement PlayerInfo;

    private void Start()
    {
        PlayerInfo = FirstPersonPlayer.GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            JumpNumberIncrease();
        }

    }
    private void JumpNumberIncrease()
    {
        PlayerInfo.timesJumped--;
        Debug.Log(PlayerInfo.timesJumped);
    }
}
