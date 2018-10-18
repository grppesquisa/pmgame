using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuIniciar : MonoBehaviour {

	RectTransform selfRect;
	Vector2 delta;

	Vector2 alvo_Posicao;
	Vector2 ref_Posicao;
	public float tempo;


	bool muda_Posicao;

	public bool isVisivel;
	Vector2 menu_Visivel;
	Vector2 menu_Invisivel;


	void Start () {
		selfRect = GetComponent<RectTransform> ();
		delta = selfRect.rect.size;
		delta.x = 0f;

		menu_Visivel = selfRect.anchoredPosition + delta;
		menu_Invisivel = selfRect.anchoredPosition;
	}
	

	void Update () {
		if (muda_Posicao) {
			AtualizaPosicao ();
		} else if (Input.GetButtonDown("Jump")) {
			ClickDeFora ();
		}
	}

	public void Click () {
		if (!isVisivel) {
			alvo_Posicao = menu_Visivel;
			muda_Posicao = true;
			isVisivel = true;						
		} else {
			alvo_Posicao = menu_Invisivel;
			muda_Posicao = true;
			isVisivel = false;		
		}

	}

	void AtualizaPosicao () {

		if (Vector2.Distance (selfRect.anchoredPosition, alvo_Posicao) < 0.5f) {
			muda_Posicao = false;
		}
		else {
			if (selfRect.anchoredPosition != alvo_Posicao) {
				selfRect.anchoredPosition = Vector2.SmoothDamp (selfRect.anchoredPosition, alvo_Posicao, ref ref_Posicao, tempo);
			}
		}

	}

	public void ClickDeFora () {
		if (isVisivel) {
			Click ();
		}
	}
}
