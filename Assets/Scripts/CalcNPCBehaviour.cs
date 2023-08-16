using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalcNPCBehaviour : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private GameObject dialogObject;
    [SerializeField] private GameObject dialogParent;
    private ToolCalcs myCalcs;
    private List<float> affectedChances = new List<float>();
    private List<calcDialogs> spawnedDialogs = new List<calcDialogs>();
    [SerializeField] private List<float> individualChance = new List<float>();
    private float totalChance;
    // Start is called before the first frame update
    void Start()
    {
        //myCalcs = FindObjectOfType<ToolCalcs>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePanel(int indexOfNPC)
    {
        myCalcs = FindObjectOfType<ToolCalcs>();
        nameText.text = myCalcs.NPCs[indexOfNPC].nameFromInput;

        //myCalcs.NPCs[indexOfNPC].mySliders[i].valueOfSlider is how we see the NPCs value for the first attribute
        //myCalcs.NPCs[indexOfNPC].myTraitLinks[i].dropdownValue is how we see which trait affects the first NPC attribute
        //E.g. Attribute is at 5. If dropdownValue is 1, then myCalcs.valueMeans[1] is how we get the players value for the desired stat. Lets say it's 7
        //5 * 7 = 35, keep note of that number for the first dialog option, and also add it to a value which will serve as the total sum
        //If the total sum comes to 55, then the chance of the first dialog happening is 35/55. * 100 and limit to 2dp for the percentage chance of it occuring

        //Additional calcs if there's 2 affectors + work out odds
        for(int i = 0; i < myCalcs.NPCs[indexOfNPC].myDialogs.Count; i++)
        {
            float dialogChance;
            float tempEffector;
            if (myCalcs.NPCs[indexOfNPC].myDialogs[i].firstDropdownEffector == 0)
                return;
            else if(myCalcs.NPCs[indexOfNPC].myDialogs[i].firstDropdownEffector > 0)
            {
                if(myCalcs.NPCs[indexOfNPC].myDialogs[i].secondDropdownEffector > 0)
                {
                    //If there's 2 affectors on the dialog option
                    dialogChance = (myCalcs.NPCs[indexOfNPC].mySliders[myCalcs.NPCs[indexOfNPC].myDialogs[i].firstDropdownEffector - 1].valueOfSlider *
                        myCalcs.NPCs[indexOfNPC].mySliders[myCalcs.NPCs[indexOfNPC].myDialogs[i].secondDropdownEffector - 1].valueOfSlider) / 2;
                    tempEffector = (myCalcs.valueMeans[myCalcs.NPCs[indexOfNPC].myTraitLinks[myCalcs.NPCs[indexOfNPC].myDialogs[i].firstDropdownEffector - 1].dropdownValue] +
                        myCalcs.valueMeans[myCalcs.NPCs[indexOfNPC].myTraitLinks[myCalcs.NPCs[indexOfNPC].myDialogs[i].secondDropdownEffector - 1].dropdownValue]) / 2;
                }
                else
                {
                    dialogChance = myCalcs.NPCs[indexOfNPC].mySliders[myCalcs.NPCs[indexOfNPC].myDialogs[i].firstDropdownEffector - 1].valueOfSlider;
                    tempEffector = myCalcs.valueMeans[myCalcs.NPCs[indexOfNPC].myTraitLinks[myCalcs.NPCs[indexOfNPC].myDialogs[i].firstDropdownEffector - 1].dropdownValue];
                }

                individualChance.Add(dialogChance * tempEffector);
                totalChance += (dialogChance * tempEffector);
            }
        }

        //Spawn the dialogs with their worked out odds
        for(int i = 0; i < myCalcs.NPCs[indexOfNPC].myDialogs.Count; i++)
        {
            GameObject tempObj = Instantiate(dialogObject, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            tempObj.transform.SetParent(dialogParent.transform);
            tempObj.transform.localScale = new Vector3(1, 1, 1);
            tempObj.transform.localPosition = new Vector3(0, 0, 0);
            spawnedDialogs.Add(tempObj.GetComponent<calcDialogs>());
            spawnedDialogs[i].dialogText.text = myCalcs.NPCs[indexOfNPC].myDialogs[i].dialogText;
            spawnedDialogs[i].percentText.text = ((individualChance[i] / totalChance) * 100).ToString() + "%";
        }
    }
}
