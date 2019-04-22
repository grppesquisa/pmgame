using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPopulate : MonoBehaviour {

    public LoadOrganogram org;
    public GameObject prefab;

	void Start () {
        for (int i = 0; i < org.NPC_List.Count; i++)
        {
            GameObject temp = Instantiate(prefab, transform);
            BilboardHandler bh = temp.GetComponent<BilboardHandler>();
            bh.NPC_index = i;
            bh.SetUp();
        }
	}
	
	
}
