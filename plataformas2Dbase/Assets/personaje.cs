using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaje : MonoBehaviour {
    public float velocidad = 1;
    public float velocidadsalto = 1;
    public GameObject iz,de;
    public string nombrecolision = "";
    public string activadorsalto = "caida";
    public float contadorsalto = 0;
    public float maximosalto = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (activadorsalto=="salto")
        {
            if (contadorsalto < maximosalto) { salto(); }
            if (contadorsalto >= maximosalto) { activadorsalto = "caida"; }

        }
        if (activadorsalto == "caida")
        {
            caida();

        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(velocidad*Time.deltaTime, 0, 0);
            this.transform.rotation = iz.transform.rotation;

        }
        if (Input.GetKey(KeyCode.D))
        {

            this.transform.Translate(velocidad * Time.deltaTime, 0, 0);
            this.transform.rotation = de.transform.rotation;

        }
        if (Input.GetKey(KeyCode.W))
        {
            if (activadorsalto=="normal") { contadorsalto = 0; activadorsalto = "salto"; }
                

        }
    }

    private void OnTriggerEnter(Collider other)
    {

        nombrecolision = other.name;
    }
    private void OnTriggerExit(Collider other)
    {

        nombrecolision = "salto";
    }

    public void salto()
    {
        contadorsalto = contadorsalto + 1 * Time.deltaTime;
        this.transform.Translate(0, velocidadsalto * Time.deltaTime, 0);

    }
    public void caida()
    {
        
        this.transform.Translate(0, -velocidadsalto * Time.deltaTime, 0);
        if (nombrecolision=="piso") { activadorsalto = "normal"; }
    }
}
