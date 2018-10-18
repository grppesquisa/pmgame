using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BotaoBarra : MonoBehaviour {

	public GameObject prog;

	JanelaHandler janela;
	TextMeshProUGUI texto;

	void Start () {
		janela = prog.GetComponent<JanelaHandler> ();
		gameObject.name = prog.name + " na Barra";
		texto = GetComponentInChildren<TextMeshProUGUI> ();
		texto.text = prog.name;

	}
		
	public void Click() {
		if (janela.isVisivel) {
			janela.TrazPraFrente ();
		} else {
			janela.DesMinimiza ();
		}
	}

}
