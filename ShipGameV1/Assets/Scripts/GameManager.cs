using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

// değişkenlerin ne işe yaradığı methodlarda anlatılıyor
public RaycastHit hitInfo;

public GameObject playerBulletPrefab;

public GameObject player;

public Camera cam;

private GameObject playerBullet;

private float reflexPoint;

public ReflexMeter reflexMeter;

public TextMeshProUGUI enemyBulletText;

public float remainingBullet;


public int counter;

[SerializeField] float reflexOffset;

 void Update()
 {  
     // düşmanın mermisini sayar
     CountEnemyBullet();
     // eğer mouse un sol tıkına basılmış ise
     if (Input.GetMouseButtonDown(0))
     {
         Debug.Log("Mouse is down");
         // yeni bir raycast değişkeni
         hitInfo = new RaycastHit();
         // camerada dünyadaki noktlara ışın çizdiriyoruz eğer bu ışın bir collider a çarparsa bize  çarptığı obje hakkında info döndürüyor
         bool hit = Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hitInfo);
         if (hit) // eğer bir objeye ışın deydiyse
         {
             Debug.Log("hitted");
             if(hitInfo.transform.gameObject.CompareTag("EnemyBullet") && !hitInfo.transform.gameObject.GetComponent<EnemyBullet>().hitted) // eğer bu objenin tagı Enemy bullet ise ve bu obje daha önce vurulmamışsa aşağıdakileri yap
             {
                 hitInfo.transform.gameObject.GetComponent<EnemyBullet>().hitted = true; // mermi objesinin hitted değişkenini true yap bu sayaede oyuncu aynı mermiyi bombardımana tutamasın
                 HandlePlayerAttack(hitInfo.transform.gameObject); // oyuncunun mermisini ateşler
                 CalculateReflexPoint(hitInfo.transform.gameObject.GetComponent<EnemyBullet>());// reflex puanını hesaplar
                 

             }
         } else {
             Debug.Log("No hit");
         }
         Debug.Log("Mouse is down");
     } 
     if ( counter ==10) // eğer 10 mermide bittiyse
    {

        Invoke("Show",5); // 5 saniye sonra reflex skorunu göster
        
    }
 }


 void HandlePlayerAttack(GameObject enemyBullet)
 {
     playerBullet = Instantiate(playerBulletPrefab,player.transform.position,Quaternion.identity); // oyuncu mermisini yaratır

    playerBullet.GetComponent<PlayerBullet>().LaunchPlayerAttack(enemyBullet);// oyuncu mermisini ateşler
    //Debug.Log(enemyBullet);


 }



 void CalculateReflexPoint(EnemyBullet enemyScript)
 {
    // Debug.Log(enemyScript.maxTime);
    // Debug.Log(enemyScript.reflexTime);
    reflexPoint +=  100 -(100/enemyScript.maxTime)*(enemyScript.reflexTime-reflexOffset);  // bu fonksiyon sayesinde oyuncunun reflex puanını 100 üzerinden bir scalaya koyuyoruz
    // toplama işaretinin sebebi 10 tane düşman mermisi olması ,
    // en bu puanı 10 a bölerek ortalamayı buluyoruz ve bu oyuncunu reflex puanı oluyor
    // ortalama show fonksiyonunda alınıyor
    


    
 }

void Show()
{
reflexMeter.ShowReflex(reflexPoint/10); // ortalamayı al ve göster
}


public void Restart()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // restart atmayı sağlar
}

void CountEnemyBullet()
{
    enemyBulletText.SetText("Enemy Bullet : " + remainingBullet ); // düşman mermilerini ui da yazdırır
}

public void Exit()
{   
    Application.Quit(); // uygulamadan çıkış yapmayı sağlar

}

    
    
}
