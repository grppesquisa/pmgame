using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BilboardHandler : MonoBehaviour {

    public int NPC_index = 0;
    public NPCPersonRoot NPC;
    public LoadOrganogram org;

    public TextMeshProUGUI teamRole_value;
    public TextMeshProUGUI afinity_value;
    public TextMeshProUGUI respect_value;
    public TextMeshProUGUI confidence_value;
    public TextMeshProUGUI result_value;

    [Range(-10, 10)]
    public int afinity;

    [Range(-10, 10)]
    public int respect;

    [Range(-10, 10)]
    public int confidence;

    public void SetUp()
    {
        org = GameObject.Find("Organogram").GetComponent<LoadOrganogram>();
        NPC = org.NPC_List[NPC_index].GetComponent<NPC_Stats>().stats;
        teamRole_value.text = NPC.teamRole;

        afinity = NPC.afinity;
        respect = NPC.respect;
        confidence = NPC.confidence;
        gameObject.name = teamRole_value.text;
    }

    private void Update()
    {

        NPC.afinity = afinity;
        NPC.respect = respect;
        NPC.confidence = confidence;

        UpdateValuesOnScreen();
    }

    void UpdateValuesOnScreen()
    {
        afinity_value.text = afinity.ToString();
        respect_value.text = respect.ToString();
        confidence_value.text = confidence.ToString();

    }

    public void ResolveFuzzy ()
    {
        string to = "Tálkey";
        string nto = "Não tálkey";

        if (Fuzzy.Bool(afinity, respect, confidence))
        {
            result_value.text = to;
        } 
        else
	    {
            result_value.text = nto;
        }

    }

    public void Click ()
    {
        ResolveFuzzy();
    }
}
