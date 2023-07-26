using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePanelToContent : MonoBehaviour
{
    public RectTransform contentRect;
    private RectTransform myRect;
    // Start is called before the first frame update
    void Start()
    {
        myRect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myRect.sizeDelta = new Vector2(660, contentRect.sizeDelta.y + 20);
    }
}
