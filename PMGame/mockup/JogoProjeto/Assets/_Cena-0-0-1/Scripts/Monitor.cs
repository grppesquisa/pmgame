using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour {

	public CameraControle cam;

	void Foca() {
		cam.MoveCamera (cam.monitor);
	}
}
