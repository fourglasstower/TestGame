using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paredes : MonoBehaviour {
    public static string chekadorcolicion="no";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
     

        if (other.tag == "paredizquierda")
        {
            personaje.activadorcorreriz = "no";
            
        }
        if (other.tag == "paredderecha")
        {
            personaje.activadorcorrerde = "no";
          
        }
        
       
            if (other.tag == "pasillo")
            {
                personaje.activadorcorreriz = "no";
                personaje.activadorcorrerde = "no";
                chekadorcolicion = "si";
            }
          
       
       
        //---------------------------------------------------

        // nombrecolision = other.name;
    }
    private void OnTriggerExit(Collider other)
    {

      

        if (other.tag == "paredizquierda")
        {
            personaje.activadorcorreriz = "si";
        }
        if (other.tag == "paredderecha")
        {
            personaje.activadorcorrerde = "si";
            chekadorcolicion = "no";
        }

        if (other.tag == "pasillo")
        {
            personaje.activadorcorreriz = "si";
            personaje.activadorcorrerde = "si";
            chekadorcolicion = "no";
        }
      

    }

}
