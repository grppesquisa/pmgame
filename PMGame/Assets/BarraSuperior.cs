using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class BarraSuperior : MonoBehaviour , IDragHandler {

	public RectTransform retangulo;
	public JanelaHandler janela;

	Image img;
	TextMeshProUGUI titulo;

	public Color sem_foco;
	public Color com_foco;

	void Start () {
		img = GetComponent<Image> ();
		titulo = GetComponentInChildren<TextMeshProUGUI> ();
		titulo.text = gameObject.transform.parent.name;
	}

	void Update () {
		if (transform.parent.GetSiblingIndex() == transform.parent.parent.childCount - 1) {
			img.color = com_foco;
		} else {
			img.color = sem_foco;
		}
	}

	public void OnDrag (PointerEventData eventData) {
		if (!janela.isMaximizado) {
			Vector2 delta = eventData.delta;
			retangulo.anchoredPosition += delta;
		}		
	}
}
