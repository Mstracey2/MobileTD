using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public Gradient gradient;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();

    }

    /// <summary>
    /// function to set max health on the bar
    /// </summary>
    /// <param name="maxHealth"></param>
    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        fill.color = gradient.Evaluate(1f);
    }


    /// <summary>
    /// function to update the health on the bar
    /// </summary>
    /// <param name="health"></param>
    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
