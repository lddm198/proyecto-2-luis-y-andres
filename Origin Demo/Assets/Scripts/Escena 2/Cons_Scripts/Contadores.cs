using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contadores : MonoBehaviour
{
    public Text marcador;
    private int cantMonedas = 0;

    void OnTriggerStay2D(Collider2D obj){
        if(obj.tag == "Moneda"){
            cantMonedas+=5;
            marcador.text = "x " + cantMonedas;
            Debug.Log(cantMonedas);
        }
        
    } 
}
