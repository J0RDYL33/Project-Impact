using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCDialog : MonoBehaviour
{
    //myNPC will be the NPC that we belong to
    private IAmNPC myNPC;

    //Gameobjects we need to get
    [SerializeField] TMP_InputField dialogInputBox;
    [SerializeField] TMP_Dropdown firstDropdownObject;
    [SerializeField] TMP_Dropdown secondDropdownObject;

    //Variables about the dialog
    public int dialogPlacement;
    int firstDropdownEffector;
    int secondDropdownEffector;
    string dialogText;

    // Start is called before the first frame update
    void Start()
    {
        //Search up through the dialogs parents til it finds its NPC
        myNPC = GetComponentInParent<IAmNPC>();
        myNPC.myDialogs.Add(this);

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
        this.gameObject.name = "Dialog " + dialogPlacement + " of NPC " + myNPC.gameObject.name;
    }

    public void UpdateFirstEffector()
    {
        firstDropdownEffector = firstDropdownObject.value;
    }

    public void UpdateSecondEffector()
    {
        secondDropdownEffector = secondDropdownObject.value;
    }
}
