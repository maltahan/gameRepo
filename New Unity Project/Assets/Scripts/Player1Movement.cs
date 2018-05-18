using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{

    public float moveSpeed;
    public Vector3 input;
    Rigidbody rigidbody;
    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector3(Input.GetAxisRaw("newHorizontal"), 0, Input.GetAxisRaw("newVertical"));

        if (rigidbody.velocity.magnitude < moveSpeed)
        {
            rigidbody.AddForce(input * moveSpeed);
        }
    }
    void OnCollisionEnter(Collision c)
    {
        // how much the character should be knocked back
        string tag = c.gameObject.tag;
        if (tag.Equals("mo") || tag.Equals("mo2"))
        {
            var magnitude = 0f;
            // calculate force vector
            var force = (transform.position - c.transform.position);
            // normalize force vector to get direction only and trim magnitude
            force.Normalize();
            var other = c.rigidbody.velocity.magnitude;
            var me = rigidbody.velocity.magnitude;
            if (other > me)
            {
                magnitude = c.rigidbody.velocity.magnitude * 1000;
                gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude);
            }
            else
            {
                magnitude = rigidbody.velocity.magnitude * 1000;
                gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude);
            }
        }
        if (c.gameObject.tag == "water")
        {
            player2ScoreCounter.ScoreValue -= 25;
            transform.position = new Vector3(-3.14f, 14.69f, 3.46f);

        }
        if (player2ScoreCounter.ScoreValue == 0)
        {
            winnerScript.winnerList.Remove("Red");
            Destroy(gameObject);
        }

    }
}

