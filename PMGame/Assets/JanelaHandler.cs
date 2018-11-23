using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JanelaHandler : MonoBehaviour {
	// Script que controla a maior parte dos comportamentos da janela (não do conteúdo dela).

	RectTransform selfRT;				// O RectTransform da janela.
	PapelParede papelParede;			// Papel de Parede é o fundo da tela. É importante para saber o tamanho que terá a janela quando for maximizada. Preferi criar um script para ter esse tamanho ao invés de pegar direto o tamanho do RectTransform porque, caso precise de outras coisas posso fazer esse script static e acessar de forma mais fácil.

	public Vector2 size_Maximizado;		
	public Vector2 posicao_Maximizado;

	Vector2 size_Restaurado;
	Vector2 posicao_Restaurado;


	float tempo = 0.05f;		// Tempo usado para definir a velocidade com que a janela é maximizada ou minimizada.

	// Variáveis de referência utilizadas pelo método SmoothDump. Só quem usa é o próprio método.
	Vector2 ref_Tamanho;
	Vector2 ref_Posicao;

	public bool isMaximizado;	// Indica se a janela está maximizada

	// Variáveis usadas nos métodos que fazem a transição de tamanho e posição da janela.
	Vector2 alvo_Tamanho;
	Vector2 alvo_Posicao;
	Vector2 temp_Tamanho;
	Vector2 temp_Posicao;
	bool muda_Tamanho;
	bool muda_Posicao;

	public RectTransform botaoNaBarra;				// RectTransform do botão que representa essa janela na barra inferior.	
	public Barra barra;								// Script que controla a barra inferior.
	public bool isAberto;							// Indica se a janela está aberta ou não.
	Vector2 fora_da_tela = new Vector2 (0f, -100f);	// Posição para onde as janelas vão quando estão fechadas. Ou seja, as janelas não são fechadas de verdade, só são movidas para fora da tela.

	public bool isVisivel;
	Vector2 posicao_Old;

	void Start () {
		selfRT = GetComponent<RectTransform> ();		
		papelParede = GameObject.FindGameObjectWithTag ("Papel de Parede").GetComponent<PapelParede>();

		size_Maximizado = papelParede.size;			// Define o tamanho que a janela terá quando for maximizada.

		// A posição que a janela terá quando for maximizada leva em conta que o pivot point é o canto superior esquerdo e o anchor point é o ponto na margem esquerda logo acima da barra inferior (perto do botão iniciar).
		posicao_Maximizado.x = 0f;					// Define o componente x da posição como 0, ou seja, mesmo x do anchor point (coloado à margem esquerda).
		posicao_Maximizado.y = size_Maximizado.y;	// Define o componente y da posição como o tamanho do papel de parade, que é o tamanho da tela menos a altura da barra inferior.

	}


	void Update () {

		AtualizaTamanho ();
		AtualizaPosicao ();
	}

	void AtualizaTamanho ()
	{
		// Altera gradualmente o tamanho atual enquanto não atinge o tamanho alvo.
		if (muda_Tamanho) {
			// Precisei colocar isso porque quando o tamanho da janela ficava perto do tamanho alvo ficava oscilando porque não chegava exatamente no valor. Assim tem uma pequena tolerência que acabou com a oscilação.
			if (Vector2.Distance (selfRT.rect.size, alvo_Tamanho) < 0.5f) {
				muda_Tamanho = false;
			}
			else {
				temp_Tamanho = Vector2.SmoothDamp (selfRT.rect.size, alvo_Tamanho, ref ref_Tamanho, tempo);	// Define um Vector2 para o tamanho da janela, interpolando gradualmente entre o tamanho atual e o tamanho alvo.
				selfRT.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, temp_Tamanho.x);			// Aplica o componente x definido acima na largura da janela.
				selfRT.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, temp_Tamanho.y);				// Aplica o componente y na altura da janela.
			}
		}
	}
	
	void AtualizaPosicao ()
	{
		// Altera a posição atual de maneira gradual até que alcance a posição alvo.
		if (muda_Posicao) {
			// Precisei colocar isso porque quando a posição da janela ficava perto da posição alvo ficava oscilando porque não chegava exatamente no valor. Assim tem uma pequena tolerência que acabou com a oscilação.
			if (Vector2.Distance (selfRT.anchoredPosition, alvo_Posicao) < 0.5f) {
				muda_Posicao = false;
			}
			else {
				if (selfRT.anchoredPosition != alvo_Posicao) {
					selfRT.anchoredPosition = Vector2.SmoothDamp (selfRT.anchoredPosition, alvo_Posicao, ref ref_Posicao, tempo);	// Interpola uma posição intermediária entre a posição atual e a posição alvo.
				}
			}
		}
	}

	public void MaximizaRestaura ()	{
		if (!isMaximizado) {
			posicao_Restaurado = selfRT.anchoredPosition;
			size_Restaurado = selfRT.rect.size;
			isMaximizado = true;
			NovoTamanho (size_Maximizado, posicao_Maximizado);
		} else {
			isMaximizado = false;
			NovoTamanho (size_Restaurado, posicao_Restaurado);
		}
	}

	public void NovoTamanho (Vector2 novoTamanho, Vector2 novaPosicao) {
		alvo_Tamanho = novoTamanho;
		alvo_Posicao = novaPosicao;

		muda_Tamanho = true;
		muda_Posicao = true;
	}



	public void Fechar () {
		isAberto = false;
		isVisivel = false;
		NovoTamanho (selfRT.rect.size, fora_da_tela);
	}

	public void Minimiza () {
		isVisivel = false;
		posicao_Old = selfRT.anchoredPosition;
		NovoTamanho (selfRT.rect.size, fora_da_tela);
		transform.SetAsFirstSibling ();
	}

	public void DesMinimiza () {
		isVisivel = true;
		NovoTamanho (selfRT.rect.size, posicao_Old);
		TrazPraFrente ();
	}

	public void TrazPraFrente () {
		transform.SetAsLastSibling ();
	}
	
	public void Abrir () {
		barra.AbriuPrograma (botaoNaBarra);
		isAberto = true;
	}
}
