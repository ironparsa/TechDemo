using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    public Camera cam;
    public GameObject Player;

    public bool followPlayer = true;

    public NavMeshAgent agent;

    void Update()
    {
        if (followPlayer == true)
        {
            agent.SetDestination(Player.transform.position);
        }

        if (Input.GetKeyDown("q"))
        {
            followPlayer = !followPlayer;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //move monster
                agent.SetDestination(hit.point);
            }
        }
    }
}
