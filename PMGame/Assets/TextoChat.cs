using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TextoChat {

	public bool isFalaMinha;
	public string texto;

	public TextoChat (string mensagem, bool falaDoJogador) {
		isFalaMinha = falaDoJogador;
		texto = mensagem;
	
	}

}
