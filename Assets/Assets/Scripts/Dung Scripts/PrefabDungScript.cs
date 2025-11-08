
using UnityEngine;

public class PrefabDungScript : MonoBehaviour
{
    ObjectiveCounter objectiveCounter;

    private float deleteThis;

    private void Start()
    {
        deleteThis = 1;
    }
    private void Update()
    {
        deleteThis -= Time.deltaTime;

        if (deleteThis < 0)
        {
            deleteThis = 1;
            DungOpacity();
        }
    }

    // ^ For testing if unable to rewmove dung in game

    private void DungCleared()
    {



        cusGameManager.Instance.objectiveCount--;
        cusGameManager.Instance.objectiveCounter.DecrementCounter();
    }

    private void DungOpacity()
    {
        Color newColour = this.GetComponent<MeshRenderer>().material.color;
        newColour.a -= 0.1f;
        this.GetComponent<MeshRenderer>().material.color = newColour;
    }
    
    // when player touches dung trigger, lower opaxity (script for owoer opacity done)
    // once opacity hits 0 delte object
    //make sure delting object affects score
    // add line to chnage o intermission scene
}
