using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class techos : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "techo")
        {
            personaje.contadorsalto = personaje.maximosalto;
        }
       
        //---------------------------------------------------

        // nombrecolision = other.name;
    }
}
