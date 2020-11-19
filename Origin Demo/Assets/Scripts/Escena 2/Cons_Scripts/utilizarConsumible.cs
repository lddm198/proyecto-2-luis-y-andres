using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class utilizarConsumible : MonoBehaviour
{

    Contadores cont = new Contadores();
    private Slider vida;
    private float health;
    private float maxHealth;

    void Start(){
        vida = gameObject.GetComponent<Unidad>().sliderVida;
        maxHealth = gameObject.GetComponent<Unidad>().VidaMax;
        
        vida.maxValue=maxHealth;
   }

   void Update(){
        health = gameObject.GetComponent<Unidad>().VidaActual;
        vida.value=health;
        updatePos(vida);
        if (gameObject.tag=="Personaje"){
            if(Input.GetKeyDown(KeyCode.E)){
                Debug.Log(cont.cantComidaDis());
                if (cont.cantComidaDis()>0){
                    regenerarVida(5);
                    cont.consumir(1);
                }
            }
        }
    }

    public void regenerarVida(float regenerar){
        vida.value-= regenerar;
        gameObject.GetComponent<Unidad>().VidaActual = vida.value;
        

    }
    public void updatePos(Slider vida){
        float x=gameObject.transform.position.x, y=gameObject.transform.position.y,z=0f;
        Vector3 follow = new Vector3(x,y-5f,z);
        vida.transform.position = follow;
    }
}





