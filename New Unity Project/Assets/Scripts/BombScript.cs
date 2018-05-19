using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BombScript : MonoBehaviour
{

    public GameObject bomb;
    public float power = 600f;
    public float radius = 50f;
    public float upForce = 1f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bomb == enabled)
        {
            Invoke("Detonate", 5);
        }
    }

    void Detonate()
    {
        Vector3 explosionPosition = bomb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (var hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
            }
        }
        Destroy(bomb);
        System.Random rnd = new System.Random();
        int Random = rnd.Next(1, 4);
        if (winnerScript.winnerList.Count > 1)
        {
            if (Random == 1)
            {
                transform.position = new Vector3(3f, 16f, 0f);
            }
            else if (Random == 2)
            {
                transform.position = new Vector3(-3.14f, 14.69f, 3.46f);
            }
            else
            {
                transform.position = new Vector3(-5f, 15f, 0f);
            }
        }
    }
}
