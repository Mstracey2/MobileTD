using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBuilderSection : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject scroll;
    [SerializeField] private builderUIScript builder;


    /// <summary>
    /// function that passes through the corrolating tabs and menus to the tab change function.
    /// </summary>
    public void ChangeSection()
    {
        builder.ChangePanel(button, scroll);
    }
}
