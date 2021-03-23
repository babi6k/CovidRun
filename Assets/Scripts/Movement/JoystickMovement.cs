using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed = 5.0f;
    [SerializeField] float minX = 0f;
    [SerializeField] float maxX = 0f;

    Vector3 direction;
    Joystick joystick;
    Rigidbody rigidBody;
    Animator animator;
    Vector3 playerPosSetup;

    private void Start()
    {
        joystick = GetComponent<FixedJoystick>();
        rigidBody = player.GetComponent<Rigidbody>();
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float z = joystick.Horizontal;
        float x = joystick.Vertical;
        direction = new Vector3(-x, 0, z);
        direction = ApplyHorizBoundary(player.position, direction);
        Animate();
    }

    private void FixedUpdate()
    {
        MoveCharacter(direction);
    }


    void MoveCharacter(Vector3 direction)
    {
        Vector3 moveDestination = direction * speed;
        rigidBody.velocity = new Vector3(moveDestination.x, rigidBody.velocity.y, moveDestination.z);
    }

    void Animate()
    {
        if (direction.x < 0)
        {
            player.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (direction.x > 0)
        {
            player.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (direction.z > 0)
        {
            player.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (direction.z < 0)
        {
            player.rotation = Quaternion.Euler(0, 180, 0);
        }

        animator.SetFloat("VelocityX", direction.x);
        animator.SetFloat("VelocityZ", direction.z);
    }

    Vector3 ApplyHorizBoundary(Vector3 currentPosition, Vector3 direction)
    {
        float clampedX = Mathf.Clamp(currentPosition.x + direction.x, minX, maxX);
        return new Vector3(clampedX - currentPosition.x, direction.y, direction.z);
    }
}
