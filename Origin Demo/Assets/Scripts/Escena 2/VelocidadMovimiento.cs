using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocidadMovimiento : MonoBehaviour
{

    [SerializeField] private float veloMov;

    private Vector3 vectorVelocidad;

    public void DefVelocidad(Vector3 vectorVelocidad)
    {
        this.vectorVelocidad = vectorVelocidad;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += vectorVelocidad * veloMov * Time.fixedDeltaTime;
    }
}
