using UnityEngine;

public class Movement2 : MonoBehaviour
{
    float power = 3;
    float maxspeed = 5;
    float turnpower = 2;
    float friction = 3;
    public Vector2 curspeed;
    Rigidbody2D rigidbody2D;

    void Update()
    {
        float currentSpeed = rigidbody2D.velocity.magnitude * 6;
        float pitch = currentSpeed / maxspeed;
        GetComponent<AudioSource>().pitch = pitch;
    }

    void Start()
    {
        power = GameController.power;
        maxspeed = GameController.maxspeed;
        turnpower = GameController.turnpower;
        friction = GameController.friction;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        curspeed = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y);

        if (curspeed.magnitude > maxspeed)
        {
            curspeed = curspeed.normalized;
            curspeed *= maxspeed;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody2D.AddForce(transform.up * power);
            rigidbody2D.drag = friction;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidbody2D.AddForce(-(transform.up) * (power / 2));
            rigidbody2D.drag = friction;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * turnpower);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.forward * -turnpower);
        }

        NoGas();

    }

    void NoGas()
    {
        bool gas;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            gas = true;
        }
        else
        {
            gas = false;
        }

        if (!gas)
        {
            rigidbody2D.drag = friction * 2;
        }
    }
}
