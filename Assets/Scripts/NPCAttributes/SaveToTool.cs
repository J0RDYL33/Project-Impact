using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveToTool : MonoBehaviour
{
    private ToolCalcs myCalcs;
    public int placeInList;
    private string inputText;
    private ButtonBehaviour myButton;
    // Start is called before the first frame update
    void Start()
    {
        myCalcs = FindObjectOfType<ToolCalcs>();
        myButton = FindObjectOfType<ButtonBehaviour>();

        inputText = GetComponent<TMP_InputField>().text;

        myCalcs.NPCAttributes.Add("");
        placeInList = myButton.attributeList.Count;

        Debug.Log("My pos in the list is " + placeInList);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFinishEditing()
    {
        inputText = GetComponent<TMP_InputField>().text;
        myCalcs.NPCAttributes[placeInList-1] = inputText;
    }
}
