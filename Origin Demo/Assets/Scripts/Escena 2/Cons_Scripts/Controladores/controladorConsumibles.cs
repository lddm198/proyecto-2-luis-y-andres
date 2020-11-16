using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorConsumibles : MonoBehaviour
{
    public GameObject gema;
    public GameObject jade;
    public GameObject d_or;
    public int cantGema, cantJade, cantD_or;
    public float rangoGenerar = 0f;
    

    private float  spawnTimeGema = 0f,spawnTimeJade = 0f,spawnTimeD_or = 0f ;

    void Start(){
        for (int x = 0; x < cantGema; x++)
        {
            InvokeRepeating("generarGema",0.0f,spawnTimeGema);
        }
        for (int i = 0; i < cantJade; i++)
        {
            InvokeRepeating("generarJade",0.0f,spawnTimeJade);
        }
        for (int j = 0; j < cantD_or; j++)
        {
            InvokeRepeating("generarD_or",0.0f,spawnTimeD_or);
        }
        
            
    }
    void Update()
    {
        
    }
    public void generarGema(){
        
        
        Vector3 spawnGema = new Vector3(0,0,0);
        spawnGema = this.transform.position + Random.onUnitSphere * rangoGenerar;
        spawnGema = new Vector3(spawnGema.x, spawnGema.y,160);

        GameObject Gema = Instantiate (gema,spawnGema,Quaternion.identity);
         
    }
    public void generarJade(){

        Vector3 spawnJade = new Vector3(0,0,0);
        spawnJade = this.transform.position + Random.onUnitSphere * rangoGenerar;
        spawnJade = new Vector3(spawnJade.x, spawnJade.y,160);

        GameObject Jade = Instantiate (jade,spawnJade,Quaternion.identity);
         
    }
    public void generarD_or(){
        
        Vector3 spawnD_or = new Vector3(0,0,0);
        spawnD_or = this.transform.position + Random.onUnitSphere * rangoGenerar;
        spawnD_or = new Vector3(spawnD_or.x, spawnD_or.y,160);
        
        GameObject D_or = Instantiate (d_or,spawnD_or,Quaternion.identity);
         
    }
}
