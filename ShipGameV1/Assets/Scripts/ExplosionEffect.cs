using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    private float countDown = 2;


    private void Update() {

        countDown-=Time.deltaTime;

        if(countDown<0)
        {
            Destroy(gameObject);
        }
        
    }


}
