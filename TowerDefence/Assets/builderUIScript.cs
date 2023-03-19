using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class builderUIScript : MonoBehaviour
{

    [SerializeField] private GameObject panel;
    [SerializeField] private Color greyed;
    private Color backgroundColour;

    private void Start()
    {
        backgroundColour = GetComponent<Image>().color;
    }

    public void ChangePanel(GameObject newPanel)
    {
        panel.GetComponent<Image>().color = greyed;
        panel = newPanel;
        panel.GetComponent<Image>().color = backgroundColour;
    }
}
