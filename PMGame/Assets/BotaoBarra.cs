using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BotaoBarra : MonoBehaviour {

//	Script que controla os botões na barra inferior.

	public GameObject prog;	// Janela que o botão é ligado (E-mail, Agenda, etc..). Definido no Editor.

	JanelaHandler janela;
	TextMeshProUGUI texto;	

	void Start () {
		janela = prog.GetComponent<JanelaHandler> ();	// Acessa o script JanelaHandler na janela (prog) à qual o botão é ligado.
		gameObject.name = prog.name + " na Barra";		// Nomeia o botão no hierarchy do Editor como o nome da janela + " na Barra". Não tem utilidade fora, mas deixa mais organizado quando se esta no Editor.
		texto = GetComponentInChildren<TextMeshProUGUI> ();	// Acessa o componente de texto do botão.
		texto.text = prog.name;							// Coloca o nome da janela a qual o botão é ligado como texto do botão. Provavelmente, na vesão final, o interessante seria ter um ícone, não um texto.

	}

//	Determina o comportamento de um click no botão na barra inferior. 
//	Se a janela equivalente estiver na tela (sem estar minimizada) acessa o método no JanelaHandler da janela que traz a mesma para frente. 
//	Caso a janela estiver minimizada, acessa o método que restaura o tamanho da mesma.
	public void Click() {
		if (janela.isVisivel) {
			janela.TrazPraFrente ();
		} else {
			janela.DesMinimiza ();
		}
	}

}
