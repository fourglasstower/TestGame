using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubomagico : MonoBehaviour
{
    public GameObject posnormal, posalreves;
    public float velocidad = 1;
    public string pos = "alreves";
    public string cambio = "no";
    public string accion = "no";
    Vector3 dir;
    public float valor1, valor2, valor3;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        valor1 = this.transform.position.y - posnormal.transform.position.y;
        if (valor1 < 0) { valor1 = valor1 * -1; }
        valor2 = this.transform.position.y - posalreves.transform.position.y;
        if (valor2 < 0) { valor2 = valor2 * -1; }

        if (accion=="si")
        {
            if (pos == "alreves") { controlalreves(); }
            if (pos == "normal") { controlnormal(); }
        }
       
        
            if (Input.GetKeyDown(KeyCode.J))
            {

                if (cambio == "si")
                {
                    if (pos == "alreves") { pos = "normal";cambio = "no"; accion = "si"; }
                }

                if (cambio == "si")
                {
                    if (pos == "normal") { pos = "alreves"; cambio = "no"; accion = "si"; }
                }

               
            }
         


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="personaje") { cambio = "si"; }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "personaje") { cambio = "no"; }
    }

    void controlnormal()
    {

        

        dir = (posnormal.transform.position - this.transform.position).normalized;

        this.transform.position = this.transform.position + (dir * velocidad) * Time.deltaTime;
        if (valor1<1) { accion = "no"; }
    }
    void controlalreves()
    {

     

        dir = (posalreves.transform.position - this.transform.position).normalized;

        this.transform.position = this.transform.position + (dir * velocidad) * Time.deltaTime;
        if (valor2 < 0.5) { accion = "no"; }
    }
}
