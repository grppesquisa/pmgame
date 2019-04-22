using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PanelControl : MonoBehaviour {

    public TMP_Dropdown dropdown;
    public TextMeshProUGUI fullName_onScreen;

    public TextMeshProUGUI email_onScreen;

    public Slider afinity_Slider;
    public TextMeshProUGUI afinity_value_OnScreen;
    public Slider respect_Slider;
    public TextMeshProUGUI respect_value_OnScreen;
    public Slider confidence_Slider;
    public TextMeshProUGUI confidence_value_OnScreen;

    public TextMeshProUGUI result_onScreen;
    public TextMeshProUGUI variables_check;

    public string nome_NPC;

    int index = 0;

	void Start () {

        dropdown.options.Clear();
        result_onScreen.text = "";
        variables_check.text = "";

        if(nome_NPC == "")
            { fullName_onScreen.SetText("nome vazio"); }
        else
            { fullName_onScreen.SetText(nome_NPC); }  

        for (int i = 0; i < GD.NPC_List.Count; i++)
        {
            TMP_Dropdown.OptionData temp = new TMP_Dropdown.OptionData();
            temp.text = GD.NPC_List[i].teamRole;
            dropdown.options.Add(temp);
        }

        dropdown.value = 1;
        dropdown.value = 0;
	}
	
	
	public void ChangeValue ()
    {
        string newTeamrole = dropdown.options[dropdown.value].text;
        foreach (NPC_Stats item in GD.NPC_List)
        {
            if (item.teamRole == newTeamrole)
            {
                index = GD.NPC_List.IndexOf(item);
            }
        }
        fullName_onScreen.text = GD.NPC_List[index].treatment + " " + GD.NPC_List[index].firstName + " " + GD.NPC_List[index].surname;
        email_onScreen.text = GD.NPC_List[index].email;
        afinity_Slider.value = GD.NPC_List[index].afinity;
        respect_Slider.value = GD.NPC_List[index].respect;
        confidence_Slider.value = GD.NPC_List[index].confidence;
    }

    private void Update()
    {
        GD.NPC_List[index].afinity = (int)afinity_Slider.value;
        afinity_value_OnScreen.text = GD.NPC_List[index].afinity.ToString();
        GD.NPC_List[index].respect = (int)respect_Slider.value;
        respect_value_OnScreen.text = GD.NPC_List[index].respect.ToString();
        GD.NPC_List[index].confidence = (int)confidence_Slider.value;
        confidence_value_OnScreen.text = GD.NPC_List[index].confidence.ToString();

    }

    public void ClickFuzzy ()
    {
        result_onScreen.text = Fuzzy.ResolveFuzzy(GD.NPC_List[index].afinity, GD.NPC_List[index].respect, GD.NPC_List[index].confidence);
        variables_check.text = GD.NPC_List[index].afinity.ToString() + " : " + GD.NPC_List[index].respect.ToString() + " : " + GD.NPC_List[index].confidence.ToString();
    }
}
