using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour {
    float contador=0;
    public float velocidad = 1;
   // float contadorcolicion = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        contador = contador + 1 * Time.deltaTime;
        this.transform.Translate(velocidad * Time.deltaTime, 0, 0);
        if (contador>3) { Destroy(this.gameObject); }

       
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "enemigo")
        {
            if (contador<2.9f) { contador = 3f; }
        }
        if (other.tag == "boss")
        {
            if (contador < 2.9f) { contador = 3f; }
        }

    }
}
