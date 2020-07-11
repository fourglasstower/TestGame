using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corazones : MonoBehaviour {
    float contador = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        contador = contador + 1 * Time.deltaTime;
        if (contador < 0.4f) { this.transform.Translate(0, 0.2f * Time.deltaTime, 0); }
        if (contador >= 0.4f) { this.transform.Translate(0, -0.2f * Time.deltaTime, 0); }
        if (contador >= 0.76f) { contador = 0; }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "daños")
        {
            vidas.vidaactual++; Destroy(this.gameObject);
        }


    }
}
