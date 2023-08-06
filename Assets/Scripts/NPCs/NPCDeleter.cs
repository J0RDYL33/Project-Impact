using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDeleter : MonoBehaviour
{
    private NPCButtons onlyButtonBehaviour;
    [SerializeField] private IAmNPC myToolScript;
    private int posInList;

    private void Start()
    {
        onlyButtonBehaviour = FindObjectOfType<NPCButtons>();
    }

    public void DeleteMyParent()
    {
        posInList = myToolScript.myIndexInButton;
        onlyButtonBehaviour.DeleteListEntry(posInList);
    }
}
