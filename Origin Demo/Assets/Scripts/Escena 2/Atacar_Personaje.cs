using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;

public class Atacar_Personaje : MonoBehaviour
{

    public Animator ataque;
    public VisualTilemap visualTilemap;
    public float rangoAtaque;
    public LayerMask capa;
    private Vector3 posicion;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    IEnumerator Animacion_ataque()
    {
        ataque.SetBool("Ataque", true);
        yield return new WaitForSeconds(0.1f);
        ataque.SetBool("Ataque", false);
    }

    public void AtacarEnemigo(Vector3 posicion) {
        this.posicion = posicion;
        Collider2D[] enemigos = Physics2D.OverlapCircleAll(posicion, rangoAtaque, capa);

        foreach (Collider2D enemigoGolpeado in enemigos) {
            GameObject enemigo =  enemigoGolpeado.gameObject.GetComponent<ObtenerPadre>().ObtPadre();
            enemigo.GetComponent<Unidad>().VidaActual = enemigo.GetComponent<Unidad>().VidaActual - gameObject.GetComponent<Unidad>().Daño;
            CMDebug.TextPopupMouse("-" + gameObject.GetComponent<Unidad>().Daño + " " + enemigo.GetComponent<Unidad>().Nombre);

            if(enemigo.GetComponent<Unidad>().VidaActual <= 0) {
                enemigo.GetComponent<Unidad>().Morir();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            Vector3 posicionMouse = UtilsClass.GetMouseWorldPosition();
            if (visualTilemap.cuadricula2.ObtObjeto(posicionMouse).ObtPosicionEnRango() && !gameObject.GetComponent<Unidad>().ataco)
            {
                if (transform.position.x > posicionMouse.x) {
                    transform.eulerAngles = Vector3.up * 180;
                }
                if (transform.position.x < posicionMouse.x) {
                    transform.eulerAngles = Vector3.zero;
                }
                AtacarEnemigo(posicionMouse);
                //Debug.Log(posicionAtaque);
                
                StartCoroutine(Animacion_ataque());
                gameObject.GetComponent<Unidad>().ataco = true;
            }

        } 
    }
}
