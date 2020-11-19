using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;

public class Atacar_Enemigo : MonoBehaviour
{
    public Animator ataque;
    private Vector3 blanco;
    public float rangoAtaque;
    public LayerMask capa;
    private Vector3 posicion;
    private bool atacar = true;

    IEnumerator Animacion_ataque()
    {
        ataque.SetBool("Ataque", true);
        yield return new WaitForSeconds(0.1f);
        ataque.SetBool("Ataque", false);
    }

    public void AtacarPersonaje(Vector3 posicion) {
        this.posicion = posicion;
        Collider2D[] personajes = Physics2D.OverlapCircleAll(posicion, rangoAtaque, capa);

        foreach (Collider2D personajeGolpeado in personajes) {
            GameObject personaje =  personajeGolpeado.gameObject.GetComponent<ObtenerPadre>().ObtPadre();
            personaje.GetComponent<Unidad>().VidaActual = personaje.GetComponent<Unidad>().VidaActual - gameObject.GetComponent<Unidad>().Daño;
            CMDebug.TextPopupMouse("-" + gameObject.GetComponent<Unidad>().Daño + " " + personaje.GetComponent<Unidad>().Nombre);

            if(personaje.GetComponent<Unidad>().VidaActual <= 0) {
                personaje.GetComponent<Unidad>().Morir();
            }
        }
    }

    void Start(){
        blanco = new Vector3( 0f,0f,0f);
    }
    void Update()
    {
        float dist=Vector3.Distance(blanco,gameObject.transform.position);
        if (atacar){
            if( dist < 10f){
                AtacarPersonaje(blanco);
                StartCoroutine(Animacion_ataque());
                gameObject.GetComponent<Unidad>().ataco = true;
                atacar=false;
            }
        }
        
        //Debug.Log(posicionAtaque);
        
        
    } 
    void OnTriggerStay2D(Collider2D other){
        if (other.tag=="Personaje"){
            blanco = other.transform.position;
        }
    }
}
