using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IAmAspect : MonoBehaviour
{
    //Where everything goes to
    private ToolCalcs myCalcs;
    //myButton is what created us, and stores our position of the aspects. Use this scripts position at all times when finding position/ deleting myself (myButton.IndexOf(this.gameobject)
    private AspectButtons myButton;

    //Gameobjects on the panel that we need info from
    public TMP_InputField nameInput;
    public TMP_Dropdown myDropdown;

    //Information about the Aspect
    public int myIndexInButton;
    public string nameFromInput;
    public List<AspectSliders> mySliders;
    [SerializeField] private List<string> typesOfAspects;

    //Slider prefab stuff
    [SerializeField] private GameObject sliderPrefab;
    [SerializeField] private GameObject parentOfAttribute;

    // Start is called before the first frame update
    void Start()
    {
        //The only ToolCalcs in the project, find it
        myCalcs = FindObjectOfType<ToolCalcs>();
        //The only NPCButtons in the project, find it
        myButton = FindObjectOfType<AspectButtons>();

        //Add myself to the list in myCalcs
        myCalcs.visualAspects.Add(this);

        //After everything, find myself in the toolCalcs list and get my index
        UpdateIndex();
        //Check to see if the NPC has a name
        UpdateName();
        //Add the attributes that have already been made to the Aspect
        AddExistingAspects();
        UpdateDropdown();
    }

    public void UpdateIndex()
    {
        myIndexInButton = myButton.aspectList.IndexOf(this.gameObject);
    }

    public void UpdateName()
    {
        nameFromInput = nameInput.text;

        if (nameFromInput == "")
            this.gameObject.name = "Aspect";
        else
            this.gameObject.name = nameFromInput;
    }

    public void AddAspect()
    {
        GameObject newSlider = Instantiate(sliderPrefab, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        newSlider.transform.SetParent(parentOfAttribute.transform);
        newSlider.transform.localScale = new Vector3(1, 1, 1);
        newSlider.transform.localPosition = new Vector3(0, 0, 0);

        //MIGHT NEED NEW SCRIPT TO HANDLE THIS
        //dialogButtons.RefreshRect();
    }

    private void AddExistingAspects()
    {
        for (int i = 0; i < myCalcs.visualAttributes.Count; i++)
        {
            AddAspect();
        }
    }

    public void UpdateAspect(int indexOfUpdated)
    {
        mySliders[indexOfUpdated].UpdateText();
    }

    public void DeleteAttribute(int indexToDelete)
    {
        GameObject objToDelete = mySliders[indexToDelete].gameObject;
        mySliders.RemoveAt(indexToDelete);
        Destroy(objToDelete);

        for (int i = 0; i < mySliders.Count; i++)
        {
            mySliders[i].UpdateIndex();
        }
    }

    private void UpdateDropdown()
    {
        myDropdown.ClearOptions();
        for(int i = 0; i < typesOfAspects.Count; i++)
        {
            var addToDropdown = new TMP_Dropdown.OptionData(typesOfAspects[i]);
            myDropdown.options.Add(addToDropdown);
        }
    }
}
