using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    

    // değişkenlerin ne işe yaradığı methodlarda anlatılacaktır
    [SerializeField] float movePower=10;
    [SerializeField] float steerPower=10;




    private Vector3 currentDirection;
    private Rigidbody rb;

   
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();   // oyuncunun gemisinin rigidBody componentini alıyoruz bu sayede üzerinde fizik uygulayabiliriz
     
        
    }

    private void FixedUpdate() 
    {
        currentDirection = transform.forward; //  geminin o anda burunun gösterdiği yön
        Move(); // gemiyi hareket ettirir
        Break(); // fren yapmayı sağlar
        Steer(); // dönmeyi sağlar
        
    }



    void Move()
    {
        if (Input.GetKey(KeyCode.W)) // w tuşuna basıldıysa
        {
            rb.AddForce(currentDirection*movePower*Time.deltaTime); // o anki yönde gemiye güç uygula 
        }
        
    }

    void Break()

    {
        if(Input.GetKey(KeyCode.Space)) // space tuşuna basıldıysa
        {
            rb.velocity *= 0.9f*Time.deltaTime; // gemininin hızını düşür
            
            if(rb.velocity.magnitude < 0.1) // eğer geminin hızı 0.1 den küçükse
            {
                rb.velocity = new Vector3(0,0,0); // direk 0 a eşitle
            }
        }

    }

    void Steer()
    {   
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // yatay düzelmi belirten a d sol ok tuşu sağ ok tuşu gibi bütün tuşları dinle ve yatayda bir yön verilmişmi kontrol et

        rb.AddTorque(0f,horizontalInput*steerPower,0f); // bu yön kadar gemiye tork uygula (bunu yaparken geminin z rotation fix lemen gerek)

        
        
    }


}
