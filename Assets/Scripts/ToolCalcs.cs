using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ToolCalcs : MonoBehaviour
{
    public List<string> NPCAttributes;
    public List<string> VisualAttributes;
    public List<IAmNPC> NPCs;
    [SerializeField] private GameObject NPCCanvas;

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

    public void FlashNPCCanvas()
    {
        StartCoroutine(FlashingCanvas());
    }

    IEnumerator FlashingCanvas()
    {
        NPCCanvas.SetActive(true);
        yield return new WaitForEndOfFrame();
        NPCCanvas.SetActive(false);
    }
}
