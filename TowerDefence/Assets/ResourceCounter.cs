using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceCounter : MonoBehaviour
{
    [SerializeField] private ResourceType resource;
    private TMP_Text counterText;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        counterText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        counterText.text = counter.ToString();
    }

    public ResourceType GetResourceType()
    {
        return resource;
    }

    public void AddToCounter()
    {
        counter++;
    }
}
