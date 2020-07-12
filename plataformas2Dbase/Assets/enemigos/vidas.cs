using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vidas : MonoBehaviour {
    
    public static string estado="normal";
    public static float almas=10;
    public float almass = 10;
    public static float almastotales=0;
    public float alma;
    public GameObject v1, v2, v3, v4, v5,v6;
    public static int vidaactual = 3;
    public int vida = 0;
    public int level=0;
    float contadoralmas=0;
    //enemigos
    float duracion = 0;
    public static Quaternion iz;
    public static Quaternion de;
    public GameObject izquierda, derecha;

    public Vector3 scaleChange;
    public Vector3 posicionbarra;
    public GameObject barraalmas;
   public float valorrandom = 0;
    // Use this for initialization
    void Start () {
        vidaactual = vida;
        almas = almass;
        iz = izquierda.transform.rotation;
        de = derecha.transform.rotation;
        scaleChange = barraalmas.transform.localScale;
        posicionbarra = barraalmas.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        scalas();
        if (almas>0) { contalmas(); }
        estados();
        alma = almas;
        if (vidaactual > 0) { v1.SetActive(true); } else { v1.SetActive(false); }
        if (vidaactual > 1) { v2.SetActive(true); } else { v2.SetActive(false); }
        if (vidaactual > 2) { v3.SetActive(true); } else { v3.SetActive(false); }
        if (vidaactual > 3) { v4.SetActive(true); } else { v4.SetActive(false); }
        if (vidaactual > 4) { v5.SetActive(true); } else { v5.SetActive(false); }
        if (vidaactual > 5) { v6.SetActive(true); } else { v6.SetActive(false); }
        if (vidaactual<1) { vidaactual = 3;  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
        //Application.LoadLevel(level);
        if (vidaactual>6) { vidaactual = 6; }
    }

    void contalmas()
    {
        contadoralmas = contadoralmas + 1 * Time.deltaTime;
        if (contadoralmas>5) { contadoralmas = 0; almas--; }
        
    }

    void estados()
    {
        if (almas < 1)
        {
            if (estado=="normal")
            {
                valorrandom = Random.Range(1, 3);
                if (valorrandom == 1) { estado = "descontrol"; }
                if (valorrandom == 2) { estado = "lento"; }
            }
            

        }
        else
        {
            estado = "normal";

        }
        if (estado!="normal") { duracion = duracion + 1 * Time.deltaTime; }
        if (duracion>10) { duracion = 0;almas = almas + 2;estado = "normal"; }
    }

    void scalas()
    {
        scaleChange.y = almas / 10;
        posicionbarra.x = almas / 10;
        barraalmas.transform.localScale = scaleChange;
       // barraalmas.transform.position = posicionbarra;
    }
}
