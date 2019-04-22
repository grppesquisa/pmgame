using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaPaineis : MonoBehaviour {

	public GameObject[] abas;
	public GameObject trava;

	public bool travado = true;

	void Start () {
		TrocaAba (abas [1].name);
	}
	

	void Update () {
		if (travado) {
			trava.SetActive (true);
		} else {
			trava.SetActive (false);
		}
	}

	public void TrocaAba (string aba) {
		// A Aba do computador que for igual a aba é definida ativa, todas as outras são desativadas
		// P.S.: Quando as abas não estão ativas elas não recebem SendMessage... pode ser que tenha que achar outro jeito.
		for (int i = 0; i < abas.Length; i++) {
			if (abas [i].name == aba) {
				abas [i].gameObject.SetActive(true);
			} else {
				abas [i].gameObject.SetActive(false);
			}
		}
	}
}
