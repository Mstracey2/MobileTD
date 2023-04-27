using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckPlayerMoney : MonoBehaviour
{
    [SerializeField] private Inventory playerInv;
    [SerializeField] private GameObject pref;
    private ResourceController prefResource;
    [SerializeField] private Color greyedOut;
    [SerializeField] private Color selectable;
    private Image buttonImage;
    private TMP_Text costText;
    private SendToSim sim;
    private void Start()
    {
        sim = GetComponent<SendToSim>();
        costText = GetComponentInChildren<TMP_Text>();
        prefResource = pref.GetComponent<ResourceController>();
        buttonImage = GetComponent<Image>();
        costText.text = "£" + prefResource.cost;
    }

    private void Update()
    {
        if(playerInv.money >= prefResource.cost)
        {
            buttonImage.color = selectable;
        }
        else
        {
            buttonImage.color = greyedOut;
        }
    }

    public void CheckPlayerInv()
    {
        if(playerInv.money >= prefResource.cost)
        {
            playerInv.money -= prefResource.cost;
            GameObject newObj = Instantiate(pref, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 1));
            RandomizeLocation.randomLocation.RandomizeobjectLocation(newObj);
            if(sim != null)
            {
                sim.SendTo(newObj);
            }
        }
    }


}
