using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3Movement : MonoBehaviour
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
        input = new Vector3(Input.GetAxisRaw("ThirdPlayerHorizontal"), 0, Input.GetAxisRaw("ThirdPlayerVertical"));

        if (rigidbody.velocity.magnitude < moveSpeed)
        {
            rigidbody.AddForce(input * moveSpeed);
        }
    }
    void OnCollisionEnter(Collision c)
    {
        // how much the character should be knocked back
        string tag = c.gameObject.tag;
        if (tag.Equals("mo") || tag.Equals("mo1"))
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
            Player3ScoreCounter.ScoreValue -= 25;
            transform.position = new Vector3(-5f, 15f, 0f);

        }
        if (Player3ScoreCounter.ScoreValue == 0)
        {
            winnerScript.winnerList.Remove("Green");
            Destroy(gameObject);
        }

    }
}
