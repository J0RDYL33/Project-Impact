using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TraitConnections : MonoBehaviour
{
    //Where everything goes to
    private ToolCalcs myCalcs;

    private IAmNPC myNPC;
    private int myIndexInNPC;
    public string myText;
    public int dropdownValue;

    [SerializeField] private TMP_Text attributeText;
    [SerializeField] private TMP_Dropdown traitDropdown;
    // Start is called before the first frame update
    void Start()
    {
        //The only ToolCalcs in the project, find it
        myCalcs = FindObjectOfType<ToolCalcs>();
        myNPC = GetComponentInParent<IAmNPC>();

        myNPC.myTraitLinks.Add(this);

        UpdateText();
        UpdateDropdown();
    }

    public void UpdateIndex()
    {
        myIndexInNPC = myNPC.myTraitLinks.IndexOf(this);
    }

    public void UpdateText()
    {
        UpdateIndex();
        myText = myCalcs.NPCAttributes[myIndexInNPC];
        attributeText.text = myText;
    }

    public void OnDDValueChange()
    {
        dropdownValue = traitDropdown.value;
    }

    public void UpdateDropdown()
    {
        int ddValue = dropdownValue;
        string ddString = "";
        if (traitDropdown.options.Count > ddValue)
        {
            ddString = traitDropdown.options[ddValue].text;
        }

        traitDropdown.ClearOptions();

        for (int i = 0; i < myCalcs.visualAttributes.Count; i++)
        {
            var addAttInLoop = new TMP_Dropdown.OptionData(myCalcs.visualAttributes[i]);
            traitDropdown.options.Add(addAttInLoop);
        }
        Debug.Log(traitDropdown.options.Count);
        if (traitDropdown.options.Count > ddValue)
        {
            if (ddString == traitDropdown.options[ddValue].text)
                traitDropdown.value = ddValue;
            else
                traitDropdown.value = 0;
        }
        Debug.Log("End of Dropdown refreshes");
    }
}
