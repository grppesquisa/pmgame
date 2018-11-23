using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Balao : MonoBehaviour {

	RectTransform rt;
	TextMeshProUGUI texto;

	float ajuste = 10f;
	bool isFalaMinha;

	public Color eu;
	Vector3 normal = Vector3.one; 
	public Color ele;
	Vector3 invertido = new Vector3 (-1f, 1f, 1f);

	public TextoChat mensagem;

	void Start () {
		rt = GetComponent<RectTransform> ();
		texto = GetComponentInChildren<TextMeshProUGUI> ();
		texto.text = mensagem.texto;
		isFalaMinha = mensagem.isFalaMinha;


	}
	

	void Update () {
		rt.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, texto.preferredHeight + ajuste);

		if (isFalaMinha) {
			rt.gameObject.GetComponent<Image> ().color = eu;
			rt.localScale = normal;
			texto.rectTransform.localScale = normal;
		} else {
			rt.gameObject.GetComponent<Image> ().color = ele;
			rt.localScale = invertido;
			texto.rectTransform.localScale = invertido;
		}
	}


}
