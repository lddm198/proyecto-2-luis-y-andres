using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reaccionSaco : MonoBehaviour
{
    public SpriteRenderer saco;
    public AudioSource sacoSFX;
    

    private void OnTriggerStay2D(Collider2D personaje){

        if (personaje.tag != "Enemigo" && personaje.tag != "Consumibles" && personaje.tag!="Moneda"){
            saco.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(GetComponent<Collider2D>());
            if (!sacoSFX.isPlaying){
                sacoSFX.Play(); 
            }
        }
        
    }
}
