using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VisualTraitSaver : MonoBehaviour
{
    //Where everything goes to
    private ToolCalcs myCalcs;

    public int placeInList;
    private string inputText;
    private VisualTraitButtons myButton;
    // Start is called before the first frame update
    void Start()
    {
        myCalcs = FindObjectOfType<ToolCalcs>();
        myButton = FindObjectOfType<VisualTraitButtons>();

        inputText = GetComponent<TMP_InputField>().text;

        myCalcs.visualAttributes.Add("");
        myCalcs.AddedAspect();
        placeInList = myButton.attributeList.Count-1;

        myCalcs.FlashNPCCanvas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFinishEditing()
    {
        inputText = GetComponent<TMP_InputField>().text;
        myCalcs.visualAttributes[placeInList] = inputText;
        myCalcs.UpdateAspect(placeInList);

        myCalcs.FlashNPCCanvas();
        Debug.Log("Should flash canvas");
    }
}
