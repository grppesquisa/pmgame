using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra : MonoBehaviour {

//	Script que controla os botões de cada janela na barra inferior. 
//	Basicamente as janela que são abertas (pelos botões do Menu Iniciar) são inseridas na List programasAbertos, através de seus respectivos componetes RectTransform. Quando uma janela é fechada é excluída da List.
//	O método ReorganizaBarra os itens da List nas posições pré-definidas no Editor.

	public RectTransform[] posicoes;	// Array das posicoes que os botoes podem ocupar na barra inferior.  
	public RectTransform fora_da_tela;	// Posição para onde as janelas vão quando estão fechadas ou minimizadas.

	public List <RectTransform> programasAbertos = new List<RectTransform> ();	// Lista das posicoes das janelas consideradas abertas para que elas apareçam na barra. É essa lista que é utilizada para reorganizar a barra quando uma janela é aberta ou fechada.

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
