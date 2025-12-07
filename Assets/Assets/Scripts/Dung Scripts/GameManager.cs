using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
public static GameManager Instance { get; private set; }
    public ObjectiveCounter objectiveCounter;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        // Class Starts here, ignore above (is needed, dont even worry about it)
    }
    public int objectiveCount;
    
     private void CompletionChecker()
     {
         if (objectiveCount <= 0)
         {
             SceneManager.LoadScene("Intermission Scene");
         }
    
}
}
