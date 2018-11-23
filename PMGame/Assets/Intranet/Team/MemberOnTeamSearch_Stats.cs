using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MemberOnTeamSearch_Stats : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler , IPointerDownHandler {

	public BioHandler bioHandler;

	TextMeshProUGUI label;
	public int id;
	Color normal_Color;
	public Color hover_Color;
	public Color clicked_Color;

	void Start () {
		label = GetComponent<TextMeshProUGUI> ();	
		normal_Color = label.color;
		label.text = Company.npc [id].first_name + " " + Company.npc [id].last_name + " - " + Company.npc [id].teamrole;
		bioHandler = transform.parent.GetComponent<MemberOnTeamSearch_Handler> ().bio;
	}

	public void ResetColor () {
		label.color = normal_Color;
	}

	public void OnPointerEnter (PointerEventData eventData)
	{
		if (label.color != clicked_Color) {
			label.color = hover_Color;
		}
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		if (label.color != clicked_Color) {
			label.color = normal_Color;
		}
	}


	public void OnPointerDown (PointerEventData eventData)
	{
		transform.parent.BroadcastMessage ("ResetColor");
		bioHandler.SetBio (id);
		label.color = clicked_Color;
	}

}
