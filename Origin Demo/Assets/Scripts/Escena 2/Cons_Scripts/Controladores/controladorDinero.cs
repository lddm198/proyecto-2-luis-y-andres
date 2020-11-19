using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorDinero : MonoBehaviour
{
    public GameObject moneda;
    public GameObject saco;
    public int cantMonedas, cantSacos;
    public float rangoGenerar = 0f;
    

    private float  spawnTimeMoneda = 0f,spawnTimeSaco = 0f;

    void Start(){
        //llamamos a los métodos que me generan los sacos y las monedas para ubicarlas en el mapa
        for (int x = 0; x < cantMonedas ; x++)
        {
            InvokeRepeating("generarMoneda",0.0f,spawnTimeMoneda);
        }
        for (int i = 0; i < cantSacos; i++)
        {
            InvokeRepeating("generarSaco",0.0f,spawnTimeSaco);
        }
        
            
    }
    public void generarMoneda(){
        //creamos el spawn de la moneda 
        Vector3 spawnMoneda = new Vector3(0,0,0);
        //definimos su ubicion 
        spawnMoneda = this.transform.position + Random.onUnitSphere * rangoGenerar;
        //determinamos los parametros finales
        spawnMoneda = new Vector3(spawnMoneda.x, spawnMoneda.y,160);

        //instanciamos el objeto
        GameObject Moneda = Instantiate (moneda,spawnMoneda,Quaternion.identity);
         
    }
    public void generarSaco(){
        //creamos el spawn del saco 
        Vector3 spawnSaco = new Vector3(0,0,0);
        //definimos su ubicion 
        spawnSaco = this.transform.position + Random.onUnitSphere * rangoGenerar;
        //determinamos los parametros finales
        spawnSaco = new Vector3(spawnSaco.x, spawnSaco.y,160);

        //instanciamos el objeto
        GameObject Saco = Instantiate (saco,spawnSaco,Quaternion.identity);
         
    }
}
