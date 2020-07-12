using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class preinvo : MonoBehaviour {
    float contador = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        contador = contador + 1 * Time.deltaTime;
        if (contador>0.1f) { Destroy(this.gameObject); }
	}
}
