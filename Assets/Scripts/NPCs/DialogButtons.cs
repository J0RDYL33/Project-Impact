using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogButtons : MonoBehaviour
{
    [SerializeField] private GameObject dialogPrefab;
    [SerializeField] private GameObject parentOfDialog;
    [SerializeField] private List<GameObject> dialogsIveCreated;
    [SerializeField] private RectTransform myRect;
    private IAmNPC myNPC;

    private void Start()
    {
        myNPC = GetComponentInParent<IAmNPC>();
    }

    public void InstantiateDialog()
    {
        GameObject newDialog = Instantiate(dialogPrefab, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        newDialog.transform.SetParent(parentOfDialog.transform);
        newDialog.transform.localScale = new Vector3(1, 1, 1);

        dialogsIveCreated.Add(newDialog);
        newDialog.name = "Dialog " + (dialogsIveCreated.Count - 1).ToString();

        newDialog.transform.SetSiblingIndex(dialogsIveCreated.Count - 1);
        this.transform.SetSiblingIndex(dialogsIveCreated.Count);

        RefreshRect();
    }

    private void RefreshRect()
    {
        myRect.sizeDelta = new Vector2(600,0);
    }

    //ADD LATER
    public void DeleteListEntries()
    {

    }
}
