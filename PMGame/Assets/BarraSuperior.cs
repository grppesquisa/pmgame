using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class BarraSuperior : MonoBehaviour , IDragHandler {
//	Script que controla a barra superior de cada janela.
//	Muda a cor da barra para indicar que é a janela ativa e move a janela quando clica e arrasta pela barra, bem como define o título da janela.
	public RectTransform retangulo;		// O RectTransform da janela, que determina o tamanho e a posição.
	public JanelaHandler janela;		// O JanelaHandler da janela a qual a barra pertence.

	Image img;							// Imagem que aparece na barra superior. É basicamente um quadrado, mas é a imagem que dará, por exemplo, cantos arredondados para a barra. Ou talvez um degradê.
	TextMeshProUGUI titulo;				// Componente de texto que é o título da janela que aparecerá na barra.

	// As cores a serem usadas na barra das janelas: com_foco apenas para a janela ativa e sem_foco para as demais. As cores são definidas no Editor.
	public Color sem_foco;
	public Color com_foco;

	void Start () {
		img = GetComponent<Image> ();
		titulo = GetComponentInChildren<TextMeshProUGUI> ();
		titulo.text = gameObject.transform.parent.name;		// Define o nome a ser exibido na barra como o nome da respectiva janela. A barra superior é child do objeto com o nome da janela (Chat ou Agenda, por exemplo). Assim, o texto a ser exibido é o nome do parent do objeto que tem esse script.
	}

	void Update () {
		// Define a cor da barra com base na posição da janela no Hierarchy. Esse script está num objeto que é child do janela. Esse objeto, por sua vez, é child de um outro que contém todas as janelas.
		// Assim o que é levado em conta é a posição do parent desse objeto dentro do objeto (Janelas) que contém todas as janelas, por isso "transform.parent.parent.childCount". 
		// Se o SiblingIndex for igual ao número de children -1 quer dizer que o objeto que é parent da barra superior é o último e está por cima, sendo considerado a janela ativa.
		// O -1 é porque childCount retorna a quantidade de children e o SiblingIndex começa em zero. Ou seja, se o childCount for 2 quer dizer que tem o child 0 e o child 1.
		if (transform.parent.GetSiblingIndex() == transform.parent.parent.childCount - 1) {
			img.color = com_foco;
		} else {
			img.color = sem_foco;
		}
	}

	// Se a janela não estiver maximizada e ocorrer um drag na barra superior é aplicado o delta do deslocamento à posição da janela em relação ao ponto de âncora.
	public void OnDrag (PointerEventData eventData) {
		if (!janela.isMaximizado) {
			Vector2 delta = eventData.delta;
			retangulo.anchoredPosition += delta;
		}		
	}
}
