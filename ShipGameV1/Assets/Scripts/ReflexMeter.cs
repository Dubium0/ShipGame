using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReflexMeter : MonoBehaviour
{
    

public TextMeshProUGUI text;

void Awake() {
    text.gameObject.SetActive(false);
    
}


public void ShowReflex(float reflexPoint)
{
    
    text.SetText("Reflex Point : "+ reflexPoint);
    text.gameObject.SetActive(true);

}






}
