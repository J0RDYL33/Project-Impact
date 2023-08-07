using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ToolCalcs : MonoBehaviour
{
    public List<string> NPCAttributes;
    public List<string> VisualAttributes;
    public List<IAmNPC> NPCs;

    public void AddedAttribute()
    {
        for(int i = 0; i < NPCs.Count; i++)
        {
            NPCs[i].AddAttribute();
        }
    }

    public void UpdateAttributes(int indexOfAttribute)
    {
        //Once called, go to each IAmNPC and update the new list
        for (int i = 0; i < NPCs.Count; i++)
        {
            NPCs[i].UpdateAttribute(indexOfAttribute);
        }
    }

    public void DeletedAttribute(int posOfDeleted)
    {
        for (int i = 0; i < NPCs.Count; i++)
        {
            NPCs[i].DeleteAttribute(posOfDeleted);
        }
    }
}
