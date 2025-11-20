using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{
    public UIDocument InventoryUI;
    StyleBackground Empty;
    StyleBackground Item1;
    StyleBackground Item2;
    StyleBackground Item3;
    VisualElement inventory;
    VisualElement empty1;
    VisualElement empty2;
    VisualElement empty3;

    void OnEnable()
    {
        Empty = new StyleBackground(Resources.Load<Texture2D>("empty"));
        Item1 = new StyleBackground(Resources.Load<Texture2D>("item1"));
        Item2 = new StyleBackground(Resources.Load<Texture2D>("item2"));
        Item3 = new StyleBackground(Resources.Load<Texture2D>("item3"));
        

        VisualElement root = InventoryUI.GetComponent<UIDocument>().rootVisualElement;
        VisualElement inventory = root.Q<VisualElement>("inventory");
        empty1 = inventory.Q<VisualElement>("empty1");
        empty2 = inventory.Q<VisualElement>("empty2");
        empty3 = inventory.Q<VisualElement>("empty3");

        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("item1"))
        {
            empty1.style.backgroundImage = Item1;
            SoundEffectManager.Play("ItemCollect", true);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("item2"))
        {
            empty2.style.backgroundImage = Item2;
            SoundEffectManager.Play("ItemCollect", true);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("item3"))
        {
            empty3.style.backgroundImage = Item3;
            SoundEffectManager.Play("ItemCollect", true);
            Destroy(other.gameObject);
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
