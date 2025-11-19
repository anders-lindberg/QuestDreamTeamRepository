using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class Inventory : MonoBehaviour
{
    public UIDocument miniInventoryUI;
    VisualElement keyIcon;
    VisualElement inventory;
    StyleBackground noKey;
    StyleBackground yesKey;
    bool hasKey = false;
    void OnEnable()
    {
        noKey = new StyleBackground(Resources.Load<Texture2D>("NoKey"));
        yesKey = new StyleBackground(Resources.Load<Texture2D>("YesKey"));

        VisualElement root = miniInventoryUI.rootVisualElement;
        inventory = root.Q<VisualElement>("Inventory");
        keyIcon = root.Q<VisualElement>("KeyIcon");
        keyIcon.style.backgroundImage = noKey;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            keyIcon.style.backgroundImage = yesKey;
            hasKey = true;
            collision.gameObject.SetActive(false);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
