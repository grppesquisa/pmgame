using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BioHandler : MonoBehaviour {

	public Transform npcs;

	public MemberOnTeamSearch_Handler mos_handler;
	public TextMeshProUGUI _prename;
	public TextMeshProUGUI _name;
	public TextMeshProUGUI _age;
	public TextMeshProUGUI _department;
	public TextMeshProUGUI _teamrole;
	public TextMeshProUGUI _country;
	public TextMeshProUGUI _city;
	public TextMeshProUGUI _location;

	void Start () {
		SetBio (0);
	}

	public void SetBio (int id) {
		foreach (Transform possible_NPC in npcs) {
			if (id == possible_NPC.gameObject.GetComponent<NPC_Handler>().info.id) {
				NPC actual_NPC = possible_NPC.gameObject.GetComponent<NPC_Handler> ().info;
				_prename.text = actual_NPC.pre_name;
				_name.text = actual_NPC.first_name + " " + actual_NPC.middle_name + " " + actual_NPC.last_name;
				_age.text = actual_NPC.age.ToString ();
				_department.text = actual_NPC.department;
				_teamrole.text = actual_NPC.teamrole;
				_country.text = actual_NPC.country;
				_city.text = actual_NPC.city;
				_location.text = actual_NPC.location;
			}
		}
	}
}
