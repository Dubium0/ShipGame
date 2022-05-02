using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update

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
        rb =  GetComponent<Rigidbody>();
        
        
    }
    void Start()
    {
        player  = GameObject.FindGameObjectWithTag("Player");
        LaunchAttack();
        rb.velocity = Vf;
        
    }   

    private void Update() {
        reflexTime += Time.deltaTime;
    }

    void LaunchAttack()
    {

        Xd = player.transform.position - transform.position;

        float radians = (theta*Mathf.PI)/180;


        t = Mathf.Sqrt((Mathf.Tan(radians) * Xd.magnitude)/-Physics.gravity.y);
        maxTime = t;
        if (t == 0)
        {
            Vd = Xd;
        }
        else
        {
            Vd = Xd/t;

        }



        Vy = -t/2*Physics.gravity.y;


         
        Vf = new Vector3(Vd.x,Vy,Vd.z);

        //Debug.Log(Vf);
        

    }
}
