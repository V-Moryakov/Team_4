using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{

    public float speed;
    public float lifeTime = 3;
    float damage = 20;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<EnemyHP>() != null)
        {
            collision.gameObject.GetComponent<EnemyHP>().DealDamage(damage);
            FireDestroy();
        }
        else
            FireDestroy();
    }

    private void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void Update()
    {
        Move();
        Invoke("FireDestroy", lifeTime);
    }

    void Move()
    {
        gameObject.transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void FireDestroy()
    {
        Destroy(gameObject);
    }

}
