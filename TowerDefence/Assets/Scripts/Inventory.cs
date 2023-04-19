using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public int money = 50;
    [SerializeField] private TMP_Text moneyText;
    // Update is called once per frame
    void Update()
    {
        moneyText.text = "£" + money; 
    }
}
