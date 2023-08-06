using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IAmNPC : MonoBehaviour
{
    //Where everything goes to
    private ToolCalcs myCalcs;
    //myButton is what created us, and stores our position of the NPCs. Use this scripts position at all times when finding position/ deleting myself (myButton.IndexOf(this.gameobject)
    private NPCButtons myButton;

    //Gameobjects on the panel that we need info from
    public TMP_InputField nameInput;

    //Information about the NPC
    public int myIndexInButton;
    public string nameFromInput;
    public List<NPCDialog> myDialogs;

    // Start is called before the first frame update
    void Start()
    {
        //The only ToolCalcs in the project, find it
        myCalcs = FindObjectOfType<ToolCalcs>();
        //The only NPCButtons in the project, find it
        myButton = FindObjectOfType<NPCButtons>();

        //Add myself to the list in myCalcs
        myCalcs.NPCs.Add(this);

        //After everything, find myself in the toolCalcs list and get my index
        UpdateIndex();
        //Check to see if the NPC has a name
        UpdateName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateIndex()
    {
        myIndexInButton = myButton.NPCList.IndexOf(this.gameObject);
        Debug.Log("I am NPC " + this.gameObject.name + " and my new index is " + myIndexInButton);
    }

    public void UpdateName()
    {
        nameFromInput = nameInput.text;
    }
}
