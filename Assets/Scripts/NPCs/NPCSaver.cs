using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using NPCClasses;

public class NPCSaver : MonoBehaviour
{
    //Where everything goes to
    private ToolCalcs myCalcs;

    public int placeInList;
    public TMP_InputField nameInput;
    private string nameFromInput;
    private NPCButtons myButton;
    private NPC myNPC;
    // Start is called before the first frame update
    void Start()
    {
        myCalcs = FindObjectOfType<ToolCalcs>();
        myButton = FindObjectOfType<NPCButtons>();

        nameFromInput = nameInput.text;

        myNPC = new NPC();
        myCalcs.NPCs.Add(myNPC);
        placeInList = myButton.attributeList.Count;

        Debug.Log("My pos in the list is " + placeInList);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFinishEditingName()
    {
        nameFromInput = nameInput.text;
        myCalcs.NPCs[placeInList-1].name = nameFromInput;
    }
}
