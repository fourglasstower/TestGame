using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour {
    public static string seguir = "si";
    public GameObject personaje;
     float speed = 0;
    public float velocidad = 0;
    public float distancia = 0;
    public float valor1, valor2,valor3;
    Vector3 dir;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        valor1 = this.transform.position.x-personaje.transform.position.x;
        if (valor1<0) { valor1 = valor1 * -1; }

        valor2 = this.transform.position.y - personaje.transform.position.y;
        if (valor2 < 0) { valor2 = valor2 * -1; }

        valor3 = valor1 + valor2;
        //valor3 = valor3/2;
        speed = valor3 +velocidad;
        
        if (seguir == "si") { if (valor3>1) { controlsuave(); } }
        
        else { }

       
    }

    void controlsuave()
    {
        dir = (personaje.transform.position - this.transform.position).normalized;

        this.transform.position = this.transform.position + (dir * speed) * Time.deltaTime;
    }
}
