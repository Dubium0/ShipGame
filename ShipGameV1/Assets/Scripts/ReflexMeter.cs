using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // textmeshpro yu import et

public class ReflexMeter : MonoBehaviour
{
    // bu script Reflex sayacını ekrana çizdirir

public TextMeshProUGUI text; // ekrandaki reflex meter textine referans al

void Awake() {
    text.gameObject.SetActive(false);  // en başta bu yazının gözükmesini istemiyoruz yani onu deactive et
    
}


public void ShowReflex(float reflexPoint) // bu fonksiyon Game Manager da çağrılır
{
    
    text.SetText("Reflex Point : "+ reflexPoint);  // reflex pointi texte yazdır
    text.gameObject.SetActive(true); // ve objeyi tekrar active et

}






}
