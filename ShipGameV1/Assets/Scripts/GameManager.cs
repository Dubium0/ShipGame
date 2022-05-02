using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

public RaycastHit hitInfo;

public GameObject playerBulletPrefab;

public GameObject player;

private GameObject playerBullet;

private float reflexPoint;

public ReflexMeter reflexMeter;

public int counter;

[SerializeField] float reflexOffset;

 void Update()
 {
     if (Input.GetMouseButtonDown(0))
     {
         Debug.Log("Mouse is down");
         
         hitInfo = new RaycastHit();
         bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
         if (hit) 
         {
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
    
    
}
