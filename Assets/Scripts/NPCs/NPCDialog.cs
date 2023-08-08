using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCDialog : MonoBehaviour
{
    //myNPC will be the NPC that we belong to
    private IAmNPC myNPC;
    private ToolCalcs myCalcs;

    //Gameobjects we need to get
    [SerializeField] TMP_InputField dialogInputBox;
    [SerializeField] TMP_Dropdown firstDropdownObject;
    [SerializeField] TMP_Dropdown secondDropdownObject;

    //Variables about the dialog
    public int dialogPlacement;
    public int firstDropdownEffector;
    public int secondDropdownEffector;
    public string dialogText;

    // Start is called before the first frame update
    void Start()
    {
        myCalcs = FindObjectOfType<ToolCalcs>();

        //Search up through the dialogs parents til it finds its NPC
        myNPC = GetComponentInParent<IAmNPC>();
        myNPC.myDialogs.Add(this);

        AddOption();

        //Get the dialogs index in its NPC
        UpdateIndex();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateIndex()
    {
        dialogPlacement = myNPC.myDialogs.IndexOf(this);
        this.gameObject.name = "Dialog " + dialogPlacement + " of " + myNPC.gameObject.name;
    }

    public void UpdateFirstEffector()
    {
        firstDropdownEffector = firstDropdownObject.value;
    }

    public void UpdateSecondEffector()
    {
        secondDropdownEffector = secondDropdownObject.value;
    }

    public void UpdateText()
    {
        dialogText = dialogInputBox.text;
    }

    public void AddOption()
    {
        int dd1Value = firstDropdownEffector;
        int dd2Value = secondDropdownEffector;
        string dd1String = firstDropdownObject.options[dd1Value].text;
        string dd2String = secondDropdownObject.options[dd2Value].text;

        firstDropdownObject.ClearOptions();
        secondDropdownObject.ClearOptions();
        var addNoneTo1 = new TMP_Dropdown.OptionData("None");
        firstDropdownObject.options.Add(addNoneTo1);
        secondDropdownObject.options.Add(addNoneTo1);

        for(int i = 0; i < myCalcs.NPCAttributes.Count; i++)
        {
            var addAttInLoop = new TMP_Dropdown.OptionData(myCalcs.NPCAttributes[i]);
            firstDropdownObject.options.Add(addAttInLoop);
            secondDropdownObject.options.Add(addAttInLoop);
        }

        if (dd1String == firstDropdownObject.options[dd1Value].text)
            firstDropdownObject.value = dd1Value;
        else
            firstDropdownObject.value = 0;

        if (dd2String == secondDropdownObject.options[dd2Value].text)
            secondDropdownObject.value = dd2Value;
        else
            secondDropdownObject.value = 0;
    }
}
