using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPCClasses;

namespace NPCClasses
{
    public struct Dialog
    {
        int dialogPlacement;
        int firstDropdownEffector;
        int secondDropdownEffector;
        string dialogText;

        public Dialog(int myPlace)
        {
            this.dialogPlacement = myPlace;
            this.firstDropdownEffector = -1;
            this.secondDropdownEffector = -1;
            this.dialogText = "";
        }
    }

    public class NPC
    {
        public string name;
        public List<float> sliderValues;
        public List<Dialog> dialogs;
    }
}
public class ToolCalcs : MonoBehaviour
{
    public List<string> NPCAttributes;
    public List<string> VisualAttributes;
    public List<NPC> NPCs;

}
