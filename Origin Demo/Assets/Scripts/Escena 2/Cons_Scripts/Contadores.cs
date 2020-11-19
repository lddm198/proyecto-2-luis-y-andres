using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contadores : MonoBehaviour
{
    public Text marcadorDinero;
    public Text marcadorComida ;
    public Text marcadorGema ;
    public Text marcadorJade;
    public Text marcadorDor;
    private int cantDinero;
    private int cantComida;
    private int cantGema;
    private int cantJade;
    private int cantDor;

    

    void OnTriggerStay2D(Collider2D obj){

        if (obj.tag == "Moneda")
        {
            cantDinero += 1;
            marcadorDinero.text = "x " + cantDinero;
            Debug.Log(cantDinero);
        }
        if (obj.tag == "Saco")
        {
            cantDinero += 10;
            marcadorDinero.text = "x " + cantDinero;
            Debug.Log(cantDinero);
        }
        if (obj.tag == "Gema")
        {
            cantGema += 1;
            marcadorGema.text = "x " + cantGema;
            Debug.Log(cantGema);
        }
        if (obj.tag == "Jade")
        {
            cantJade += 1;
            marcadorJade.text = "x " + cantJade;
            Debug.Log(cantJade);
        }
        if (obj.tag == "Dor")
        {
            cantDor += 1;
            marcadorDor.text = "x " + cantDor;
            Debug.Log(cantDor);
        }
        if (obj.tag == "Cereza")
        {
            cantComida += 1;
            marcadorComida.text = "x " + cantComida;
            Debug.Log(cantComida);
        }
        if (obj.tag == "Sandia")
        {
            cantComida += 1;
            marcadorComida.text = "x " + cantComida;
            Debug.Log(cantComida);
        }
        if (obj.tag == "Manzana")
        {
            cantComida += 1;
            marcadorComida.text = "x " + cantComida;
            Debug.Log(cantComida);
        }

    } 

    public void ActualizarCont()
    {
        marcadorDinero.text = "x " + cantDinero;
        marcadorGema.text = "x " + cantGema;
        marcadorJade.text = "x " + cantJade;
        marcadorDor.text = "x " + cantDor;
        marcadorComida.text = "x " + cantComida;
    }

    public int cantComidaDis(){return cantComida;}
    public void consumir(int cant){cantComida-=cant;}

}

        
