using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reaccionComidaManzana : MonoBehaviour
{
    public SpriteRenderer manzana;
    public AudioSource comidaSFX;
    

    private void OnTriggerStay2D(Collider2D personaje){
        
        if (personaje.tag == "Personaje"){
            manzana.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(GetComponent<Collider2D>());
            if (!comidaSFX.isPlaying){
                comidaSFX.Play(); 
            }
        }
        
    }
}
