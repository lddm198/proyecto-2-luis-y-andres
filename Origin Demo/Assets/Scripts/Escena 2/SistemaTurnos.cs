using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EstadoJuego { TurnoPersonajes, TurnoEnemigos }

public class SistemaTurnos : MonoBehaviour
{

    [SerializeField] public GameObject[] arregloUnidades;
    public GameObject cambioPersonajes;

    private List<GameObject> personajes;
    public List<GameObject> enemigos;
    public EstadoJuego estadoJuego;
    public Text textoTurno;

    // Start is called before the first frame update
    void Start()
    {
        personajes = new List<GameObject>();
        enemigos = new List<GameObject>();

        estadoJuego = EstadoJuego.TurnoPersonajes;
        textoTurno.text = "Turno de Personajes";

        DividirUnidades();

    }

    public void AnadirEnemigo(GameObject enemigo) {
        enemigos.Add(enemigo);
    }

    public void DividirUnidades()
    {
        foreach (GameObject unidad in arregloUnidades)
        {
            if (unidad.GetComponent<Unidad>().tipo == Tipos.Personaje)
            {
                personajes.Add(unidad);
            }
            else
            {
                enemigos.Add(unidad);
            }
        }
    }

    private void Update()
    {
        if(estadoJuego == EstadoJuego.TurnoPersonajes) {
            if (VerificarFin("personajes")) {
                CambioTurno("enemigo");
            }
        }
        else {
            if (VerificarFin("enemigos")) {
                CambioTurno("personajes");
            }
            else
            {
                foreach(GameObject enemigos in enemigos) {
                    enemigos.GetComponent<reaccionEnemigo>().Mover();
                }
            }
        }
    }

    public bool VerificarFin(String unidad) {
        if(unidad == "personajes") {
            foreach(GameObject personaje in personajes) {
                if(!personaje.GetComponent<Unidad>().seMovio || !personaje.GetComponent<Unidad>().ataco) {
                    return false;
                }
            }
            return true;
        }
        else {
            foreach (GameObject enemigo in enemigos) {
                if (!enemigo.GetComponent<Unidad>().seMovio || !enemigo.GetComponent<Unidad>().ataco) {
                    return false;
                }
            }
            return true;
        }
    }

    public void CambioTurno(String turnoSiguiente)
    {
        if(turnoSiguiente == "enemigo") {
            estadoJuego = EstadoJuego.TurnoEnemigos;
            foreach(GameObject enemigo in enemigos) {
                enemigo.GetComponent<Unidad>().seMovio = false;
                enemigo.GetComponent<Unidad>().ataco = false;
                textoTurno.text = "Turno de Enemigos";
            }
        }
        else{
            estadoJuego = EstadoJuego.TurnoPersonajes;
            foreach (GameObject personajes in personajes) {
                personajes.GetComponent<Unidad>().seMovio = false;
                personajes.GetComponent<Unidad>().ataco = false;
                textoTurno.text = "Turno de Personajes";
            }
        }
    }
}
