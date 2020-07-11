using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigodetector : MonoBehaviour {
    public string lado = "ninguno";
    public GameObject iz, de;
    public GameObject basenemigo;
    public GameObject bala;
    public string detectado="ninguno";
    public string fase = "normal";

    public float velocidad = 1;
    public float ciclo=3;
    float timeciclo = 0;
    string direcion = "derecha";

    public float velocidaddisparo=0.4f;
    float contadordisparo=0.3f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
        if (fase=="normal") { normal(); }
        if (fase == "atacar") { atacar(); }

    }
    private void OnTriggerEnter(Collider other)
    {
        detectado = other.name;
        if (other.name=="personaje") { fase = "atacar"; }
    }
    private void OnTriggerExit(Collider other)
    {
        
        if (other.name == "personaje") { fase = "normal"; }
    }

    void normal()
    {
        basenemigo.transform.Translate(velocidad * Time.deltaTime, 0, 0);
        if (direcion == "derecha") { basenemigo.transform.rotation = iz.transform.rotation; }
        if (direcion == "izquierda") { basenemigo.transform.rotation = de.transform.rotation; }
        timeciclo = timeciclo + 1 * Time.deltaTime;
        if (timeciclo > ciclo)
        {
            if (direcion=="derecha") { direcion = "izquierda"; timeciclo = 0; }         
           
        }
        if (timeciclo > ciclo)
        {          
            if (direcion == "izquierda") { direcion = "derecha"; timeciclo = 0; }
        
        }
    }
    void atacar()
    {
        contadordisparo = contadordisparo + 1 * Time.deltaTime;
        if (contadordisparo>velocidaddisparo) { contadordisparo = 0; Instantiate(bala, basenemigo.transform.position, basenemigo.transform.rotation); }
        
    }
}
