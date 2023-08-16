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
    [SerializeField] private GameObject visualAspectCanvas;
    [SerializeField] private GameObject NPCSubMenuCanvas;
    [SerializeField] private GameObject VisualSubMenuCanvas;
    [SerializeField] private GameObject calculationsCanvas;
    // Start is called before the first frame update
    void Start()
    {
        mainCanvas.SetActive(true);
        npcAttributeCanvas.SetActive(false);
        visualTraitCanvas.SetActive(false);
        NPCCanvas.SetActive(false);
        visualAspectCanvas.SetActive(false);
        NPCSubMenuCanvas.SetActive(false);
        VisualSubMenuCanvas.SetActive(false);
        calculationsCanvas.SetActive(false);

        activeCanvas = mainCanvas;
    }

    public void BackToMenu()
    {
        activeCanvas.SetActive(false);
        visualTraitCanvas.SetActive(false);
        NPCCanvas.SetActive(false);
        visualAspectCanvas.SetActive(false);
        NPCSubMenuCanvas.SetActive(false);
        VisualSubMenuCanvas.SetActive(false);
        calculationsCanvas.SetActive(false);

        mainCanvas.SetActive(true);
    }

    public void ToNPCAttribute()
    {
        mainCanvas.SetActive(false);
        visualTraitCanvas.SetActive(false);
        NPCCanvas.SetActive(false);
        visualAspectCanvas.SetActive(false);
        npcAttributeCanvas.SetActive(true);
        NPCSubMenuCanvas.SetActive(false);
        VisualSubMenuCanvas.SetActive(false);
        calculationsCanvas.SetActive(false);

        activeCanvas = npcAttributeCanvas;
    }

    public void ToVisualTrait()
    {
        mainCanvas.SetActive(false);
        visualTraitCanvas.SetActive(true);
        NPCCanvas.SetActive(false);
        visualAspectCanvas.SetActive(false);
        npcAttributeCanvas.SetActive(false);
        NPCSubMenuCanvas.SetActive(false);
        VisualSubMenuCanvas.SetActive(false);
        calculationsCanvas.SetActive(false);

        activeCanvas = visualTraitCanvas;
    }

    public void ToNPC()
    {
        mainCanvas.SetActive(false);
        visualTraitCanvas.SetActive(false);
        NPCCanvas.SetActive(true);
        visualAspectCanvas.SetActive(false);
        npcAttributeCanvas.SetActive(false);
        NPCSubMenuCanvas.SetActive(false);
        VisualSubMenuCanvas.SetActive(false);
        calculationsCanvas.SetActive(false);

        activeCanvas = NPCCanvas;
    }

    public void ToVisual()
    {
        mainCanvas.SetActive(false);
        visualTraitCanvas.SetActive(false);
        NPCCanvas.SetActive(false);
        visualAspectCanvas.SetActive(true);
        npcAttributeCanvas.SetActive(false);
        NPCSubMenuCanvas.SetActive(false);
        VisualSubMenuCanvas.SetActive(false);
        calculationsCanvas.SetActive(false);

        activeCanvas = visualTraitCanvas;
    }

    public void ToNPCSub()
    {
        mainCanvas.SetActive(false);
        visualTraitCanvas.SetActive(false);
        NPCCanvas.SetActive(false);
        visualAspectCanvas.SetActive(false);
        npcAttributeCanvas.SetActive(false);
        NPCSubMenuCanvas.SetActive(true);
        VisualSubMenuCanvas.SetActive(false);
        calculationsCanvas.SetActive(false);

        activeCanvas = visualTraitCanvas;
    }

    public void ToVisualSub()
    {
        mainCanvas.SetActive(false);
        visualTraitCanvas.SetActive(false);
        NPCCanvas.SetActive(false);
        visualAspectCanvas.SetActive(false);
        npcAttributeCanvas.SetActive(false);
        NPCSubMenuCanvas.SetActive(false);
        VisualSubMenuCanvas.SetActive(true);
        calculationsCanvas.SetActive(false);

        activeCanvas = visualTraitCanvas;
    }

    public void ToCalcs()
    {
        mainCanvas.SetActive(false);
        visualTraitCanvas.SetActive(false);
        NPCCanvas.SetActive(false);
        visualAspectCanvas.SetActive(false);
        npcAttributeCanvas.SetActive(false);
        NPCSubMenuCanvas.SetActive(false);
        VisualSubMenuCanvas.SetActive(false);
        calculationsCanvas.SetActive(true);

        activeCanvas = calculationsCanvas;
    }
}
