using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AspectSliders : MonoBehaviour
{
    public TMP_Text textObject;
    public Slider sliderObject;
    [SerializeField] private TMP_Text onSliderDigit;

    public int indexInAspect;
    public string nameOfAspect;
    public float valueOfSlider;

    private ToolCalcs myCalcs;
    private IAmAspect myAspect;
    // Start is called before the first frame update
    void Start()
    {
        myCalcs = FindObjectOfType<ToolCalcs>();
        myAspect = GetComponentInParent<IAmAspect>();

        myAspect.mySliders.Add(this);

        UpdateIndex();
        UpdateText();
        UpdateValue();
    }

    public void UpdateIndex()
    {
        indexInAspect = myAspect.mySliders.IndexOf(this);

        this.gameObject.name = indexInAspect.ToString();
    }

    public void UpdateText()
    {
        UpdateIndex();
        nameOfAspect = myCalcs.visualAttributes[indexInAspect];
        textObject.text = nameOfAspect;
    }

    //Called when the slider value changes
    public void UpdateValue()
    {
        valueOfSlider = sliderObject.value;
        onSliderDigit.text = valueOfSlider.ToString();
    }
}
