using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class Inventory : MonoBehaviour
{
    public UIDocument InventoryUI;
    VisualElement keyIcon;
    VisualElement inventory;
    StyleBackground noKey;
    StyleBackground yesKey;
    
    void OnEnable()
    {
        // Defensive checks to prevent NullReferenceException from breaking UI
        if (InventoryUI == null)
        {
            Debug.LogWarning("InventoryUI reference is missing on Inventory component.");
            return;
        }

        var noKeyTex = Resources.Load<Texture2D>("NoKey");
        var yesKeyTex = Resources.Load<Texture2D>("YesKey");
        if (noKeyTex == null || yesKeyTex == null)
        {
            Debug.LogWarning("NoKey or YesKey texture not found in Resources folder. Ensure textures are in Assets/Resources/");
        }

        noKey = new StyleBackground(noKeyTex);
        yesKey = new StyleBackground(yesKeyTex);

        VisualElement root = InventoryUI.rootVisualElement;
        if (root == null)
        {
            Debug.LogWarning("Could not get rootVisualElement from UIDocument.");
            return;
        }

        // Assign to class field (not local variable) to avoid shadowing
        inventory = root.Q<VisualElement>("inventory");
        if (inventory == null)
        {
            Debug.LogWarning("Could not find 'inventory' VisualElement in UIDocument. Check the element name/ID in UI Builder.");
            return;
        }

        keyIcon = inventory.Q<VisualElement>("keyIcon");
        if (keyIcon == null)
        {
            Debug.LogWarning("Could not find 'keyIcon' VisualElement inside inventory. Check the element name/ID in UI Builder.");
            return;
        }

        if (noKeyTex != null)
            keyIcon.style.backgroundImage = noKey;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            Debug.Log($"[Inventory] Key collected! InventoryUI active: {InventoryUI.gameObject.activeSelf}, inventory display: {inventory?.style.display}");
            
            // Defensive check: ensure keyIcon is initialized before updating
            if (keyIcon == null)
            {
                Debug.LogWarning("keyIcon is null in OnTriggerEnter2D. UI setup may have failed.");
                return;
            }

            try
            {
                keyIcon.style.backgroundImage = yesKey;
                Debug.Log("Key collected! UI updated to YesKey.");
                
                // Ensure the UI elements are still visible after update
                if (inventory != null)
                {
                    inventory.style.display = DisplayStyle.Flex; // force visible
                    Debug.Log($"[Inventory] Forced inventory display to Flex. Current: {inventory.style.display}");
                }
                if (InventoryUI != null)
                {
                    InventoryUI.gameObject.SetActive(true); // ensure UIDocument GameObject is active
                    Debug.Log($"[Inventory] Ensured UIDocument active: {InventoryUI.gameObject.activeSelf}");
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error updating keyIcon: " + e.Message);
            }
            
            Debug.Log($"[Inventory] Before deactivating key. InventoryUI active: {InventoryUI.gameObject.activeSelf}");
            collision.gameObject.SetActive(false);
            Debug.Log($"[Inventory] After deactivating key. InventoryUI active: {InventoryUI.gameObject.activeSelf}");
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
