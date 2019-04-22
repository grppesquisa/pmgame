using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controles : MonoBehaviour {

	void Update () {
		if (Input.GetButton("Cancel")) {
			Application.Quit ();
		}	
	}
}
