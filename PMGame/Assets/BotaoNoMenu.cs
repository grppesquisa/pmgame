using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BotaoNoMenu : MonoBehaviour {
//	Script que controla o funcionamento do botão no menu iniciar.
	public Transform programa;	// Janela a que o botão está ligado, definido no Editor.
	RectTransform janela_Rect;	// O componente RectTransform para controlar o tamanho e a posição da janela.
	JanelaHandler janela;		// O JanelaHandler da janela a que o botão está ligado.
	TextMeshProUGUI nomeBotao;	// Acessa o texto que aparece no botão. Talvez na versão final seja melhor um ícone, ou até mesmo um ícone e o nome da janela.

	void Start () {
		gameObject.name = "Botão " + programa.name;					// Nomeia o botão no hierarchy do Editor como "Botão" + o nome da janela. Não tem utilidade fora, mas deixa mais organizado quando se esta no Editor.
		nomeBotao = GetComponentInChildren <TextMeshProUGUI> ();
		nomeBotao.text = programa.name;								// Define o texto do botão como o nome da janela.
		janela_Rect = programa.GetComponent<RectTransform> ();		// Acessa o RectTransform da janela.
		janela = programa.GetComponent<JanelaHandler> ();			// Acessa o JanelaHandler da janela a que o botão está ligado.
	}


//	Define o que um click no botão faz. Se a janela não estiver aberta, coloca ela numa posição que apareça na tela. Essa posição é, dentro de um limite, aleatória.
//	Se a janela já estiver aberta, faz ela ficar por cima das outras.
	public void Click() {
		if (!janela.isAberto) {
			janela.NovoTamanho (janela_Rect.rect.size, new Vector2 (Random.Range (5f, 400f), Random.Range (710f, 280f)));	// Acessa o método NovoTamanho no JanelaHandler da janela, passando o tamanho atual da janela e uma posição aleatória.
			programa.SetAsLastSibling ();		// Coloca a janela como último child. Isso faz com que seja renderezida por último, ficando como a janela mais por cima.
			janela.Abrir ();					// Acessa o método Abrir no JanelaHandler da janela, que trata a questão de, por exemplo, inserir o botão na barra inferior.
			janela.isVisivel = true;			
		} else {
			programa.SetAsLastSibling ();		// Coloca a janela como último child. Isso faz com que seja renderezida por último, ficando como a janela mais por cima.
			if (!janela.isVisivel) {			// Se a janela estiver aberta e não estiver visível quer dizer que ela está minimizada, então se acessa o método que restaura o tamanho da janela.
				janela.DesMinimiza ();
			}
		}
	}
}
