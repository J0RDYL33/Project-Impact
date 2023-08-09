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
    public List<SliderBehaviour> mySliders;
    public List<TraitConnections> myTraitLinks;

    //Slider prefab stuff
    [SerializeField] private GameObject sliderPrefab;
    [SerializeField] private GameObject parentOfAttribute;
    [SerializeField] private GameObject dropdownPrefab;
    [SerializeField] private GameObject dropdownParent;
    private DialogButtons dialogButtons;

    // Start is called before the first frame update
    void Start()
    {
        //The only ToolCalcs in the project, find it
        myCalcs = FindObjectOfType<ToolCalcs>();
        //The only NPCButtons in the project, find it
        myButton = FindObjectOfType<NPCButtons>();
        dialogButtons = GetComponentInChildren<DialogButtons>();

        //Add myself to the list in myCalcs
        myCalcs.NPCs.Add(this);

        //After everything, find myself in the toolCalcs list and get my index
        UpdateIndex();
        //Check to see if the NPC has a name
        UpdateName();
        //Add the attributes that have already been made to the NPC
        AddExistingAttributes();
    }

    public void UpdateIndex()
    {
        myIndexInButton = myButton.NPCList.IndexOf(this.gameObject);
    }

    public void UpdateName()
    {
        nameFromInput = nameInput.text;

        if (nameFromInput == "")
            this.gameObject.name = "NPC";
        else
            this.gameObject.name = nameFromInput + " The NPC";
    }

    public void AddAttribute()
    {
        GameObject newSlider = Instantiate(sliderPrefab, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        newSlider.transform.SetParent(parentOfAttribute.transform);
        newSlider.transform.localScale = new Vector3(1, 1, 1);
        newSlider.transform.localPosition = new Vector3(0, 0, 0);

        GameObject newDropdown = Instantiate(dropdownPrefab, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        newDropdown.transform.SetParent(dropdownParent.transform);
        newDropdown.transform.localScale = new Vector3(1, 1, 1);
        newDropdown.transform.localPosition = new Vector3(0, 0, 0);

        dialogButtons.RefreshRect();
    }

    private void AddExistingAttributes()
    {
        for(int i = 0; i < myCalcs.NPCAttributes.Count; i++)
        {
            AddAttribute();
        }
    }

    public void UpdateAttribute(int indexOfUpdated)
    {
        mySliders[indexOfUpdated].UpdateText();
        myTraitLinks[indexOfUpdated].UpdateText();
    }

    public void DeleteAttribute(int indexToDelete)
    {
        GameObject objToDelete1 = mySliders[indexToDelete].gameObject;
        GameObject objToDelete2 = myTraitLinks[indexToDelete].gameObject;
        mySliders.RemoveAt(indexToDelete);
        myTraitLinks.RemoveAt(indexToDelete);
        Destroy(objToDelete1);
        Destroy(objToDelete2);

        for(int i = 0; i < mySliders.Count; i++)
        {
            mySliders[i].UpdateIndex();
            myTraitLinks[i].UpdateIndex();
        }
    }

    public void UpdateDialogOptions()
    {
        for(int i = 0; i < myDialogs.Count; i++)
        {
            myDialogs[i].AddOption();
        }
    }

    public void UpdateDropdownOptions()
    {
        for(int i = 0; i < myTraitLinks.Count; i++)
        {
            myTraitLinks[i].UpdateDropdown();
        }
    }
}
