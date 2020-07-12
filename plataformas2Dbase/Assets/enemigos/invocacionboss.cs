using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invocacionboss : MonoBehaviour {
    public GameObject corazon;
    float contador = 0;
    public float vida = 10;
    public float velocidad = 1;
    Vector3 dir;
    // Use this for initialization
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        contador = contador + 1 * Time.deltaTime;



        dir = (personaje.posicionactual - this.transform.position).normalized;
        this.transform.position = this.transform.position + (dir * velocidad) * Time.deltaTime;

        if (contador > 15) { Destroy(this.gameObject); }

        if (vida < 1) { Instantiate(corazon, this.transform.position, this.transform.rotation); Destroy(this.gameObject); }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "daños")
        {
            if (contador < 14.9f) { if (personaje.invulneravilidad > personaje.tiempoinmune) { personaje.invulneravilidad = 0; vidas.vidaactual--; } contador = 15f; }

        }

        if (other.tag == "bala")
        {
            vida--;
        }


    }
}
