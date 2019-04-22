using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GD : MonoBehaviour {

    public static List<NPC_Stats> NPC_List = new List<NPC_Stats>();
    public List<NPC_Stats> NPC_List_Clone = new List<NPC_Stats>();

    private void Update()
    {
        NPC_List_Clone = NPC_List; // Esse é só para aparecer no inspector, já que static variables não aparecem.
    }

}
