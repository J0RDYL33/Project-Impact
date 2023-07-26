using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCButtons : MonoBehaviour
{
    [SerializeField] private GameObject inputField;
    [SerializeField] private GameObject parentObject;
    [SerializeField] private ScrollRect myRect;
    private ToolCalcs theCalcs;
    public List<GameObject> attributeList;

    // Start is called before the first frame update
    void Start()
    {
        theCalcs = FindObjectOfType<ToolCalcs>();
    }

    //Depending on the field provided, instantiates it into the scrolling list under the others, but above the button that spawned it
    public void InstantiateField()
    {
        GameObject newField = Instantiate(inputField, new Vector3(0,0,0), Quaternion.Euler(0,0,0));
        newField.transform.SetParent(parentObject.transform);
        newField.transform.localScale = new Vector3(1, 1, 1);

        attributeList.Add(newField);
        newField.name = Random.Range(0, 1000).ToString();

        newField.transform.SetSiblingIndex(attributeList.Count-1);
        this.transform.SetSiblingIndex(attributeList.Count);

        StartCoroutine(ScrollbartoZero());
    }

    //When you add a new item to a scrollbar area, it wants to scroll to the bottom
    IEnumerator ScrollbartoZero()
    {
        yield return new WaitForEndOfFrame();
        myRect.verticalNormalizedPosition = 0f;
    }

    public void DeleteListEntry(int posToDelete)
    {
        //Get the object we'll be deleting from the list
        GameObject objToDelete = attributeList[posToDelete-1];

        //Remove it from the calc list
        theCalcs.NPCs.RemoveAt(posToDelete - 1);

        //Remove it from this list
        attributeList.RemoveAt(posToDelete-1);
        Destroy(objToDelete);

        for (int i = 0; i < attributeList.Count; i++)
        {
            if(attributeList[i].GetComponentInChildren<NPCSaver>().placeInList > posToDelete)
            {
                attributeList[i].GetComponentInChildren<NPCSaver>().placeInList--;
            }
        }
    }
}
