using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapelParede : MonoBehaviour {

	RectTransform rectTransform;

	public Vector2 size;

	void Awake () {
		rectTransform = GetComponent<RectTransform> ();	
		size = rectTransform.rect.size;
	}
	
}
