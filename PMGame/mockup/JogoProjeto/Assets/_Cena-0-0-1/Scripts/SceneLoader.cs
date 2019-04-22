using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	void Start () {
		StartCoroutine (CarregaCena ());
	}
		
	IEnumerator CarregaCena () {
		AsyncOperation carrgaCena = SceneManager.LoadSceneAsync ("Cena-0-0-1");

		while (!carrgaCena.isDone) {
			yield return null;
		} 
	}
}
