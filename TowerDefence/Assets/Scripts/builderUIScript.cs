using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class builderUIScript : MonoBehaviour
{
    [SerializeField] private GameObject panel;          //panal that is set, will change if the player changes panels
    [SerializeField] private GameObject scroll;         //scroll menu that is set, will change on tab press
    [SerializeField] private Color greyed;
    private Color backgroundColour;

    private void Start()
    {
        backgroundColour = GetComponent<Image>().color;
    }


    /// <summary>
    /// Function that changes the scroll menu and tab colour when the player presses a new tab
    /// </summary>
    /// <param name="newPanel"></param> - new tab that the player pressed
    /// <param name="newScroll"></param> - the scroll menu that comes with that tab
    public void ChangePanel(GameObject newPanel, GameObject newScroll)
    {
        if(newScroll != scroll)                                                 //will not run if the player presses the same tab that they are already on.
        {
            newScroll.SetActive(true);
            scroll.SetActive(false);
            scroll = newScroll;
            panel.GetComponent<Image>().color = greyed;
            panel = newPanel;
            panel.GetComponent<Image>().color = backgroundColour;
        }
       
    }
}
