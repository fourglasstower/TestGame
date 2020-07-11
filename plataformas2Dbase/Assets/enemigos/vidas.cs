using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidas : MonoBehaviour {
    public GameObject v1, v2, v3, v4, v5;
    public static int vidaactual = 3;
    public int level=0;
    // Use this for initialization
    void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        if (vidaactual > 0) { v1.SetActive(true); } else { v1.SetActive(false); }
        if (vidaactual > 1) { v2.SetActive(true); } else { v2.SetActive(false); }
        if (vidaactual > 2) { v3.SetActive(true); } else { v3.SetActive(false); }
        if (vidaactual > 3) { v4.SetActive(true); } else { v4.SetActive(false); }
        if (vidaactual > 4) { v5.SetActive(true); } else { v5.SetActive(false); }
        if (vidaactual<1) { vidaactual = 3; Application.LoadLevel(level); }
    }
}
