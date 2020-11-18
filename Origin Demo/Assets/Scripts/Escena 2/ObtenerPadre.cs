using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtenerPadre : MonoBehaviour 
{

    [SerializeField] public GameObject padre;

    public GameObject ObtPadre() {
        return padre;
    }
    
}
