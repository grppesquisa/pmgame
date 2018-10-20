using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversa : MonoBehaviour {

	public List <RectTransform> mensagens = new List<RectTransform> ();
	public float ajuste;

	void Start () {
		
	}

	void Update () {
		for (int i = 0; i < mensagens.Count; i++) {
			if (i == 0) {
				mensagens [i].anchoredPosition = Vector2.zero;
			} else {
				float proximo = mensagens[i -1].anchoredPosition.y - mensagens [i - 1].rect.height - ajuste;
				mensagens [i].anchoredPosition = new Vector2 (0f, proximo);
			} 
		}
	}
}
