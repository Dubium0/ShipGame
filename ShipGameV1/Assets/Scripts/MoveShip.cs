using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    


    [SerializeField] float movePower=10;
    [SerializeField] float steerPower=10;




    private Vector3 currentDirection;
    private Rigidbody rb;

    private Quaternion startAngle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();   
     
        
    }

    private void FixedUpdate() 
    {
        currentDirection = transform.forward;
        Move();
        Break();
        Steer();
        
    }



    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(currentDirection*movePower*Time.deltaTime);
        }
        
    }

    void Break()

    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.velocity *= 0.9f*Time.deltaTime;
            
            if(rb.velocity.magnitude < 0.1)
            {
                rb.velocity = new Vector3(0,0,0);
            }
        }

    }

    void Steer()
    {   
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        rb.AddTorque(0f,horizontalInput*steerPower,0f);

        
        
    }


}
