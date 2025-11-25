using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //singleton logic
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //variables that keep track of the different tnt parts in the levels:
    public bool level1TNT;
    public bool level2TNT;
    public bool level3TNT;



    //Counts how many TNT parts are collected in total by adding +1 for each level that has its TNT collected.
    //Same as saying "if level1TNT = true {tntcollected += 1} else {tntcollected += 0} etc."
    public int tNTCollected = 0;


    //method that should be called when collecting a tnt part
    public void TNTCollected(int levelIndex)
    {
        //based on the given levelindex, the corresponding bool should be set to true, so the manager knows which parts the player has collected (or not)
        switch(levelIndex)
        {
            case 1: level1TNT = true; tNTCollected++; break;

            case 2: level2TNT = true; tNTCollected++; break;

            case 3: level3TNT = true; tNTCollected++; break;
        }
    }



    public bool HasQuestBeenCompleted()
    {
        //all three variables must be true for the method to return true, meaning: "HasQuestBeenCompleted()? == true (yes)"
        return level1TNT && level2TNT && level3TNT;
    }
}
