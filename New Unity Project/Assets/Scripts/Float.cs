using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Float : MonoBehaviour {

    public int health = 0;
    NavMeshAgent nav;
    Rigidbody rig;
    float speed = 1f;
    bool sinking;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (sinking)
        {
            transform.Translate(-Vector3.up * speed * Time.deltaTime);
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        nav.enabled = false;
        rig.isKinematic = true;
        sinking = true;
        Destroy(gameObject, 5f);
    }
}
