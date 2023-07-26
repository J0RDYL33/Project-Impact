using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvasChanger : MonoBehaviour
{
    [SerializeField] private GameObject activeCanvas;
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject npcAttributeCanvas;
    [SerializeField] private GameObject visualTraitCanvas;
    [SerializeField] private GameObject NPCCanvas;
    // Start is called before the first frame update
    void Start()
    {
        mainCanvas.SetActive(true);
        npcAttributeCanvas.SetActive(false);
        visualTraitCanvas.SetActive(false);
        NPCCanvas.SetActive(false);

        activeCanvas = mainCanvas;
    }

    public void BackToMenu()
    {
        activeCanvas.SetActive(false);
        visualTraitCanvas.SetActive(false);
        NPCCanvas.SetActive(false);

        mainCanvas.SetActive(true);
    }

    public void ToNPCAttribute()
    {
        mainCanvas.SetActive(false);
        visualTraitCanvas.SetActive(false);
        NPCCanvas.SetActive(false);

        npcAttributeCanvas.SetActive(true);

        activeCanvas = npcAttributeCanvas;
    }

    public void ToVisualTrait()
    {
        mainCanvas.SetActive(false);
        visualTraitCanvas.SetActive(true);
        NPCCanvas.SetActive(false);

        npcAttributeCanvas.SetActive(false);

        activeCanvas = visualTraitCanvas;
    }

    public void ToNPC()
    {
        mainCanvas.SetActive(false);
        visualTraitCanvas.SetActive(false);
        NPCCanvas.SetActive(true);

        npcAttributeCanvas.SetActive(false);

        activeCanvas = visualTraitCanvas;
    }
}
