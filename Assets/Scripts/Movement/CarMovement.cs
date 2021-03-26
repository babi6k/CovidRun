using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] float speed = 5f;
    Rigidbody carRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        carRigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate() 
    {
        MoveCar();
    }

    public void MoveCar()
    {
        Vector3 moveDestination = direction * speed;
        carRigidBody.velocity = new Vector3(moveDestination.x, carRigidBody.velocity.y, moveDestination.z);
    }
}
