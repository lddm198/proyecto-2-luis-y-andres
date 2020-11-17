using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reaccionComidaSandia : MonoBehaviour
{
    public SpriteRenderer sandia;
    public AudioSource comidaSFX;
    

    private void OnTriggerStay2D(Collider2D personaje){

        if (personaje.tag == "Personaje"){
            sandia.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(GetComponent<Collider2D>());
            if (!comidaSFX.isPlaying){
                comidaSFX.Play(); 
            }
        }
        
    }
}
