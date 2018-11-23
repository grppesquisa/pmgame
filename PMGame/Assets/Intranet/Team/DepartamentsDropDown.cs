using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DepartamentsDropDown : DepartamentsManager {

	TMP_Dropdown department_List;

	void Start () {
		department_List = GetComponent<TMP_Dropdown> ();

		department_List.options.Clear ();
		for (int i = 0; i < Company.department.Count; i++) {
			TMP_Dropdown.OptionData dep = new TMP_Dropdown.OptionData ();
			dep.text = Company.department [i];
			department_List.options.Add (dep);
			
		}
		TMP_Dropdown.OptionData dep_All = new TMP_Dropdown.OptionData ();
		dep_All.text = "All";
		department_List.options.Insert (0, dep_All);



	}
	

}
