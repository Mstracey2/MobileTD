using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class builderUIScript : MonoBehaviour
{

    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject scroll;
    [SerializeField] private Color greyed;
    private Color backgroundColour;

    private void Start()
    {
        backgroundColour = GetComponent<Image>().color;
    }

    public void ChangePanel(GameObject newPanel, GameObject newScroll)
    {
        if(newScroll != scroll)
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
