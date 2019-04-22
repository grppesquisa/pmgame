using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MockedPanelHandler : MonoBehaviour {

    public TMP_Dropdown dropdown;
    public TextMeshProUGUI fullName_text;
    public TextMeshProUGUI afinity_text;
    public Slider afinity_slider;
    public TextMeshProUGUI respect_text;
    public Slider respect_slider;
    public TextMeshProUGUI confidence_text;
    public Slider confidence_slider;
    public TextMeshProUGUI button_text;
    public TextMeshProUGUI result_text;

    public string button_name;
    public string result_true;
    public string result_false;

    public Color32 result_true_color;
    public Color32 result_false_color;

    LoadOrganogram org;
    public List<NPCPersonRoot> NPC_list;
    public int NPC_index = 0;
    

    void Start () {
		org = GameObject.Find("Organogram").GetComponent<LoadOrganogram>();

        MountNPC_list();

    }
    
    public void UpdateSlidersValues()
    {
        afinity_text.text = afinity_slider.value.ToString();
        respect_text.text = respect_slider.value.ToString();
        confidence_text.text = confidence_slider.value.ToString();
    }

    public void SlidersManuallyChanged()
    {
        foreach (GameObject  item in org.NPC_List)
        {
            if (item.name == NPC_list[NPC_index].teamRole)
            {
                item.GetComponent<NPCPersonRoot>().afinity = (int)afinity_slider.value;
                item.GetComponent<NPCPersonRoot>().respect = (int)respect_slider.value;
                item.GetComponent<NPCPersonRoot>().confidence = (int)confidence_slider.value;
            }
        }
    }
    void SetupSliders ()
    {
        
    }

    void MountNPC_list ()
    {
        foreach (GameObject item in org.NPC_List)
        {
            NPCPersonRoot temp = item.GetComponent<NPC_Stats>().stats;
            NPC_list.Add(temp);
        }

        dropdown.options.Clear();
        foreach (NPCPersonRoot item in NPC_list)
        {
            TMP_Dropdown.OptionData temp = new TMP_Dropdown.OptionData ();
            temp.text = item.teamRole;
            dropdown.options.Add(temp);
        }
        dropdown.value = 1;
        dropdown.value = 0;
    }

    public void ValueChanged()
    {
        string newValue = dropdown.options[dropdown.value].text;

        foreach (NPCPersonRoot item in NPC_list)
        {
            if (item.teamRole == newValue)
            {
                NPC_index = NPC_list.IndexOf(item);
            }
        }

        FillValues();
        
    }

    void FillValues ()
    {
        fullName_text.text = NPC_list[NPC_index].firstName + " " + NPC_list[NPC_index].surname;
        afinity_slider.value = NPC_list[NPC_index].afinity;
        respect_slider.value = NPC_list[NPC_index].respect;
        confidence_slider.value = NPC_list[NPC_index].confidence;

        UpdateSlidersValues();
    }
}
