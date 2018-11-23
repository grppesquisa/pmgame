using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ChatConversa : MonoBehaviour {

    public string arquivo;

    ConversaFromTwine conversa;
    public FalaFromTwine[] passagens;

	public GameObject balao;
	public GameObject balao_Resposta;
	public Transform content_Mensagens;
	public Transform content_Respostas;


    void Start ()
    {
		int indice = 1;
		CarregaConversa ();
		CarregaMensagem (indice);




    }

	void CarregaConversa ()
	{
		string caminho = Application.streamingAssetsPath + "/" + arquivo + ".json";
		string stringFromJson = File.ReadAllText (caminho);
		conversa = JsonUtility.FromJson<ConversaFromTwine> (stringFromJson);
		passagens = new FalaFromTwine[conversa.passages.Length + 1];
		for (int i = 0; i < conversa.passages.Length; i++) {
			passagens [(conversa.passages [i].pid)] = conversa.passages [i];
		}
	}

	public void CarregaMensagem (int indice)
	{
		if (content_Respostas.childCount > 0) {
			foreach (RectTransform item in content_Respostas) {
				Destroy (item.gameObject);
			}
		}
		TextoChat textoMensagem = new TextoChat (passagens [indice].text, false);
		GameObject mensagem = Instantiate (balao, content_Mensagens);
		mensagem.gameObject.GetComponent<Balao> ().mensagem = textoMensagem;
		for (int i = 0; i < passagens [indice].links.Length; i++) {
			RespostasFromTwine opcao = new RespostasFromTwine (passagens [indice].links [i].name, passagens [indice].links [i].pid);
			GameObject resposta = Instantiate (balao_Resposta, content_Respostas);
			resposta.GetComponent<Balao> ().mensagem.texto = opcao.texto;
			resposta.GetComponent<Resposta> ().Configura (this, opcao.pid);

		}
	}

	public void CarregaFalaMinha (string texto) {
		TextoChat textoMensagem = new TextoChat (texto, true);
		GameObject mensagem = Instantiate (balao, content_Mensagens);
		mensagem.gameObject.GetComponent<Balao> ().mensagem = textoMensagem;
	}
}
