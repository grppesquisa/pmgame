using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citacao : MonoBehaviour {

	TextMesh textMesh;

	void Start () {
		textMesh = GetComponent<TextMesh> ();
		textMesh.text = DefineQuotes ();
		}

	string DefineQuotes () {

		TextAsset quotes_Fonte = Resources.Load<TextAsset> ("Quotes");   // Carrega o txt Quotes, que precisa estar na pasta Resources para ser carregado com Resources.Load
		string[] quotes = quotes_Fonte.text.Split(new char [] { '*' } );

		int qualquer = Random.Range (0, quotes.Length);
		string retorno = quotes[qualquer];
		
		return retorno;
	}

}
