using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ToolCalcs : MonoBehaviour
{
    public List<string> NPCAttributes;
    public List<string> visualAttributes;
    public List<IAmNPC> NPCs;
    public List<IAmAspect> visualAspects;
    [SerializeField] private GameObject NPCCanvas;
    [SerializeField] private GameObject aspectCanvas;

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
}
