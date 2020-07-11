using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balae2 : MonoBehaviour {
    float contador = 0;
    public float velocidad = 1;
    Vector3 dir;
    // Use this for initialization
    void Start () {
        dir = (personaje.posicionactual - this.transform.position).normalized;
    }
	
	// Update is called once per frame
	void Update () {
        contador = contador + 1 * Time.deltaTime;
      


       
        this.transform.position = this.transform.position + (dir * velocidad) * Time.deltaTime;

        if (contador > 3) { Destroy(this.gameObject); }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "daños")
        {
            if (contador < 2.9f) { if (personaje.invulneravilidad > personaje.tiempoinmune) { personaje.invulneravilidad = 0; vidas.vidaactual--; } contador = 3f; }

        }


    }
}
