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
        // game manager  objesindeki remainingbulleti 10 a eşitler 
        // remaining bullet düşmanın ekranda kaç tane top mermisi kaldığını görebilmek için kullanılır
        gm.remainingBullet = 10;
        //Debug.Log("wait");
        //Düşmanlar saldırmadan 5 saniye beklerler
        StartCoroutine(wait(5));
        
    }
    private void Update() {

        // burası saldırılar arası zaman koymak için yazılmıştır
        if(reduce)
        {
            ReduceCoolDown();
        }
        Randomizer();
    }

    void Attack()
    {
        // düşman saldırdığında mermi yaratır ve reduce u true yapar bu sayede bir sonraki saldırısını yapmadan önce ReduceCooldown methodunu beklemek zorundadır
       Instantiate(Bullet, transform.position, Quaternion.identity);
       reduce = true;
       // remainingbullet 1 tane azaltılır
        gm.remainingBullet --;
       
      
       

    }

    void Randomizer()
    {
        // eğer düşman saldırı yapabilirse ve mermisi varsa saldırı yapabilir
        if (canAttack && gm.counter<10){
        // saldırıların arasındaki mesafe rastgele olması için random methodu kullanıldı
        float randomTime = Random.Range(1,3);
        // invoke methodu ile belirlenen rastgele zamanda Attack fonksiyonu çağrıldı
        Invoke("Attack",randomTime);
        canAttack = false;
        // game manager da ki counter variable ı 1 artırıldı
        gm.counter ++;
        }
        

    }

    void ReduceCoolDown()
    {
        // bekleme süresinden geçen süre çıkarılıyor
        coolDown-= Time.deltaTime;
        // eğer bekleme süresi kadar süre geçtiyse  daha fazla düşürmüyoruz ve canAttack ı true
        if(coolDown <0)
        {
            reduce = false;
            canAttack =true;
            coolDown = 3;

        }
        
    }
    IEnumerator wait(float waitTime) {
        // bu method 3 saniye bekletir
            yield return new WaitForSeconds(waitTime);
            Debug.Log("Finished");
            canAttack = true;
        
    }
  

}
