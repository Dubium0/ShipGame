using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Değişkenlerin işlevleri methodlarda açıklanmıştır

    private Rigidbody rb;

    private GameObject player;
    
    private Vector3 Xd;

    private float Vy;

    private Vector3 Vd;

    private Vector3 Vf;

    private float t;

    public bool hitted;

     [SerializeField] float theta;


    public float reflexTime = 0; 

    public float maxTime;
    private void Awake() {
        // bağlı olduğu objenin rigid body componentini alır
        rb =  GetComponent<Rigidbody>();
        
        
    }
    void Start()
    {   // sahnede player objesini tag ına bakarak bulmayı sağlar
        player  = GameObject.FindGameObjectWithTag("Player");
        // saldırının yönünü belirler
        LaunchAttack();
        //bağlı olduğu objeye ilk hız verir Vf LaunchAttack() fonksiyonunda belirleniyor.
        rb.velocity = Vf;
        
    }   

    private void Update() {
        /*  düşman mermisi objesi yaratıldığında reflextTime  =0 olarak belirlenmişti , burada  reflexTime varaible ını obje yaratıldığı ilk andan itibaren geçen süre kadar artırıyoruz
bu sayede oyuncu mermiye tıkladığında ne kadar hızlı tepki verdiği ölçülebiliyor.
        */

        reflexTime += Time.deltaTime;
    }

    void LaunchAttack()
    {
        /* bu kod da düşman mermilerinin hız vektörü hesaplanıyor 

        Bu hesaplamada merminin hız vektörünün yatay düzlemle yaptığı açı bizim değişkenimiz olurken sabitlerimiz yerçekimi ivmesi ve aradaki mesafe vektörüdür.


        Aradaki mesafe vektörü Xd yi  oyuncunun pozisyonundan merminin pozisyonunu çıkararak bulabiliriz.

        Mesafe vektörü aynı zamanda mermiden oyuncuya uzanan bir yön  belirtiyor.  Bu yönü kullanarak mermiye bir hız vektörü çizebiliriz.

        Düşman gemisi ve oyuncu gemilerini aynı yüksekliğe koyarsak  aradaki pozisyon vektörü x - z düzleminde olacağından bize işlem kolaylığı sağlayacaktır bu yüzden  düşman ve oyuncuyu aynı yüksekliğe koydum.

        Merminin x-z düzlemindeki hızını hespalamak için  Xd = Vd*t formülünü kullandım . t burada geçen zamanı belirtiyor

        Eğer Mermi havada t kadar süre kalabilirse Vd hız ile Xd mesafe gidebilir. Bu yüzden y doğrultusundakş hızımız Vy = - g*(t/2) kadar olmalıdır. g yerçekimi ivmesidir.

        Cismimiz bu yerçekimi ivmesinin t/2 katı kadar ters yönde hıza sahip olursa  ilk t/2 anda g*t/2 e hız kaybeder ve maksimum yüksekliğe ulaşır. Sonraki t/2 anda başlangıçtaki yüksekliğine geri gelir,
        bu yükseklik aynı zamanda oyuncumuzun yüksekliğidir. Yani t sürede  tam olarak oyuncumuzun üstüne düşebilir.

        Bu anlarda Vd hızı ile Vy hızı arasındaki açıya theta dersek   tan(theta) = Vy/Vd olur  Vy yerine -g*t Vd yerine Xd/t yazarsak   ===> tan(theta) = -(g*t^2)/Xd bulunur.

        Bu denklemde bilinmeyen tek değişken t dir. Çünkü theta yı biz kendi elimiz ile unity editörü üzerinden vereceğiz. O yüzden t yi yalnız bırakıyoruz ve geri kalan sabitleri karşıya atıyoruz. 

        kök (tan(theta)* Xd/-g) = t oluyor.  Buradan t yi çektikten sonra Vy yi ve Vd yi de t yi denklemlerde yerine yazarak buluyoruz. Sonra bu hızı objemize veriyoruz. 

        
        
        */
        

        // bu method çağrıldığı andaki oyuncu pozisyonundan mevcut objenin pozisyonunu çıkararak aradaki mesafeyi vektörel olarak buluyoruz
        // bu vektörü düşman mermisinden oyuncuya doğru uzanan bir vektör olarak düşünebilirsiniz

        Xd = player.transform.position - transform.position;


        // unitynin içindeki matematik kütüphanesi derece kabul etmiyor. O yüzden basit bir işlemle derecemizi radyana çeviriyoruz
        float radians = (theta*Mathf.PI)/180;

        // yukarıda anlatılan zamanı bulduğumuz denklemi yazıyoruz
        t = Mathf.Sqrt((Mathf.Tan(radians) * Xd.magnitude)/-Physics.gravity.y);
        maxTime = t; // maxTime mermi objesinin havada kalacağı maksimum süreyi belirtiyor ve bu t kadar
        if (t == 0)
        {
            Vd = Xd; // t nin 0 olduğu tek koşul da Vd hız vektörümüz Xd ye eşittir çünkü havaya fırlamadan düz x-z düzleminde gidiyor demektir
        }
        else
        {
            Vd = Xd/t; // eğer t 0 değilse Vd yi sadece Xd/t ye eşitliyoruz bu sayede x-z düzlemindeki hızımızı buluyoruz

        }



        Vy = -t/2*Physics.gravity.y; // y düzlemindeki denklemi de yerine koyuyoruz


         
        Vf = new Vector3(Vd.x,Vy,Vd.z);  // son olarak Vf hız vektöründe bunları birleştiriyoruz

        //Debug.Log(Vf);
        

    }
}
