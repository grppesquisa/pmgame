using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class RespostasFromTwine {

	public string texto;
	public int pid;

	public RespostasFromTwine (string textoBalao, int pidAlvo) {

		texto = textoBalao;
		pid = pidAlvo;

	}
}
