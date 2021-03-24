using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    [SerializeField] FixedJoystick joystick;
    [SerializeField] float rotationSpeed = 5f;

    Vector3 direction;
    Mover mover;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        joystick = joystick.GetComponent<FixedJoystick>();
        mover = GetComponent<Mover>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float z = joystick.Horizontal;
        float x = joystick.Vertical;
        direction = new Vector3(-x, 0, z);
        direction = mover.ApplyVerticalBoundries(transform.position,direction);
        if (x > 0 || x <0 || z > 0 || z < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed);
        }
    }

    void FixedUpdate() 
    {
        mover.MoveCharacter(direction);
        Animate();
    }
    

    void Animate()
    {
        animator.SetFloat("VelocityX", direction.x);
        animator.SetFloat("VelocityZ", direction.z);
    }
}
