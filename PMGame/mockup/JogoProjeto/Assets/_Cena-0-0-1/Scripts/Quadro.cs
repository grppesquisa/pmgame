using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quadro : MonoBehaviour {

	public CameraControle cam;

	bool focaQuadro = false;

	void Foca() {
		if (!focaQuadro) {
			cam.MoveCamera (cam.quadro);
			focaQuadro = true;
		} else {
			cam.MoveCamera (cam.principal);
			focaQuadro = false;
		}
	}
}
