using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AnimacionTeclas : MonoBehaviour
{
    public Animator tecla;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            tecla.SetBool("Click1",true);
        }
        if (Input.GetKeyUp(KeyCode.Alpha1)) {
            tecla.SetBool("Click1", false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            tecla.SetBool("Click2", true);
        }
        if (Input.GetKeyUp(KeyCode.Alpha2)) {
            tecla.SetBool("Click2", false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            tecla.SetBool("Click3", true);
        }
        if (Input.GetKeyUp(KeyCode.Alpha3)) {
            tecla.SetBool("Click3", false);
        }
    }
}
