using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reaccionEnemigo : MonoBehaviour
{
    public SpriteRenderer spawn;
    //AudioSource reaccion;
    public AudioSource rabia;
    public List<Vector3> bloqueados;
    bool caminar;

    Vector3 ir;
    Vector3 objetivo = new Vector3(17.8f, 84.2f, 0f);

    void Start(){
        //spawn.enabled= false;
        bloqueados = new List<Vector3>()
        {
        new Vector3(134.9f, 23f, 0f),
        new Vector3(94.1f, 113.7f, 0f),
        new Vector3(185.7f, 96.6f, 0f),
        new Vector3(85.1f, 66.2f, 0f),
        new Vector3(82.7f, 74.3f, 0f),
        new Vector3(24.3f, 14f, 0f),
        new Vector3(62.7f, 64.8f, 0f),
        new Vector3(64.2f, 73.8f, 0f),
        new Vector3(75.1f, 75.1f, 0f),
        new Vector3(75.1f, 66.2f, 0f),
        new Vector3(154.4f, 137.4f, 0f),
        new Vector3(185.3f, 138.9f, 0f),
        new Vector3(215.7f, 127f, 0f),
        new Vector3(267f, 96.1f, 0f),
        new Vector3(264.1f, 45.3f, 0f),
        new Vector3(264.6f, 37.7f, 0f),
        new Vector3(274.5f, 43.4f, 0f),
        new Vector3(285.9f, 47.2f, 0f),
        new Vector3(275f, 34.4f, 0f),
        new Vector3(283.1f, 34.4f, 0f)
        };

    }
    public void Mover(){
        if (!gameObject.GetComponent<Unidad>().seMovio) {
            if (caminar) {
                MoverJugador();
            }
            if (!caminar) {
                MoverObjetivo();
            }
        }
    }    

    public void MoverJugador()
    {
        gameObject.GetComponent<Unidad>().seMovio = true;
        //gameObject.GetComponent<Unidad>().ataco = true;
        GetComponent<MovimientoPathfindingEnemigos>().DefPosicion(ir, bloqueados, () => { });
    }

    public void MoverObjetivo()
    {
        gameObject.GetComponent<Unidad>().seMovio = true;
        //gameObject.GetComponent<Unidad>().ataco = true;
        GetComponent<MovimientoPathfindingEnemigos>().DefPosicion(objetivo, bloqueados, () => { });
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
