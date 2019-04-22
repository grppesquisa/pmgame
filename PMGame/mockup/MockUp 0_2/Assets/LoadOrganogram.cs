using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadOrganogram : MonoBehaviour {

    string path;
    string jsonRaw;

    string[] jsonRaw_splitted;

	void Awake () {
        path = Application.streamingAssetsPath + "/NPC_DataBase.json";
        jsonRaw = File.ReadAllText(path);

        jsonRaw_splitted = jsonRaw.Split(new char[] { '\n' });

        string t = jsonRaw_splitted[0].Remove(0, 1);
        jsonRaw_splitted[0] = t;
        t = jsonRaw_splitted[jsonRaw_splitted.Length -1].Remove (jsonRaw_splitted[jsonRaw_splitted.Length - 1].Length -1, 1);
        jsonRaw_splitted[jsonRaw_splitted.Length - 1] = t;

        for (int i = 0; i < jsonRaw_splitted.Length -1; i++)
        {
            t = jsonRaw_splitted[i].Remove(jsonRaw_splitted[i].Length - 2, 1);
            jsonRaw_splitted[i] = t;
        }

        for (int i = 0; i < jsonRaw_splitted.Length; i++)
        {
            string tempString = jsonRaw_splitted[i];
            NPC_Stats tempStats = JsonUtility.FromJson<NPC_Stats>(tempString);
            GD.NPC_List.Add(tempStats);
        }
    }
	
	
}
