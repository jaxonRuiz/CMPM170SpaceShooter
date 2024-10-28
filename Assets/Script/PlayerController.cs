using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Vector3 velocity;
    public float MAX_SPEED;
    public float SPEED;
    public float RECOIL;

    public float last_shot;
    public float fire_delay;
    public GameObject bullet;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // AddForce(new Vector3(100, 0, 4));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.linearVelocity.magnitude > MAX_SPEED)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * MAX_SPEED;
        }
        Vector3 mouse = Mouse.current.position.value;
        mouse.z = Camera.main.transform.position.y;
        Vector3 world = Camera.main.ScreenToWorldPoint(mouse);
        world.y = transform.position.y;
        transform.LookAt(world);
        // transform.Translate(velocity * Time.deltaTime*MAX_SPEED, Space.Self);

        Debug.Log(rb.GetPointVelocity(world));
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * MAX_SPEED);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * MAX_SPEED / 2);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * MAX_SPEED);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * MAX_SPEED);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();
        //rb.AddForce(new Vector3(move.x, 0, move.y)*MAX_SPEED);
        Debug.Log("moving");
        //velocity.x = move.x;
        //velocity.z = move.y;
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (last_shot + fire_delay < Time.time)
        {
            GetComponent<AudioSource>().Play();
            var new_bullet = Instantiate(bullet,
                     transform.position + transform.rotation * new Vector3(0, 0, 4),
                     transform.rotation);
            var ctrl = new_bullet.GetComponent<BulletController>();
            ctrl.lifetime = 3;
            ctrl.speed = 40;
            ctrl.damage = 40;
            ctrl.transform.localScale = new Vector3(2, 2, 2);
            ctrl.player = true;
            last_shot = Time.time;
            rb.AddForce(-transform.forward * RECOIL);

        }
    }
}
