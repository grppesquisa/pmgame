using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Relogio : MonoBehaviour {

	TextMeshProUGUI relogio;
	public string hora;
	public string data;

	void Start () {
		relogio = GetComponent<TextMeshProUGUI> ();	
	}
	

	void Update () {
		hora = System.DateTime.Now.ToString ("HH:mm");
		data = System.DateTime.Now.ToString ("dd/MM/yyyy");

		relogio.text = hora + "\n" + data;
	}
}
