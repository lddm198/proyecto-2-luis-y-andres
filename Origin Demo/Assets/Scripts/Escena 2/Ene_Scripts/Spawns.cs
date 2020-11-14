using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawns : MonoBehaviour
{
    
    public GameObject mini;
    public GameObject espora;
    public GameObject ogro;
    public int cantMini, cantEspora, cantOgro;
    private int x = 0,y = 0,z = 0;
    

    public float  spawnTimeMini = 5f,spawnTimeEspora = 10f,spawnTimeOgro = 15f ,rangoGenerar = 2f;

    void Start(){

        InvokeRepeating("generarMini",0.0f,spawnTimeMini);
        InvokeRepeating("generarEspora",0.0f,spawnTimeEspora);
        InvokeRepeating("generarOgro",0.0f,spawnTimeOgro);
            
    }
    void Update()
    {
        
    }
    public void generarMini(){
        
        if (cantMini != x){
            Vector3 spawnMini = new Vector3(0,0,0);
            spawnMini = this.transform.position + Random.onUnitSphere * rangoGenerar;
            spawnMini = new Vector3(spawnMini.x, spawnMini.y,160);

            GameObject Mini = Instantiate (mini,spawnMini,Quaternion.identity);
            x++;
        }
    }
    public void generarEspora(){

        if ( cantEspora != y){
            Vector3 spawnEspora = new Vector3(0,0,0);
            spawnEspora = this.transform.position + Random.onUnitSphere * rangoGenerar;
            spawnEspora = new Vector3(spawnEspora.x, spawnEspora.y,160);

            GameObject Espora = Instantiate (espora,spawnEspora,Quaternion.identity);
            y++;        
        } 
    }
    public void generarOgro(){
        
        if (cantOgro != z){
            Vector3 spawnOgro = new Vector3(0,0,0);
            spawnOgro = this.transform.position + Random.onUnitSphere * rangoGenerar;
            spawnOgro = new Vector3(spawnOgro.x, spawnOgro.y,160);
            
            GameObject Ogro = Instantiate (ogro,spawnOgro,Quaternion.identity);
            z++;
        }
    }
}
