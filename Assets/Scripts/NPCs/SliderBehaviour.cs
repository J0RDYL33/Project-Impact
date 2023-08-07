using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderBehaviour : MonoBehaviour
{
    public TMP_Text textObject;
    public Slider sliderObject;

    public int indexInNPC;
    public string nameOfAttribute;
    public float valueOfSlider;

    private ToolCalcs myCalcs;
    private IAmNPC myNPC;
    // Start is called before the first frame update
    void Start()
    {
        myCalcs = FindObjectOfType<ToolCalcs>();
        myNPC = GetComponentInParent<IAmNPC>();

        myNPC.mySliders.Add(this);

        UpdateIndex();
        UpdateText();
        UpdateValue();
    }

    public void UpdateText()
    {
        nameOfAttribute = myCalcs.NPCAttributes[indexInNPC];
        textObject.text = nameOfAttribute;
    }

    //Called when the slider value changes
    public void UpdateValue()
    {
        valueOfSlider = sliderObject.value;
    }

    public void UpdateIndex()
    {
        indexInNPC = myNPC.mySliders.IndexOf(this);

        this.gameObject.name = indexInNPC.ToString();
    }
}
