using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reaccionColeccionablesGema : MonoBehaviour
{
    public SpriteRenderer gema;
    public AudioSource coleccionablesSFX;
    

    private void OnTriggerStay2D(Collider2D personaje){
        
        if (personaje.tag != "Enemigo" && personaje.tag != "Consumibles" && personaje.tag!="Moneda"){    
            gema.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(GetComponent<Collider2D>());
            if (!coleccionablesSFX.isPlaying){
                coleccionablesSFX.Play(); 
            }
        }
        
    }
}
