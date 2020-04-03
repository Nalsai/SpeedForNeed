﻿using UnityEngine;

public class Movement : MonoBehaviour
{
    public float power = 7;
    public float maxspeed = 10;
    public float turnpower = 3;
    public float friction = 3;
    public Vector2 curspeed;
    Rigidbody2D rdbody;

    void Update()
    {
        float currentSpeed = rdbody.velocity.magnitude * 6;
        float pitch = currentSpeed / maxspeed;
        GetComponent<AudioSource>().pitch = pitch;
    }

    void Start()
    {
        rdbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        curspeed = new Vector2(rdbody.velocity.x, rdbody.velocity.y);

        if (curspeed.magnitude > maxspeed)
        {
            curspeed = curspeed.normalized;
            curspeed *= maxspeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            rdbody.AddForce(transform.up * power);
            rdbody.drag = friction;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rdbody.AddForce(-(transform.up) * (power / 2));
            rdbody.drag = friction;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * turnpower);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * -turnpower);
        }

        NoGas();
    }

    void NoGas()
    {
        bool gas;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            gas = true;
        }
        else
        {
            gas = false;
        }

        if (!gas)
        {
            rdbody.drag = friction * 2;
        }
    }
}
