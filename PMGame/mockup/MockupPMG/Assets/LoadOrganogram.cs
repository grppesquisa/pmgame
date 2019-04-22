using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadOrganogram : MonoBehaviour {

    private string path;
    private string jsonRaw;
    private string[] NPC_stringsArray;
    
   
    public GameObject NPC_prefab;

    public List<GameObject> NPC_List;

    void Awake()
    {
        path = Application.streamingAssetsPath + "/NPCstats.json";
        jsonRaw = File.ReadAllText(path);
        NPC_stringsArray = jsonRaw.Split (new string[] { "\n" }, System.StringSplitOptions.None);
        StringArrayAdjust();

        for (int i = 0; i < NPC_stringsArray.Length; i++)
        {
            LoadJsonStringIntoNPCPR(NPC_stringsArray[i]); 
        }

        BuildNPC_GameObject_List();
               
    }

   

    void BuildNPC_GameObject_List()
    {
        foreach (Transform item in transform)
        {
            NPC_List.Add(item.gameObject);
        }
    }
    
    void StringArrayAdjust()
    {
        string temp = NPC_stringsArray[0].Remove(0, 1);
        NPC_stringsArray[0] = temp;

        for (int i = 0; i < NPC_stringsArray.Length -1; i++)
        {
            temp = NPC_stringsArray[i].Remove(NPC_stringsArray[i].Length - 2, 1);
            NPC_stringsArray[i] = temp;
        }

        temp = NPC_stringsArray[NPC_stringsArray.Length -1].Remove(NPC_stringsArray[NPC_stringsArray.Length -1].Length - 1, 1);
        NPC_stringsArray[NPC_stringsArray.Length -1] = temp;
    }

    void LoadJsonStringIntoNPCPR(string stringAdjusted)
    {
        GameObject newNPC = Instantiate(NPC_prefab, transform);
        newNPC.GetComponent<NPC_Stats>().stats = JsonUtility.FromJson<NPCPersonRoot>(stringAdjusted);
        newNPC.name = newNPC.GetComponent<NPC_Stats>().stats.teamRole;

    }
}
