using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private PlayerHealthManager healthManager;

    private Button retryButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        root.style.display = DisplayStyle.None;
    }

    // Update is called once per frame
    void Update()
    {
        if(healthManager.playerIsDead != false)
        {
            DisplayGameOverMenu();
        }
    }

    void DisplayGameOverMenu()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        root.style.display = DisplayStyle.Flex;
    }

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        retryButton = root.Q<Button>("RetryButton");

        retryButton.clicked += OnRetryClicked;
    }

    void OnDisable()
    {
        retryButton.clicked -= OnRetryClicked;
    }

    void OnRetryClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
