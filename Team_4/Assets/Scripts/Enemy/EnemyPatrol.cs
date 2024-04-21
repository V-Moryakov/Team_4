using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{

    NavMeshAgent agent;
    //public List<GameObject> PatrolPoints;
    public Transform Player;
    public float ViewAngle;
    bool Rest = false;
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
        float x = 0;
        float z = 0;
        Vector3 pos = Vector3.zero;
        if(agent.remainingDistance <= 2)
        {
            x = Random.Range(-10, 10);
            z = Random.Range(-10, 10);
            pos = new Vector3(x, 0, z);
            agent.destination = gameObject.transform.position + pos;
        }
        if (!Rest && !agent.isStopped)
        {
            float timeToRest = Random.Range(10, 20);
            Invoke("RestOnPatrol", timeToRest);
            Rest = true;
        }
            
    }
    void RestOnPatrol()
    {
        float timeForRest = Random.Range(5, 10);
        Rest = false;
        agent.Stop();
        Invoke("ReturnToPatrol", timeForRest);
    }
    void ReturnToPatrol()
    {
        agent.Resume();
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
