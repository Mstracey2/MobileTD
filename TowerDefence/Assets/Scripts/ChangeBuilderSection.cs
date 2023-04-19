using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBuilderSection : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject scroll;
    [SerializeField] private builderUIScript builder;

    public void ChangeSection()
    {
        builder.ChangePanel(button, scroll);
    }
}
