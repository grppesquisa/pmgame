using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figura : MonoBehaviour {

	MeshRenderer papel;
	WWW www;

	public bool gatoAleatório = true;	// true mostra um gato aleatório de cataas.com, false mostra o PNG gráficos (esse PNG tem que estar na pasta Resources para ser carregado com Resources.Load)

	IEnumerator Start () {
		papel = GetComponent <MeshRenderer> ();
		if (gatoAleatório) {
			string url = "https://cataas.com/c";
		
			using (WWW www = new WWW (url)) {
				yield return www;
				papel.material.mainTexture = www.texture;
			}
		} else {
			papel.material.mainTexture = Resources.Load ("Graficos") as Texture;
		}
	}
}






