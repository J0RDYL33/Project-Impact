using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AspectButtons : MonoBehaviour
{
    [SerializeField] private GameObject aspectPrefab;
    [SerializeField] private GameObject parentObject;
    [SerializeField] private ScrollRect myRect;
    private ToolCalcs theCalcs;
    public List<GameObject> aspectList;
    // Start is called before the first frame update
    void Start()
    {
        theCalcs = FindObjectOfType<ToolCalcs>();
    }

    public void InstantiateField()
    {
        GameObject newField = Instantiate(aspectPrefab, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        newField.transform.SetParent(parentObject.transform);
        newField.transform.localScale = new Vector3(1, 1, 1);

        aspectList.Add(newField);
        newField.name = Random.Range(0, 1000).ToString();

        newField.transform.SetSiblingIndex(aspectList.Count - 1);
        this.transform.SetSiblingIndex(aspectList.Count);

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
        GameObject objToDelete = aspectList[posToDelete];

        //Remove it from the calc list
        theCalcs.visualAspects.RemoveAt(posToDelete);

        //Call ToolCalcs function to update all the NPCs that could have been using what we just deleted
        theCalcs.DeletedAspect(posToDelete);

        //Remove it from this list
        aspectList.RemoveAt(posToDelete);
        Destroy(objToDelete);

        for (int i = 0; i < aspectList.Count; i++)
        {
            if (aspectList[i].GetComponentInChildren<IAmAspect>().myIndexInButton > posToDelete)
            {
                aspectList[i].GetComponentInChildren<IAmAspect>().UpdateIndex();
            }
        }
    }
}
