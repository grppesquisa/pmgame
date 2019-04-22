using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {

	LayerMask mask_clicavel;

	void Start () {
		mask_clicavel = LayerMask.GetMask ("Clicavel");
	}
	

	void Update () {
		Ray raio; 
		raio = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		Debug.DrawRay (raio.origin, raio.direction, Color.red);

		if (Physics.Raycast(raio, out hit, 100f, mask_clicavel)) {
			Debug.DrawLine (raio.origin, hit.point, Color.green);

			if (Input.GetButtonDown ("Fire1")) {
				hit.collider.gameObject.SendMessage ("Foca");
			}
			
		}
		
	}
}
