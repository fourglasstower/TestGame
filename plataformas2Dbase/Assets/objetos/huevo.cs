using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huevo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "daños")
        {
            vidas.vidaactual++; vidas.vidaactual++; vidas.vidaactual++;
            vidas.almas++; vidas.almas++; vidas.almas++; vidas.almas++; vidas.almas++; vidas.almas++; vidas.almas++; vidas.almas++;
            vidas.almastotales++; vidas.almastotales++; vidas.almastotales++; vidas.almastotales++; vidas.almastotales++; vidas.almastotales++; vidas.almastotales++;
            Destroy(this.gameObject);
            
        }


    }
}
