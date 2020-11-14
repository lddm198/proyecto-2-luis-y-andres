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
    Vector2 ir;
    bool caminar;

    void Start(){
        spawn.enabled= false;

    }

    void Update()
    {
        if (caminar){
            this.transform.position=Vector2.MoveTowards(transform.position,ir,velocidad*Time.deltaTime);
        }
        
        
        if(Vector2.Distance(transform.position,ir)<12f){
            caminar=false;
        }
    }
    private void OnTriggerStay2D(Collider2D personaje){
        //if (personaje.GetComponent<AudioSource>() !=null){
            //reaccion = personaje.GetComponent<AudioSource>();
            if (!rabia.isPlaying){
                spawn.enabled=true;
                rabia.Play();
                ir = personaje.transform.position;
                
                caminar =true;

            }
        //}
    }
}
