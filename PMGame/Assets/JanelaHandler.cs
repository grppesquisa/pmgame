using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JanelaHandler : MonoBehaviour {

	RectTransform selfRT;
	PapelParede papelParede;

	public Vector2 size_Maximizado;
	public Vector2 posicao_Maximizado;

	Vector2 size_Restaurado;
	Vector2 posicao_Restaurado;


	float tempo = 0.05f;

	Vector2 ref_Tamanho;
	Vector2 ref_Posicao;

	public bool isMaximizado;

	Vector2 alvo_Tamanho;
	Vector2 alvo_Posicao;

	Vector2 temp_Tamanho;
	Vector2 temp_Posicao;

	bool muda_Tamanho;
	bool muda_Posicao;

	public RectTransform botaoNaBarra;
	public Barra barra;
	public bool isAberto;
	Vector2 fora_da_tela = new Vector2 (0f, -100f);

	public bool isVisivel;
	Vector2 posicao_Old;

	void Start () {
		selfRT = GetComponent<RectTransform> ();
		papelParede = GameObject.FindGameObjectWithTag ("Papel de Parede").GetComponent<PapelParede>();

		size_Maximizado = papelParede.size;
		posicao_Maximizado.x = 0f;
		posicao_Maximizado.y = size_Maximizado.y;

		alvo_Tamanho = selfRT.rect.size;
		alvo_Posicao = selfRT.anchoredPosition;

	}


	void Update () {

		AtualizaTamanho ();
		AtualizaPosicao ();
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

	void AtualizaTamanho ()
	{
		if (muda_Tamanho) {
			if (Vector2.Distance (selfRT.rect.size, alvo_Tamanho) < 0.5f) {
				muda_Tamanho = false;
			}
			else {
				temp_Tamanho = Vector2.SmoothDamp (selfRT.rect.size, alvo_Tamanho, ref ref_Tamanho, tempo);
				selfRT.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, temp_Tamanho.x);
				selfRT.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, temp_Tamanho.y);
			}
		}
	}

	void AtualizaPosicao ()
	{
		if (muda_Posicao) {
			if (Vector2.Distance (selfRT.anchoredPosition, alvo_Posicao) < 0.5f) {
				muda_Posicao = false;
			}
			else {
				if (selfRT.anchoredPosition != alvo_Posicao) {
					selfRT.anchoredPosition = Vector2.SmoothDamp (selfRT.anchoredPosition, alvo_Posicao, ref ref_Posicao, tempo);
				}
			}
		}
	}

	public void TrazPraFrente () {
		transform.SetAsLastSibling ();
	}

	public void Abrir () {
		barra.AbriuPrograma (botaoNaBarra);
		isAberto = true;
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
}
