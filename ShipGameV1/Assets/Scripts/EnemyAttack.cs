using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttack : MonoBehaviour
{
   


    public GameObject Bullet;



    private float coolDown = 3f;

    public GameManager gm;

    private float counter;

    

    private bool reduce=false;

    private bool canAttack =false;

    
    


    void Start() {
        gm.remainingBullet = 10;
        Debug.Log("wait");
        StartCoroutine(wait(5));
        
    }
    private void Update() {

        if(reduce)
        {
            ReduceCoolDown();
        }
        Randomizer();
    }

    void Attack()
    {
        
       Instantiate(Bullet, transform.position, Quaternion.identity);
       reduce = true;
        gm.remainingBullet --;
       
      
       

    }

    void Randomizer()
    {
        if (canAttack && gm.counter<10){
        
        float randomTime = Random.Range(1,3);

        Invoke("Attack",randomTime);
        canAttack = false;
        gm.counter ++;
        }
        

    }

    void ReduceCoolDown()
    {
        coolDown-= Time.deltaTime;

        if(coolDown <0)
        {
            reduce = false;
            canAttack =true;
            coolDown = 3;

        }
        
    }
    IEnumerator wait(float waitTime) {
        {
            yield return new WaitForSeconds(waitTime);
            Debug.Log("Finished");
            canAttack = true;
        }
    }
  

}
