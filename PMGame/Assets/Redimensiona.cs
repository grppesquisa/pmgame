using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Redimensiona : MonoBehaviour , IBeginDragHandler, IDragHandler , IEndDragHandler {

	RectTransform retangulo;
	public RectTransform janela;
	JanelaHandler janelaHandler;

	Vector2 ajuste_Redimensiona;
	Vector2 ajuste_Update;
	Vector2 posicao;

	Vector2 limite;

	bool isRedimensionando;

	void Start () {
		retangulo = GetComponent<RectTransform> ();
		janelaHandler = janela.gameObject.GetComponent<JanelaHandler> ();

		ajuste_Redimensiona = new Vector2 (retangulo.rect.width / 2f, retangulo.rect.height / 2f);
		ajuste_Update = new Vector2 (retangulo.rect.width / 2f, -retangulo.rect.height / 2f);
		limite = new Vector2 (200f, 200f);
	}

	void Update () {
		if (!isRedimensionando) {
			posicao = new Vector2 (janela.rect.width, -janela.rect.height);
			retangulo.anchoredPosition = posicao - ajuste_Update;
		}

	}

	public void OnBeginDrag (PointerEventData eventData) {
		isRedimensionando = true;
		janelaHandler.TrazPraFrente ();
	}

	public void OnDrag (PointerEventData eventData) {
		janelaHandler.isMaximizado = false;
		Vector2 delta = eventData.delta;
		retangulo.anchoredPosition = new Vector2 (Mathf.Clamp (retangulo.anchoredPosition.x + delta.x, limite.x, Mathf.Infinity), Mathf.Clamp (retangulo.anchoredPosition.y + delta.y, -Mathf.Infinity, -limite.y));
		Vector2 posicao_Corrigida = new Vector2 (retangulo.anchoredPosition.x, -retangulo.anchoredPosition.y);
		janela.sizeDelta = posicao_Corrigida + ajuste_Redimensiona;

	
	}

	public void OnEndDrag (PointerEventData eventData) {
		isRedimensionando = false;
	}
}
