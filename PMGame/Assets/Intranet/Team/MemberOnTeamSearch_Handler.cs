using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemberOnTeamSearch_Handler : MonoBehaviour {

	public RectTransform outOfScreen;
	public GameObject prefab;
	public BioHandler bio;
	public GameObject[] full_List;
	public GameObject[] current_List;



	void Start () {
		CreateEntrys ();
		FilterMembers (0);
			

	}
	
	void Update () {
		
	}

	void CreateEntrys ()
	{
		full_List = new GameObject[Company.npc.Count];
		foreach (NPC member in Company.npc) {
			GameObject m = Instantiate (prefab, transform);
			m.GetComponent<MemberOnTeamSearch_Stats> ().id = member.id;
			full_List [member.id] = m;
			m.GetComponent<RectTransform> ().anchoredPosition = outOfScreen.anchoredPosition;
			m.name = member.teamrole;
		}
	}

	public void FilterMembers (int department) {
		
		foreach (GameObject member in full_List) {
			member.GetComponent<RectTransform> ().anchoredPosition = outOfScreen.anchoredPosition;
		}

		if (department > 0) {
			department--;
			int members_found = 0;
			
			foreach (NPC member in Company.npc) {
				if (member.department == Company.department [department]) {
					members_found++;
				}
			}
			
			current_List = new GameObject[members_found];
			int indice = 0;
			for (int i = 0; i < full_List.Length; i++) {
				if (Company.npc [i].department == Company.department [department]) {
					current_List [indice] = full_List [i];
					indice++;
				}
			}
		} else {
			current_List = full_List;
		}

		ShowMembers ();

	}

	void ShowMembers ()
	{
		for (int i = 0; i < current_List.Length; i++) {
			if (i == 0) {
				RectTransform temp = current_List [i].GetComponent<RectTransform> ();
				temp.anchoredPosition = Vector2.zero;
			}
			else {
				RectTransform anterior = current_List [i - 1].GetComponent<RectTransform> ();
				RectTransform temp = current_List [i].GetComponent<RectTransform> ();
				Vector2 pos = new Vector2 (0f, (anterior.anchoredPosition.y - (anterior.rect.height + 0f)));
				temp.anchoredPosition = pos;
			}
		}
	}
}
