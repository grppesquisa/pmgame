using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BotaoNoMenu : MonoBehaviour {

	public Transform programa;
	RectTransform janela_Rect;
	JanelaHandler janela;
	TextMeshProUGUI nomeBotao;

	void Start () {
		gameObject.name = "Botão " + programa.name;
		nomeBotao = GetComponentInChildren <TextMeshProUGUI> ();
		nomeBotao.text = programa.name;
		janela_Rect = programa.GetComponent<RectTransform> ();
		janela = programa.GetComponent<JanelaHandler> ();
	}
	
	public void Click() {
		if (!janela.isAberto) {
			janela.NovoTamanho (janela_Rect.rect.size, new Vector2 (Random.Range (5f, 400f), Random.Range (710f, 280f)));
			programa.SetAsLastSibling ();
			janela.Abrir ();
			janela.isVisivel = true;
		} else {
			programa.SetAsLastSibling ();
			if (!janela.isVisivel) {
				janela.DesMinimiza ();
			}
		}
	}
}
