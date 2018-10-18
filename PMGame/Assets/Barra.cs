using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra : MonoBehaviour {

	public RectTransform[] posicoes;
	public List <RectTransform> programasAbertos = new List<RectTransform> ();
	public RectTransform fora_da_tela;

	public void AbriuPrograma (RectTransform janelaAberta) {
		programasAbertos.Add (janelaAberta);
		int indice = programasAbertos.Count - 1;
		janelaAberta.anchoredPosition = posicoes [indice].anchoredPosition;
	}

	public void FecharPrograma (RectTransform janelaFechada) {
		janelaFechada.anchoredPosition = fora_da_tela.anchoredPosition;
		programasAbertos.Remove (janelaFechada);
		ReorganizaBarra ();
	}

	void ReorganizaBarra () {
		for (int i = 0; i < programasAbertos.Count; i++) {
			programasAbertos [i].anchoredPosition = posicoes [i].anchoredPosition;
		}
	}


}
