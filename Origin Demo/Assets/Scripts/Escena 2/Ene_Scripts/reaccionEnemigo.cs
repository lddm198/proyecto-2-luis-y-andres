using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reaccionEnemigo : MonoBehaviour
{
    public SpriteRenderer spawn;
    //AudioSource reaccion;
    public AudioSource rabia;
    public int velocidad;
    public int velocidadRabia;
    bool caminar;

    Vector2 ir;
    Vector2 objetivo = new Vector2(10,90);

    void Start(){
        //spawn.enabled= false;
 
    }
    void Update(){
<<<<<<< HEAD
        if (caminar){
            this.transform.position=Vector2.MoveTowards(transform.position,ir,velocidadRabia*Time.deltaTime);
        }
        if (!caminar){
            this.transform.position=Vector2.MoveTowards(transform.position,objetivo,velocidad*Time.deltaTime);
=======
        if (!gameObject.GetComponent<Unidad>().seMovio) {
            if (caminar)
            {
                this.transform.position = Vector2.MoveTowards(transform.position, ir, velocidad * Time.deltaTime);
                //gameObject.GetComponent<Unidad>().seMovio = true;
            }
            if (!caminar)
            {
                this.transform.position = Vector2.MoveTowards(transform.position, objetivo, velocidadRabia * Time.deltaTime);
                //gameObject.GetComponent<Unidad>().seMovio = true;
            }
>>>>>>> b318fbea37ce90462a144130396f4a1ac5f308e7
        }
    }    

    private void OnTriggerStay2D(Collider2D personaje){
        //if (personaje.GetComponent<AudioSource>() !=null){
            //reaccion = personaje.GetComponent<AudioSource>();
        if (personaje.tag == "Personaje"){
            caminar = true;
            if (!rabia.isPlaying){
                spawn.enabled=true;
                rabia.Play();
                ir = personaje.transform.position;
           }
        }
        
        //}
    }

    
}
