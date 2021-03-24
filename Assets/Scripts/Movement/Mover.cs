using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float minX = 0f;
    [SerializeField] float maxX = 0f;
    [SerializeField] float speed = 5.0f;

    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void MoveCharacter(Vector3 direction)
    {
        Vector3 moveDestination = direction * speed;
        rigidBody.velocity = new Vector3(moveDestination.x, rigidBody.velocity.y, moveDestination.z);
    }


    public Vector3 ApplyVerticalBoundries(Vector3 currentPosition, Vector3 direction)
    {
        float clampedX = Mathf.Clamp(currentPosition.x + direction.x, minX, maxX);
        return new Vector3(clampedX - currentPosition.x, direction.y, direction.z);
    }
}
