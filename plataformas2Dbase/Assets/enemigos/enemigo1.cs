using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo1 : MonoBehaviour {
    public float vida = 10;
    string contacto = "no";
    public GameObject alma;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (vida<1) { Instantiate(alma, this.transform.position, this.transform.rotation); Destroy(this.gameObject); }
        if (contacto=="si") { if (personaje.invulneravilidad > personaje.tiempoinmune) { personaje.invulneravilidad = 0; vidas.vidaactual--; } }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "bala")
        {
            vida--;
        }

        if (other.tag == "daños")
        {
            contacto = "si";
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "daños")
        {
            contacto = "no";
        }
           
    }


 }
