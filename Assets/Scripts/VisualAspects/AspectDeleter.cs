using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectDeleter : MonoBehaviour
{
    private AspectButtons myButtons;
    [SerializeField] private IAmAspect myToolScript;
    private int posInList;

    // Start is called before the first frame update
    void Start()
    {
        myButtons = FindObjectOfType<AspectButtons>();
    }

    public void DeleteMyParent()
    {
        posInList = myToolScript.myIndexInButton;
        myButtons.DeleteListEntry(posInList);
    }
}
