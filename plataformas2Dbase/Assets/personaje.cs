using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaje : MonoBehaviour {
    public Vector3 scaleChange;
    public GameObject dañoscolider;

    public static Vector3 posicionactual;
   public static float invulneravilidad = 0;
    public static float tiempoinmune = 1;
    Vector3 posicion;
    private Animator anim;
    public GameObject animator;
    public float velocidad = 1;
    float velocidadnormal=0;
    public float velocidadagachada = 1;
    public float velocidadsalto = 1;
    public GameObject iz,de,iz2,de2,izal,deal,izal2,deal2;
    public string nombrecolision = "";
    public string activadorsalto = "caida";
    
    public static float contadorsalto = 0;
    public float altura = 0.5f;
    public static float maximosalto = 3;
    public string saltando = "si";

    public string caminando = "no";
    public static string activadorcorreriz = "si";
    public static string activadorcorrerde = "si";

    public GameObject colicionadorpos;
    //codigo de las fases para el movimiento-----------
    public string daños = "no";
    public string instancia = "normal";
    public string accion = "normal";

    //-------------------------------------
    float brincorelog = 0;
    string direcionactual = "ninguna";

    //bala----------
    public GameObject bala;
    public GameObject posbala;

    //lllagachada
    public static string activadoragachada = "no";
    float contadoragachada = 0;

    //plataforma
    public static string activadorplataforma = "no";
    public GameObject posalreves, posnormal;
    public static string posactual = "normal";
    // Use this for initialization

    //fases
    string estadomomentanio="normal";
    float guardarvelocidad = 0;
    float guardarsalto = 0;
    float guardararastrarse = 0;
    void Start () {
        scaleChange = dañoscolider.transform.localScale;


        guardarvelocidad = velocidad;
        guardarsalto = velocidadsalto;
        guardararastrarse = velocidadagachada;

        maximosalto = altura;
        anim = animator.GetComponent<Animator>();
        velocidadnormal = velocidad;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (vidas.estado == "lento")
        { velocidad = guardarvelocidad / 2; }
            if (estadomomentanio == "normal") { if (vidas.estado == "lento") {  velocidadsalto = guardarsalto / 2; velocidadagachada = guardararastrarse / 2; estadomomentanio = "lento"; } }
        else
        { if (vidas.estado == "normal") { velocidad = guardarvelocidad; velocidadsalto = guardarsalto; velocidadagachada = guardararastrarse; estadomomentanio = "normal"; } }
       
        

        posicionactual = this.transform.position;
        invulnerable();
        brincorelog = brincorelog + 1 * Time.deltaTime;
        correr();
         salto(); 
        balasos();
        agacharse();
        plataformas();
        //codigo de las fases para el movimiento-----------
        if (daños=="si")
        {
           
        }
        if (daños == "no")
        {
            if (instancia == "arriba")
            {
                if (accion == "salto")
                {
                    anim.SetInteger("fase", 2);
                }
                if (accion == "caida")
                {
                    anim.SetInteger("fase", 3);
                }
                if (accion == "accion1")
                {

                }
            }
            if (instancia == "normal")
            {
                if (accion == "correr")
                {
                     anim.SetInteger("fase", 1); 
                }
                if (accion == "standby")
                {
                    anim.SetInteger("fase", 0);
                }
                if (accion == "accion1")
                {

                }
            }
            if (instancia == "abajo")
            {
                if (accion == "standby")
                {
                    anim.SetInteger("fase", 4);
                }
                if (accion == "correr")
                {
                    anim.SetInteger("fase", 5);
                }
            }
        }

        //------------------------------------------------------
        
        

        ///-----------------------------------------------------------------------------
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="piso")
        {
            instancia = "normal";
            activadorsalto = "si";
            saltando = "no";

            brincorelog = 0;
            //reposisionamiento automatico----------------------------
            posicion = this.transform.position;
            if (posactual=="normal") { posicion.y = other.transform.position.y + 0.7f; }
            if (posactual == "alreves") { posicion.y = other.transform.position.y - 0.7f; }

            this.transform.position = posicion;
        }

        if (other.tag=="plataforma") { activadorplataforma = "si"; }
        if (other.tag=="laba") { vidas.vidaactual = 0; }

        //---------------------------------------------------

        // nombrecolision = other.name;
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "piso")
        {
            activadorsalto = "no";
            if (saltando == "no") { saltando = "si"; contadorsalto = maximosalto; }
        }

        if (other.tag == "plataforma") { activadorplataforma = "no";  }
    }

    public void salto()
    {
        
            if (brincorelog>0.1)
            {
                if (activadorsalto == "si")
                {
                if (instancia=="normal")
                {

                    if (Input.GetKeyDown(KeyCode.W)) { contadorsalto = 0; saltando = "si"; }
                    if (Input.GetKeyDown(KeyCode.K)) { contadorsalto = 0; saltando = "si"; }


                }


            }
            }
           


        
        contadorsalto = contadorsalto + 1 * Time.deltaTime;

        if (saltando == "si")
        {
            instancia = "arriba";
            if (contadorsalto < maximosalto) { this.transform.Translate(0, velocidadsalto * Time.deltaTime, 0); accion = "salto"; } else { this.transform.Translate(0, -velocidadsalto * Time.deltaTime, 0); accion = "caida"; }
            //  if (contadorsalto >= maximosalto) { activadorsalto = "caida"; }

        }
      

    }
 
    public void correr()
    {

        //caminar----------------------------------------------------------------------
        caminando = "no";
        if (Input.GetKey(KeyCode.A))
        {
            if (vidas.estado=="normal") { if (direcionactual == "ninguna") { direcionactual = "izquierda"; } }
            if (vidas.estado == "lento") { if (direcionactual == "ninguna") { direcionactual = "izquierda"; } }
            if (vidas.estado == "descontrol") { if (direcionactual == "ninguna") { direcionactual = "derecha"; } }

        }
        if (Input.GetKey(KeyCode.D))
        {
            if (vidas.estado == "normal") { if (direcionactual == "ninguna") { direcionactual = "derecha"; } }
            if (vidas.estado == "lento") { if (direcionactual == "ninguna") { direcionactual = "derecha"; } }
            if (vidas.estado == "descontrol") { if (direcionactual == "ninguna") { direcionactual = "izquierda"; } }
        }
        if (direcionactual=="izquierda")
        {
            if (activadorcorreriz == "si") { this.transform.Translate(velocidad * Time.deltaTime, 0, 0); }
            if (posactual=="normal")
            {
                this.transform.rotation = iz.transform.rotation;
                animator.transform.rotation = iz2.transform.rotation;
            }
            if (posactual == "alreves")
            {
                this.transform.rotation = izal.transform.rotation;
                animator.transform.rotation = deal2.transform.rotation;
            }

            caminando = "si";
        }
        if (direcionactual == "derecha")
        {
            if (activadorcorrerde == "si") { this.transform.Translate(velocidad * Time.deltaTime, 0, 0); }
            if (posactual == "normal")
            {
                this.transform.rotation = de.transform.rotation;
                animator.transform.rotation = de2.transform.rotation;
            }
            if (posactual == "alreves")
            {
                this.transform.rotation = deal.transform.rotation;
                animator.transform.rotation = izal2.transform.rotation;
            }

            caminando = "si";
        }
              
        direcionactual = "ninguna";

        if (caminando == "si") { accion = "correr"; }
        if (caminando == "no") { accion = "standby"; }
        ///-----------------------------------------------------------------------
    }
    public void balasos()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Instantiate(bala,posbala.transform.position,this.transform.rotation);

        }
    }
    public void agacharse()
    {
        contadoragachada = contadoragachada + 1 * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
        {
            scaleChange.y = 3f;
            dañoscolider.transform.localScale = scaleChange;
            if (instancia=="normal")
            {
                instancia = "abajo";

                
            }
            if (instancia=="abajo")
            {
                contadoragachada = 0; velocidad = velocidadagachada; activadoragachada = "si";
                if (paredes.chekadorcolicion == "si") { activadorcorreriz = "si"; activadorcorrerde = "si"; }
            }
        }
        if (instancia == "abajo")
        {
            if (paredes.chekadorcolicion=="no")
            {
                
                if (contadoragachada > 0.1f)
                {
                    instancia = "normal"; velocidad = velocidadnormal; activadoragachada = "no";
                    scaleChange.y = 5.3f;
                    dañoscolider.transform.localScale = scaleChange;
                }
            }
            
        }
       
    }

    public void plataformas()
    {
        
            if (Input.GetKeyDown(KeyCode.J))
            {
              if (activadorplataforma == "si")
              {

                if (posactual=="normal")
                {
                    this.transform.Translate(0, 5, 0);
                    //accion = "salto";
                    activadorplataforma = "no";
                    posactual = "alreves";
                    this.transform.rotation = posalreves.transform.rotation;
                 
                }
              

              }

              if (activadorplataforma == "si")
              {

                
                if (posactual == "alreves")
                {
                    this.transform.Translate(0, 5, 0);
                   // accion = "salto";
                    activadorplataforma = "no";
                    posactual = "normal";
                    this.transform.rotation = posnormal.transform.rotation;
                   
                }

              }
            }

    }
    void invulnerable()
    {
        invulneravilidad = invulneravilidad + 1 * Time.deltaTime;

    }

}
