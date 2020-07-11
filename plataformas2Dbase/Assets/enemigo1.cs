using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo1 : MonoBehaviour {
    public float vida = 10;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (vida<1) { Destroy(this.gameObject); }

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "bala")
        {
            vida--;
        }


    }
}
