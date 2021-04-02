using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    public Camera cam;
    public GameObject Player;

    public bool followPlayer = true;

    public float spawnTimer = 10f;
    public float spawnAmount = 25f;
    public float amountSpawned;

    public static RaycastHit hitSpot;

    public GameObject monster;
    public NavMeshAgent agent;

    public static float monsterSpawn = 1;

    private void Start()
    {
        if(monsterSpawn == 1)
        {
            StartCoroutine(SpawnMonster(spawnTimer));
            monsterSpawn++;
        }
    }

    void Update()
    {
        agent.SetDestination(Player.transform.position);
        //commented code below is for Q to move the beans around, but it's broken try to fix later.
        /*
        if (followPlayer == true)
        {
            agent.SetDestination(Player.transform.position);
        }
        */
        /*
        if (Input.GetKeyDown("q"))
        {            
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                hitSpot = hit;
                agent.SetDestination(hit.point);
            }
            followPlayer = !followPlayer;
        }
        */
    }

    IEnumerator SpawnMonster(float secs)
    {
        yield return new WaitForSeconds(secs);
        var position = new Vector3(Random.Range(-20f, 12f), 1.88f, Random.Range(-31f, -28f));
        Instantiate(monster, position, Quaternion.identity);
        if (spawnAmount >= amountSpawned)
        {
            amountSpawned++;
            StartCoroutine(SpawnMonster(spawnTimer));
        }
    }
}
