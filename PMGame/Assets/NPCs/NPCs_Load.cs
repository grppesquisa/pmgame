using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NPCs_Load : MonoBehaviour {

	public GameObject NPC_prefab;


	string path;
	string fromFile_Raw;
	string[] lines;



	void Awake () {

		AdjustString ();
		CreateNPCs ();
		CreateDepartments ();
	

	}
	

	void AdjustString ()
	{
		path = Application.streamingAssetsPath + "/" + "ListOfNPCs.json";
		fromFile_Raw = File.ReadAllText (path);
		
		lines = fromFile_Raw.Split (new char[] { '\n' }, System.StringSplitOptions.None);

		string temp = lines [0].Substring (1);
		lines [0] = temp;
		int lastLine = lines.Length - 1;
		temp = lines [lastLine].Substring (0, lines[lastLine].Length -1);
		lines [lastLine] = temp;

		for (int i = 0; i < lines.Length -1; i++) {
			string t = lines [i].Substring (0, lines [i].Length - 2);
			lines [i] = t;

		}
	}

	void CreateNPCs ()
	{
		for (int i = 0; i < lines.Length; i++) {
			GameObject newNPC = Instantiate (NPC_prefab, transform);
			NPC newNPC_fromJson = JsonUtility.FromJson<NPC> (lines [i]);
			newNPC.GetComponent<NPC_Handler> ().info = newNPC_fromJson;
			newNPC.name = newNPC_fromJson.teamrole + "-" + newNPC_fromJson.last_name;
		}

		foreach (Transform item in transform) {
			Company.npc.Add (item.GetComponent<NPC_Handler> ().info);
		}
	}


	static void CreateDepartments ()
	{
		foreach (NPC item in Company.npc) {
			if (!Company.department.Contains (item.department)) {
				Company.department.Add (item.department);
			}
		}
	}
}
