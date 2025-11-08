using UnityEngine;

public class cusGameManager : MonoBehaviour
{
public static cusGameManager Instance { get; private set; }
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
    }
    public int objectiveCount;
    
 

}