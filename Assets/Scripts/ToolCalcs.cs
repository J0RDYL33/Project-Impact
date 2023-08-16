using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ToolCalcs : MonoBehaviour
{
    public List<string> NPCAttributes;
    public List<string> visualAttributes;
    public List<IAmNPC> NPCs;
    public List<IAmAspect> visualAspects;
    [SerializeField] private GameObject NPCCanvas;
    [SerializeField] private GameObject aspectCanvas;

    [SerializeField] private List<IAmAspect> chosenItems;
    public List<float> valueMeans;
    private float tempSumOfValues;
    private List<IAmAspect> tempListForChosing = new List<IAmAspect>();
    [SerializeField] private TMP_Text itemText;
    [SerializeField] private TMP_Text valueText;
    [SerializeField] private GameObject calcContent;
    [SerializeField] private GameObject calcNPCPanel;
    private List<GameObject> spawnedNPCPanels = new List<GameObject>();

    public void AddedAttribute()
    {
        for(int i = 0; i < NPCs.Count; i++)
        {
            NPCs[i].AddAttribute();
            NPCs[i].UpdateDialogOptions();
        }
    }

    public void UpdateAttributes(int indexOfAttribute)
    {
        //Once called, go to each IAmNPC and update the new list
        for (int i = 0; i < NPCs.Count; i++)
        {
            NPCs[i].UpdateAttribute(indexOfAttribute);
            NPCs[i].UpdateDialogOptions();
        }
    }

    public void DeletedAttribute(int posOfDeleted)
    {
        for (int i = 0; i < NPCs.Count; i++)
        {
            NPCs[i].DeleteAttribute(posOfDeleted);
            NPCs[i].UpdateDialogOptions();
        }
    }

    public void DeletedAspect(int posOfDeleted)
    {
        for (int i = 0; i < visualAspects.Count; i++)
        {
            visualAspects[i].DeleteAttribute(posOfDeleted);
        }

        for(int i = 0; i < NPCs.Count; i++)
        {
            NPCs[i].UpdateDropdownOptions();
        }
    }

    public void AddedAspect()
    {
        for (int i = 0; i < visualAspects.Count; i++)
        {
            visualAspects[i].AddAspect();
        }

        for (int i = 0; i < NPCs.Count; i++)
        {
            NPCs[i].UpdateDropdownOptions();
        }
    }

    public void UpdateAspect(int indexOfAspect)
    {
        //Once called, go to each IAmNPC and update the new list
        for (int i = 0; i < visualAspects.Count; i++)
        {
            visualAspects[i].UpdateAspect(indexOfAspect);
        }

        for (int i = 0; i < NPCs.Count; i++)
        {
            NPCs[i].UpdateDropdownOptions();
        }
    }

    public void FlashNPCCanvas()
    {
        StartCoroutine(FlashingCanvas());
    }

    IEnumerator FlashingCanvas()
    {
        NPCCanvas.SetActive(true);
        aspectCanvas.SetActive(true);
        yield return new WaitForEndOfFrame();
        NPCCanvas.SetActive(false);
        aspectCanvas.SetActive(false);
    }

    public void RunCalculations()
    {
        //Reset values used back to null to avoid errors on recalculations
        itemText.text = "";
        itemText.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(640, 0);
        valueText.text = "";
        valueText.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(640, 0);
        if(valueMeans.Count > 0)
            valueMeans.Clear();
        if(chosenItems.Count > 0)
            chosenItems.Clear();
        if(spawnedNPCPanels.Count >= 1)
        {
            for(int i = 0; i < spawnedNPCPanels.Count; i++)
            {
                Destroy(spawnedNPCPanels[i].gameObject);
            }
            spawnedNPCPanels.Clear();
        }

        FindAssignItems();
        CalculateValues();
        CalculateNPCs();
    }

    private void FindAssignItems()
    {
        //Loop through the code once for every type of clothing there is
        for (int j = 1; j < visualAspects[0].typesOfAspects.Count; j++)
        {
            if(tempListForChosing.Count > 0)
                tempListForChosing.Clear();

            for (int i = 0; i < visualAspects.Count; i++)
            {
                //Check if the type of clothing currently being looked at is the same type we're looking for
                if(visualAspects[i].valueOfAspect == j)
                {
                    tempListForChosing.Add(visualAspects[i]);
                }
            }

            //If the list of items isn't empty, pick one at random to equip to the player
            if (tempListForChosing.Count != 0)
            {
                int randItem = Random.Range(0, tempListForChosing.Count);
                chosenItems.Add(tempListForChosing[randItem]);
                itemText.text = itemText.text + visualAspects[0].typesOfAspects[j] + ": " + tempListForChosing[randItem].name + "\n";
                itemText.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(640, itemText.gameObject.GetComponent<RectTransform>().sizeDelta.y + 25);
            }
        }
    }

    private void CalculateValues()
    {
        for (int j = 0; j < visualAttributes.Count; j++)
        {
            tempSumOfValues = 0;
            for (int i = 0; i < chosenItems.Count; i++)
            {
                tempSumOfValues += chosenItems[i].mySliders[j].valueOfSlider;
            }
            valueMeans.Add(tempSumOfValues / chosenItems.Count);
            valueText.text = valueText.text + visualAttributes[j] + ": " + tempSumOfValues / chosenItems.Count + "\n";
            valueText.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(640, valueText.gameObject.GetComponent<RectTransform>().sizeDelta.y + 25);
        }
    }

    private void CalculateNPCs()
    {
        for(int i = 0; i < NPCs.Count; i++)
        {
            GameObject tempObj = Instantiate(calcNPCPanel, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            tempObj.transform.SetParent(calcContent.transform);
            tempObj.transform.localScale = new Vector3(1, 1, 1);
            tempObj.transform.localPosition = new Vector3(0, 0, 0);
            spawnedNPCPanels.Add(tempObj);

            tempObj.GetComponent<CalcNPCBehaviour>().UpdatePanel(i);
        }
    }
}
