using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LevelManager : MonoBehaviour
{
    /*variables*/
    public static LevelManager Instance;
    [SerializeField] private UIDocument fadeDocument;
    private VisualElement fadeOverlay;
    [SerializeField] private float fadeDuration = 1f;
    public string lastHubEntranceID = "Default";

    /*Loads when the script is called*/
    private void Awake()
    {
        //Singleton logic
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /*Start*/
    private void Start()
    {
        //fade-in of image 
        fadeOverlay = fadeDocument.rootVisualElement.Q<VisualElement>("FadeOverlay");
        StartCoroutine(Fade(1f,0f));
    }


    /*Fade Coroutine which takes certain alpha-values (transparency) as parameters and fades out/in based on the fadeDuration*/
    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        //keeps track of the time elapsed of the fade, and sets color to the color of the fadeImage
        float timeElapsed = 0f;

        //makes sure this only runs for the set duration
        while (timeElapsed < fadeDuration)
        {
            //updates timeElapsed based on in-game time
            timeElapsed += Time.deltaTime;

            //transparency of the image based on the set alpha start/end values by the time elapsed over fadeduration.
            //picture it as a linear graph which has start/end value, and the length is timeElapsed/fadeDuration = 1
            float a = Mathf.Lerp(startAlpha, endAlpha, timeElapsed/fadeDuration);
            fadeOverlay.style.opacity = a;

            yield return null;
        }
        //once the fade ends it sets the transparency values to the endAlpha value and assigning it to the color of the image
        fadeOverlay.style.opacity = endAlpha;
    }


    /*Starts the load-scene proces*/
    public void StartLoadScene(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    
    /*Actually loads the given scene, by fading in/out and changing the scene*/
    private IEnumerator LoadScene(string sceneName)
    {
        //fade out
        if (fadeOverlay != null)
        {
            yield return StartCoroutine(Fade(0f, 1f));
        }

        //gets and changes scene
        SceneManager.LoadScene(sceneName);

        //fade in
        if (fadeOverlay != null)
        {
            yield return StartCoroutine(Fade(1f, 0f));
        }
    }


    /*Method which always loads the Hub-scene*/
    public void ReturnToHub()
    {
        StartCoroutine(LoadScene("Hub"));
    }
}
