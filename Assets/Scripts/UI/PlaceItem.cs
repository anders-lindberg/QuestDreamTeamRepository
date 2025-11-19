using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using UnityEditor.SceneManagement;
public class PlaceItem : MonoBehaviour
{
    InputAction placeItem;
    public UIDocument InventoryUI;
    StyleBackground Empty;
    StyleBackground Item1;
    StyleBackground Item2;
    StyleBackground Item3;
    VisualElement inventory;
    VisualElement empty1;
    VisualElement empty2;
    VisualElement empty3;
    public GameObject item1Prefab;
    public GameObject item2Prefab; 
    public GameObject item3Prefab;
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        placeItem = InputSystem.actions.FindAction("PlaceItem");
        placeItem.Enable();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (placeItem.triggered)
        {
            empty1.style.backgroundImage = Empty;
            Instantiate(item1Prefab, new Vector3(transform.position.x+3, transform.position.y, transform.position.z), Quaternion.identity);
        
        }
    }
}
