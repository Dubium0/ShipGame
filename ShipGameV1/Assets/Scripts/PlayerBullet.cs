using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    

    [SerializeField] float yPosOffset =2;

    public GameObject explosionEffect;





    
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {

        
        
    }
    public void LaunchPlayerAttack(GameObject enemyBullet)
    {
        Vector3 attackDirection = enemyBullet.transform.position-transform.position;

        if (enemyBullet.GetComponent<Rigidbody>().velocity.y>0)
        {
            attackDirection.y += yPosOffset;
        }
       

        rb.velocity = attackDirection*3;
        



        

        

    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("EnemyBullet"))
        {
            Instantiate(explosionEffect,transform.position,Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
            Debug.Log("Destroyed");

        }
        
    }


}
