using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
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
    bool initemzone = false;
    
    // Track active item instances to prevent multiple spawns
    private GameObject activeItem1Instance;
    private bool item1Placed = false;
    
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ItemZone"))
        {
            initemzone = true;
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (placeItem.triggered && initemzone && !item1Placed)
        {
            empty1.style.backgroundImage = Empty;
            activeItem1Instance = Instantiate(item1Prefab, new Vector3(transform.position.x+3, transform.position.y, transform.position.z), Quaternion.identity);
            item1Placed = true;
            Debug.Log("Item1 placed. Flag set to prevent duplicate spawns.");
        }
    }
    
    /// <summary>
    /// Call this when item1 is picked up to reset the placement flag.
    /// </summary>
    public void OnItem1PickedUp()
    {
        activeItem1Instance = null;
        item1Placed = false;
        Debug.Log("Item1 picked up. Can place again.");
    }
    

}
