using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControle : MonoBehaviour {

	#region Posições da Câmera
	public Transform principal;
	public Transform monitor;
	public Transform quadro;
	#endregion

	public TrocaPaineis trocaPaineis;	// Referência ao script que cuida da troca das abas do computador.

	public float velocidadeCamera;		// Velocidade com que a câmera se movimenta.

	Vector3 velocidade_Atual = Vector3.zero;		
	Transform posicao_atual;

	void Start () {
		MoveCamera (principal);			// Move a câmera para a posição inicial, nesse caso a posição "principal".
	}
	
	void Update () {
		// Se a posição da câmera não for a posica_Atual, muda a posição para ficar igual. SmoothDamp e Slerp são usados para a transição não ser automática.
		if (transform.position != posicao_atual.position) {		
			transform.position = Vector3.SmoothDamp (transform.position, posicao_atual.position, ref velocidade_Atual, velocidadeCamera);
			transform.rotation = Quaternion.Slerp (transform.rotation, posicao_atual.rotation, (1f / velocidadeCamera) * Time.deltaTime);
		}
	}

	public void MoveCamera (Transform novaPosicao) {
		// Define a posição que será buscada em Update e define trocaPaineis.travado para que seja possível ou não clicar na tela.
		posicao_atual = novaPosicao;
		if (novaPosicao == monitor) {
			trocaPaineis.travado = false;
		} else {
			trocaPaineis.travado = true;
		}
	}
}
