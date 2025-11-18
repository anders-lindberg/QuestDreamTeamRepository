using UnityEngine;
using UnityEngine.InputSystem;
public class Score : MonoBehaviour
{
    InputAction increaseScoreAction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // create and enable a new button action for increasing score
        increaseScoreAction = InputSystem.actions.FindAction("Attack");
        increaseScoreAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (increaseScoreAction.WasPressedThisFrame())
        {
            HUDScript.IncreaseScore();
        } 
    }
}
