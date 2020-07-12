using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour {
    public GameObject barra;
    float vida=80;
    public GameObject pos1, pos2, pos3, pos4,pos5;
    public float contador = 0;
    public float contadoraccion = 0;
    public string accion = "normal";
    public float valorrandom = 0;
    public GameObject bala,invocacion;
    public GameObject personajejugador;

    public float velocidad = 1;
    Vector3 dir;

    public Vector3 scaleChange;
    // Use this for initialization
    void Start() {
        scaleChange = barra.transform.localScale;
    }

    // Update is called once per frame
    void Update() {
        scalas();
        morir();
        contador = contador + 1 * Time.deltaTime;
        if (contador>5) { contador = 0; acciones(); }

        realisaraccion();
        if (accion == "normal") { movimiento(); }
       
    }

    void acciones ()
    {
        //aqui va el aleatori que desisira que accion ara
        valorrandom = Random.Range(1, 6);
        if (valorrandom == 1) { accion = "disparos"; }
        if (valorrandom == 2) { accion = "invocacion"; }
        if (valorrandom == 3) { accion = "disparos"; }
        if (valorrandom == 4) { accion = "lento"; }
        if (valorrandom == 5) { accion = "lento"; }

        //prueba
        //accion = "lento";
    }

    void realisaraccion()
    {
        if (accion != "normal") { contadoraccion = contadoraccion + 1 * Time.deltaTime; }


        if (accion == "disparos")
        {
            if (contadoraccion > 0.2 && contadoraccion < 0.4) { Instantiate(bala, this.transform.position, this.transform.rotation); }
            if (contadoraccion > 1.2 && contadoraccion < 1.4) { Instantiate(bala, this.transform.position, this.transform.rotation); }
            if (contadoraccion > 2.2 && contadoraccion < 2.4) { Instantiate(bala, this.transform.position, this.transform.rotation); }
            if (contadoraccion > 2.4) { contadoraccion = 0; accion = "normal"; }

        }
        if (accion == "invocacion")
        {
            if (contadoraccion > 0.2 && contadoraccion < 0.4) { Instantiate(invocacion, pos2.transform.position, pos2.transform.rotation);contadoraccion = 0.5f; }
            if (contadoraccion > 1.2 && contadoraccion < 1.4) { Instantiate(invocacion, pos3.transform.position, pos3.transform.rotation); contadoraccion = 1.5f; }
            if (contadoraccion > 2.2 && contadoraccion < 2.4) { Instantiate(invocacion, pos4.transform.position, pos4.transform.rotation); contadoraccion = 2.5f; }
            if (contadoraccion > 2.4) { contadoraccion = 0; accion = "normal"; }
        }
        if (accion == "lento")
        {
            if (contadoraccion > 0.2 && contadoraccion < 0.4) {vidas.almas = 0; }
           
            if (contadoraccion > 3.4) {  contadoraccion = 0; accion = "normal"; vidas.almas = 10; }
        }
        if (accion == "descontrol")
        {
            if (contadoraccion > 0.2 && contadoraccion < 0.4) { vidas.estado = "descontrol"; }

            if (contadoraccion > 3.4) { vidas.estado = "normal"; contadoraccion = 0; accion = "normal"; }
        }
        if (accion == "gravedad")
        {
            if (contadoraccion > 0.2 && contadoraccion < 0.3) { personaje.activadorplataforma = "si"; personaje.posactual = "normal"; contadoraccion = 0.3f; }

            if (contadoraccion > 3.4) { personaje.activadorplataforma = "si"; personaje.posactual = "alreves"; contadoraccion = 0; accion = "normal"; }
        }
       
    }

    void movimiento()
    {
        if (valorrandom == 1) { dir = (pos1.transform.position - this.transform.position).normalized; }
        if (valorrandom == 2) { dir = (pos2.transform.position - this.transform.position).normalized; }
        if (valorrandom == 3) { dir = (pos3.transform.position - this.transform.position).normalized; }
        if (valorrandom == 4) { dir = (pos4.transform.position - this.transform.position).normalized; }
        if (valorrandom == 5) { dir = (pos5.transform.position - this.transform.position).normalized; }

        
        this.transform.position = this.transform.position + (dir * velocidad) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "bala")
        {
            vida--;
        }

        if (other.tag == "daños")
        {
            vidas.vidaactual--;
        }
    }

    void scalas()
    {
        scaleChange.x = vida / 4;
        
        barra.transform.localScale = scaleChange;
        // barraalmas.transform.position = posicionbarra;
    }
    void morir()
    {
        if (vida<1) { Destroy(this.gameObject); }
    }
}
