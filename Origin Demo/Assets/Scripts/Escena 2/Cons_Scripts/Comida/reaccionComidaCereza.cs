using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reaccionComidaCereza : MonoBehaviour
{
    public SpriteRenderer cereza;
    public AudioSource comidaSFX;
    

    private void OnTriggerStay2D(Collider2D personaje){
        
        if (personaje.tag != "Enemigo" && personaje.tag != "Consumibles" && personaje.tag!="Moneda"){
            cereza.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(GetComponent<Collider2D>());
            if (!comidaSFX.isPlaying){
                comidaSFX.Play(); 
            }
        }
        
    }
}
