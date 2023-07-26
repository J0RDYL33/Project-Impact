using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteParent : MonoBehaviour
{
    private ButtonBehaviour onlyButtonBehaviour;
    [SerializeField] private SaveToTool myToolScript;
    private int posInList;

    private void Start()
    {
        onlyButtonBehaviour = FindObjectOfType<ButtonBehaviour>();
    }

    public void DeleteMyParent()
    {
        posInList = myToolScript.placeInList;
        onlyButtonBehaviour.DeleteListEntry(posInList);
    }
}
