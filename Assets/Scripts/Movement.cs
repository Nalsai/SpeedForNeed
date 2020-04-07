using UnityEngine;

public class Movement : MonoBehaviour
{
    public float power = 7;
    public float maxspeed = 10;
    public float turnpower = 3;
    public float friction = 3;
    public KeyCode KeyCodeUp;
    public KeyCode KeyCodeDown;
    public KeyCode KeyCodeLeft;
    public KeyCode KeyCodeRight;

    Rigidbody2D rdbody;
    Vector2 curspeed;

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
            curspeed = curspeed.normalized * maxspeed;
        }

        if (Input.GetKey(KeyCodeUp))
        {
            rdbody.AddForce(transform.up * power);
            rdbody.drag = friction;
        }
        if (Input.GetKey(KeyCodeDown))
        {
            rdbody.AddForce(-(transform.up) * (power / 2));
            rdbody.drag = friction;
        }
        if (Input.GetKey(KeyCodeLeft))
        {
            transform.Rotate(Vector3.forward * turnpower);
        }
        if (Input.GetKey(KeyCodeRight))
        {
            transform.Rotate(Vector3.forward * -turnpower);
        }

        NoGas();
    }

    void NoGas()
    {
        bool gas;
        if (Input.GetKey(KeyCodeUp) || Input.GetKey(KeyCodeDown))
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
