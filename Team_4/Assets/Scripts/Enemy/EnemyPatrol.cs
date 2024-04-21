using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{

    NavMeshAgent agent;
    public List<GameObject> PatrolPoints;
    public Transform Player;
    public float ViewAngle;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        EnemySeenPlayer();
    }

    void Patrol()
    {
        
        int i = 0;
        if(agent.remainingDistance <= 2)
        {
            i = Random.Range(0, PatrolPoints.Count);
            agent.destination = PatrolPoints[i].transform.position;
        }

    }

    void EnemySeenPlayer()
    {
        var direction = Player.position - gameObject.transform.position;
        if (Vector3.Angle(gameObject.transform.forward, direction) < ViewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast((transform.position + Vector3.up), direction, out hit))
            {
                if (hit.collider.GetComponent<PlayerController>() != null)
                    HuntingOnPlayer();
                else
                    Patrol();
            }
        }
        else
            Patrol();
    }

    void HuntingOnPlayer()
    {
        agent.destination = Player.position;
    }

}
