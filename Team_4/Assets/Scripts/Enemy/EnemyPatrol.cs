using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{

    NavMeshAgent agent;
    //public List<GameObject> PatrolPoints;
    Transform Player;
    public float ViewAngle;
    bool Rest = false;
    public Animator anime;
    public float maxSeenDistance;
    private void Start()
    {
        Player = FindObjectOfType<PlayerController>().transform;
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        EnemySeenPlayer();
    }






    void Patrol()
    {
        agent.gameObject.GetComponent<Enemy1Attack>().CancelInvoke("AttackOnPlayer");//отменяем атаку, если враг теряет игрока;

        float x = 0;
        float z = 0;
        Vector3 pos = Vector3.zero;
        if(agent.remainingDistance <= 3)
        {
            Debug.Log("1");
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
        Debug.Log("3");
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
                {
                    //Debug.Log(hit.distance);
                    if (hit.distance <= maxSeenDistance)
                        HuntingOnPlayer();
                    else
                        Patrol();
                }
                else
                    Patrol();

            }
        }
        else
            Patrol();
    }

    void HuntingOnPlayer()
    {
        Debug.Log("2");
        agent.Resume();
        agent.destination = Player.position;
        if (agent.remainingDistance < 2)
        {
            agent.gameObject.GetComponent<Enemy1Attack>().AttackEnemy1();
        }
        else
        {
            anime.SetInteger("moving", 1);
            agent.gameObject.GetComponent<Enemy1Attack>().CancelInvoke("AttackOnPlayer");
        }
            
    }



}
