using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

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
     CountEnemyBullet();
     if (Input.GetMouseButtonDown(0))
     {
         Debug.Log("Mouse is down");
         
         hitInfo = new RaycastHit();
         bool hit = Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hitInfo);
         if (hit) 
         {
             Debug.Log("hitted");
             if(hitInfo.transform.gameObject.CompareTag("EnemyBullet") && !hitInfo.transform.gameObject.GetComponent<EnemyBullet>().hitted)
             {
                 hitInfo.transform.gameObject.GetComponent<EnemyBullet>().hitted = true;
                 HandlePlayerAttack(hitInfo.transform.gameObject);
                 CalculateReflexPoint(hitInfo.transform.gameObject.GetComponent<EnemyBullet>());
                 

             }
         } else {
             Debug.Log("No hit");
         }
         Debug.Log("Mouse is down");
     } 
     if ( counter ==10)
    {

        Invoke("Show",5);
        
    }
 }


 void HandlePlayerAttack(GameObject enemyBullet)
 {
     playerBullet = Instantiate(playerBulletPrefab,player.transform.position,Quaternion.identity);

    playerBullet.GetComponent<PlayerBullet>().LaunchPlayerAttack(enemyBullet);
    Debug.Log(enemyBullet);


 }



 void CalculateReflexPoint(EnemyBullet enemyScript)
 {
     Debug.Log(enemyScript.maxTime);
     Debug.Log(enemyScript.reflexTime);
    reflexPoint +=  100 -(100/enemyScript.maxTime)*(enemyScript.reflexTime-reflexOffset); 
    


    
 }

void Show()
{
reflexMeter.ShowReflex(reflexPoint/10);
}


public void Restart()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}

void CountEnemyBullet()
{
    enemyBulletText.SetText("Enemy Bullet : " + remainingBullet );
}

public void Exit()
{   
    Application.Quit();

}

    
    
}
