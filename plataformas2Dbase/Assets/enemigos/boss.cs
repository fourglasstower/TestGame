using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour {
    public float valorx1, valorx2, valory1, valory2,valorx,valory,total;
    
    public GameObject barra;
    public float vida=10;
    public GameObject pos1, pos2, pos3, pos4,pos5;
    public float contador = 0;
    public float contadoraccion = 0;
    public string accion = "normal";
    public float valorrandom = 0;
    public GameObject bala,invocacion,invopre;
    public GameObject personajejugador;
    float contadorvida=0;
    public float velocidad = 1;
    Vector3 dir;

    public Vector3 scaleChange;

    private Animator anim;
    public GameObject animator;
    // Use this for initialization
    void Start() {
        scaleChange = barra.transform.localScale;
        anim = animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        morir();
        if (vida>0)
        {

            scalas();
            
            contador = contador + 1 * Time.deltaTime;
            if (contador > 5) { contador = 0; acciones(); anim.SetInteger("fase", 1); }

            realisaraccion();
            if (accion == "normal") { movimiento(); anim.SetInteger("fase", 0); }

        }
      
       
    }

    void acciones ()
    {
        //aqui va el aleatori que desisira que accion ara
        valorrandom = Random.Range(1, 7);
        if (valorrandom == 1) { accion = "disparos"; }
        if (valorrandom == 2) { accion = "invocacion"; }
        if (valorrandom == 3) { accion = "disparos"; }
        if (valorrandom == 4) { accion = "lento"; }
        if (valorrandom == 5) { accion = "gravedad"; }
        if (valorrandom == 6) { accion = "gravedad"; }

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
            if (contadoraccion > 0 && contadoraccion < 0.1) { Instantiate(invopre, pos2.transform.position, pos2.transform.rotation);  }
            if (contadoraccion > 0.2 && contadoraccion < 0.4) { Instantiate(invocacion, pos2.transform.position, pos2.transform.rotation);contadoraccion = 0.5f; }

            if (contadoraccion > 1 && contadoraccion < 1.1) { Instantiate(invopre, pos2.transform.position, pos2.transform.rotation); }
            if (contadoraccion > 1.2 && contadoraccion < 1.4) { Instantiate(invocacion, pos3.transform.position, pos3.transform.rotation); contadoraccion = 1.5f; }

            if (contadoraccion > 2 && contadoraccion < 2.1) { Instantiate(invopre, pos2.transform.position, pos2.transform.rotation); }
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
            if (contadoraccion < 3.4&&contadoraccion>0.3f) { anim.SetInteger("fase", 3); }

            if (contadoraccion > 3.4) {  contadoraccion = 0; accion = "normal"; }
        }
       
    }

    void movimiento()
    {
        valorx1 = this.transform.position.x;
        valory1 = this.transform.position.y;
        if (valorrandom == 1)
        {
            dir = (pos1.transform.position - this.transform.position).normalized;
            valorx2 = pos1.transform.position.x;
            valory2 = pos1.transform.position.y;
            calculo();
        }
        if (valorrandom == 2)
        {
            dir = (pos2.transform.position - this.transform.position).normalized;
            valorx2 = pos2.transform.position.x;
            valory2 = pos2.transform.position.y;
            calculo();
        }
        if (valorrandom == 3)
        {
            dir = (pos3.transform.position - this.transform.position).normalized;
            valorx2 = pos3.transform.position.x;
            valory2 = pos3.transform.position.y;
            calculo();
        }
        if (valorrandom == 4)
        {
            dir = (pos4.transform.position - this.transform.position).normalized;
            valorx2 = pos4.transform.position.x;
            valory2 = pos4.transform.position.y;
            calculo();
        }
        if (valorrandom == 5)
        {
            dir = (pos5.transform.position - this.transform.position).normalized;
            valorx2 = pos5.transform.position.x;
            valory2 = pos5.transform.position.y;
            calculo();
        }


        if (total>10) { this.transform.position = this.transform.position + (dir * velocidad) * Time.deltaTime; }
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
        if (vida<1)
        {
            anim.SetInteger("fase", 3);
            contadorvida = contadorvida + 1 * Time.deltaTime;
            this.transform.position = this.transform.position + (dir * velocidad) * Time.deltaTime;
            dir = (pos5.transform.position - this.transform.position).normalized;
        }
        if (contadorvida>5) { Destroy(this.gameObject); } 
    }
    void calculo()
    {
      
        valorx = valorx1 - valorx2;
        valory = valory1 - valory2;
        if (valorx < 0) { valorx = valorx * -1; }
        if (valory < 0) { valory = valory * -1; }
        total = valorx + valory;
    }
    
    
}
