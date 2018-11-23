using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TextoChat {

	public bool isFalaMinha;
	public string texto;

//	string[] splitString = theText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

	public TextoChat (string mensagem, bool falaDoJogador) {
		isFalaMinha = falaDoJogador;
		string[] partes = mensagem.Split(new string[] { "\n¢" }, System.StringSplitOptions.None); 
		texto = partes[0];

	}

}
