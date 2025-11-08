
using Unity.VisualScripting;
using UnityEngine;

public class PrefabDungScript : MonoBehaviour
{
    ObjectiveCounter objectiveCounter;
    GameObject dung;
    Player player;
    float opacityDelay = 0.5f;



    private float deleteThis;

    // private void Start()
    // {
    //     deleteThis = 1;
    // }
    // private void Update()
    // {
    //     deleteThis -= Time.deltaTime;

    //     if (deleteThis < 0)
    //     {
    //         deleteThis = 1;
    //         DungOpacity();
    //     }
    // }

    // ^ For testing if unable to rewmove dung in game

    private void DungCleared()
    {
        cusGameManager.Instance.objectiveCount--;
        cusGameManager.Instance.objectiveCounter.DecrementCounter();
        Destroy(gameObject);
    }

    private void DungOpacity()
    {
        Color newColour = this.GetComponent<MeshRenderer>().material.color;
        newColour.a -= Time.deltaTime * opacityDelay;
        this.GetComponent<MeshRenderer>().material.color = newColour;

        if (newColour.a <= 0f)
        {
            DungCleared();
        }
    }

    void OnTriggerStay(Collider player)
    {
        if (player.gameObject.GetComponent<Player>() != null)
        {
            DungOpacity();
        }
    }

    // when player touches dung trigger, lower opacity (script for owoer opacity done) ><
    // once opacity hits 0 delte object ><
    //make sure delting object affects score ><
    // add line to chnage to intermission scene ><
}
