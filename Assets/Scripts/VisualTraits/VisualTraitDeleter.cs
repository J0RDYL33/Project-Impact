using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualTraitDeleter : MonoBehaviour
{
    private VisualTraitButtons onlyButtonBehaviour;
    [SerializeField] private VisualTraitSaver myToolScript;
    private int posInList;

    private void Start()
    {
        onlyButtonBehaviour = FindObjectOfType<VisualTraitButtons>();
    }

    public void DeleteMyParent()
    {
        posInList = myToolScript.placeInList;
        onlyButtonBehaviour.DeleteListEntry(posInList);
    }
}
