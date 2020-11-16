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
        ninja.GetComponent<LecturaDeMouse>().enabled = true;
        vikingo.GetComponent<LecturaDeMouse>().enabled = false;
        mago.GetComponent<LecturaDeMouse>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            if (!ninja.GetComponent<Unidad>().seMovio) {
                ninja.GetComponent<LecturaDeMouse>().enabled = true;
                vikingo.GetComponent<LecturaDeMouse>().enabled = false;
                mago.GetComponent<LecturaDeMouse>().enabled = false;
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            if (!vikingo.GetComponent<Unidad>().seMovio) {
                ninja.GetComponent<LecturaDeMouse>().enabled = false;
                vikingo.GetComponent<LecturaDeMouse>().enabled = true;
                mago.GetComponent<LecturaDeMouse>().enabled = false;
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            if (!mago.GetComponent<Unidad>().seMovio) {
                ninja.GetComponent<LecturaDeMouse>().enabled = false;
                vikingo.GetComponent<LecturaDeMouse>().enabled = false;
                mago.GetComponent<LecturaDeMouse>().enabled = true;
            }

        }
    }
}
