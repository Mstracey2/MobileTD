using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceButtonManager : MonoBehaviour
{
    private Image buttonImage;
    [SerializeField] private Spawner resourceSpawner;

    private void Start()
    {
        buttonImage = GetComponent<Image>();   
    }

    /// <summary>
    /// activates only when in build mode
    /// </summary>
    private void Update()
    {
        if (BuildingSystem.currentSystem.buildMode)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }


    public void Pressed(TMP_Text buttonText)
    {
        if (resourceSpawner.activated)
        {
            Deactivated(buttonText);
        }
        else
        {
            Activated(buttonText);
        }
    }

    public void Activated(TMP_Text buttonText)
    {
        buttonImage.color = Color.green;
        buttonText.text = "active";
        resourceSpawner.activated = true;
    }

    public void Deactivated(TMP_Text buttonText)
    {
        buttonImage.color = Color.red;
        buttonText.text = "Deactive";
        resourceSpawner.activated = false;
    }
}
