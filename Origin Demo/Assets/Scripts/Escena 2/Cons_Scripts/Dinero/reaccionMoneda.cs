using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reaccionMoneda : MonoBehaviour
{
    public SpriteRenderer moneda;
    public AudioSource coinSFX;
    

    private void OnTriggerStay2D(Collider2D personaje){

        if (personaje.tag != "Enemigo" && personaje.tag != "Consumibles" && personaje.tag!="Moneda"){
            moneda.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(GetComponent<Collider2D>());
            
            if (!coinSFX.isPlaying){
                coinSFX.Play(); 
            }
        }
        
        
    }
}
