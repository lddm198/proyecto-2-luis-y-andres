using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioPersonaje : MonoBehaviour
{
    //Se Definen los personajes
    public GameObject ninja, vikingo, mago;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IniciarBarras());
        ninja.GetComponent<LecturaDeMouse>().enabled = true;
        vikingo.GetComponent<LecturaDeMouse>().enabled = false;
        mago.GetComponent<LecturaDeMouse>().enabled = false;

        ninja.GetComponent<Atacar_Personaje>().enabled = true;
        vikingo.GetComponent<Atacar_Personaje>().enabled = false;
        mago.GetComponent<Atacar_Personaje>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            ninja.GetComponent<Contadores>().ActualizarCont();
            if (!ninja.GetComponent<Unidad>().seMovio) {
                ninja.GetComponent<LecturaDeMouse>().enabled = true;
                vikingo.GetComponent<LecturaDeMouse>().enabled = false;
                mago.GetComponent<LecturaDeMouse>().enabled = false;

                ninja.GetComponent<utilizarConsumible>().enabled = true;
                vikingo.GetComponent<utilizarConsumible>().enabled = false;
                mago.GetComponent<utilizarConsumible>().enabled = false;

                ninja.GetComponent<Atacar_Personaje>().enabled = true;
                vikingo.GetComponent<Atacar_Personaje>().enabled = false;
                mago.GetComponent<Atacar_Personaje>().enabled = false;
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            vikingo.GetComponent<Contadores>().ActualizarCont();
            if (!vikingo.GetComponent<Unidad>().seMovio) {
                ninja.GetComponent<LecturaDeMouse>().enabled = false;
                vikingo.GetComponent<LecturaDeMouse>().enabled = true;
                mago.GetComponent<LecturaDeMouse>().enabled = false;

                ninja.GetComponent<utilizarConsumible>().enabled = false;
                vikingo.GetComponent<utilizarConsumible>().enabled = true;
                mago.GetComponent<utilizarConsumible>().enabled = false;

                ninja.GetComponent<Atacar_Personaje>().enabled = false;
                vikingo.GetComponent<Atacar_Personaje>().enabled = true;
                mago.GetComponent<Atacar_Personaje>().enabled = false;
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            mago.GetComponent<Contadores>().ActualizarCont();
            if (!mago.GetComponent<Unidad>().seMovio) {
                ninja.GetComponent<LecturaDeMouse>().enabled = false;
                vikingo.GetComponent<LecturaDeMouse>().enabled = false;
                mago.GetComponent<LecturaDeMouse>().enabled = true;

                ninja.GetComponent<utilizarConsumible>().enabled = false;
                vikingo.GetComponent<utilizarConsumible>().enabled = false;
                mago.GetComponent<utilizarConsumible>().enabled = true;

                ninja.GetComponent<Atacar_Personaje>().enabled = false;
                vikingo.GetComponent<Atacar_Personaje>().enabled = false;
                mago.GetComponent<Atacar_Personaje>().enabled = true;
            }

        }
    }
    IEnumerator IniciarBarras()
    {
        ninja.GetComponent<utilizarConsumible>().enabled = true;
        vikingo.GetComponent<utilizarConsumible>().enabled = true;
        mago.GetComponent<utilizarConsumible>().enabled = true;

        yield return new WaitForSeconds(1f);

        ninja.GetComponent<utilizarConsumible>().enabled = true;
        vikingo.GetComponent<utilizarConsumible>().enabled = false;
        mago.GetComponent<utilizarConsumible>().enabled = false;
    }
}
