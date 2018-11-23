using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Resposta : MonoBehaviour , IPointerDownHandler {

	public ChatConversa chatConversa;
	public int pid;

	Balao balao;

	void Start () {
		balao = GetComponent<Balao> ();
	}

	public void Configura (ChatConversa conversa, int pidAlvo) {
		chatConversa = conversa;
		pid = pidAlvo;
	}
	public void OnPointerDown (PointerEventData eventData)
	{
		if (chatConversa.passagens[pid].tags != null) {
			Debug.Log (chatConversa.passagens [pid].tags[0]);
		}
		chatConversa.CarregaFalaMinha (balao.mensagem.texto);
		chatConversa.CarregaMensagem (pid);
	}
}

