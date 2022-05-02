using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // değişkenler methodlarda anlatılacaktır

    [SerializeField] float yPosOffset =2;

    public GameObject explosionEffect;





    
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>(); // oyuncu mermisinin rigidbody componentini al
        // oyuncu mermisni gravity kullanmayacak bu yüzden editörde oyuncu mermisine gel rigidbody componentinde use gravity kısmını uncheck et
    }

    public void LaunchPlayerAttack(GameObject enemyBullet) // bu fonksiyon Game Manager da çağrılmakta 
    {
        Vector3 attackDirection = enemyBullet.transform.position-transform.position; // düşman mermisinin posizyonundan oyunucunun pozisyonunu çıkar ve  bunu attack direction a eşitle

        if (enemyBullet.GetComponent<Rigidbody>().velocity.y>0) // eğer düşman mermisini hala yükseliyorsa
        {
            attackDirection.y += yPosOffset; // attack directionun y sini yükselti ki düşman mermisini yetişebilsin
        }
       

        rb.velocity = attackDirection*3; // oyuncu mermisine attack direction yönünde hız ver
        



        

        

    }
    // OnTriggerEnter fonksiyonu objelerin colliderları birbirine deydiğinde çalışır
    private void OnTriggerEnter(Collider other) { // bu fonksiyonun çalışabilmesi için mermilerin box collider larına git ve isTrigger ı işaretle , aynı zamanda objelerde rigid body de olmalı
        if(other.CompareTag("EnemyBullet")) // eğer düşman mermisi ile çarpıştıysa
        {
            Instantiate(explosionEffect,transform.position,Quaternion.identity); // explosion effect yarat
            Destroy(other.gameObject); // düşman mermisini yok et
            Destroy(gameObject); // oyuncu mermisini yok et
            //Debug.Log("Destroyed");

        }
        
    }


}
