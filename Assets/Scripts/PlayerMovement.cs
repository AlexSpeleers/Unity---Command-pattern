using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public delegate void OnDeath();
    public static event OnDeath onDeath;
    [SerializeField]
    private float speed = 4f;

    ICommand moveRight, moveLeft, moveForward, moveBackward;

    private void Start()
    {
        EventHandler.onTeleport += Teleport;
    }
    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.P))
        {
            Death();
        }
        if (Input.GetMouseButtonDown(1))
        {
            GameObject bullet = PoolManager.Instance.RequestBullet();
            bullet.GetComponent<Bullet>().DoAction();
        }
    }

    private void LateUpdate()
    {
        CheckBoundaries();
    }

    void Death()
    {
        if (onDeath != null)
        {
            onDeath();
        }
    }
    private void CalculateMovement()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");

        if (hInput > 0)
        {
            moveRight = new MoveRightCommand(this.transform, speed);
            moveRight.Execute();
            CommandManager.Instance.AddCommand(moveRight);
        }
        else if (hInput < 0)
        {
            moveLeft = new MoveLeftCommand(this.transform, speed);
            moveLeft.Execute();
            CommandManager.Instance.AddCommand(moveLeft);
        }
        else if (vInput > 0)
        {
            moveForward = new MoveForwardCommand(this.transform, speed);
            moveForward.Execute();
            CommandManager.Instance.AddCommand(moveForward);
        }
        else if (vInput < 0)
        {
            moveBackward = new MoveBackwardCommand(this.transform, speed);
            moveBackward.Execute();
            CommandManager.Instance.AddCommand(moveBackward);
        }
        //transform.Translate(new Vector3(hInput, 0, vInput) * speed * Time.deltaTime);
    }

    private void CheckBoundaries()
    {
        if (transform.position.x > 8.5f)
            transform.position = new Vector3(8.5f, transform.position.y, transform.position.z);
        if (transform.position.z > 12)
            transform.position = new Vector3(transform.position.x, transform.position.y, 12f);
        if (transform.position.x < -8.5f)
            transform.position = new Vector3(-8.5f, transform.position.y, transform.position.z);
        if (transform.position.z < -5.5f)
            transform.position = new Vector3(transform.position.x, transform.position.y, -5.5f);
    }

    private void Teleport(Vector3 pos)
    {
        transform.position = pos;
    }

    private void OnDestroy()
    {
        EventHandler.onTeleport -= Teleport;
    }
}
