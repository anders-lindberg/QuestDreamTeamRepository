using UnityEngine;
using UnityEngine.UIElements;

public class HealthUIScripts : MonoBehaviour
{
    private Label hpLabel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
         var root = GetComponent<UIDocument>().rootVisualElement;
        hpLabel = root.Q<Label>("hp");

    }

    // Update is called once per frame
    void Update()
    {
        if (hpLabel != null && PlayerHealthManager.Instance != null)
        {
            hpLabel.text = $"HP: {PlayerHealthManager.Instance.currentHp}/{PlayerHealthManager.Instance.maxHp}";
        }

    }
}
