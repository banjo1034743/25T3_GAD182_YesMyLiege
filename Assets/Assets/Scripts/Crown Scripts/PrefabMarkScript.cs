
using Unity.VisualScripting;
using UnityEngine;

public class PrefabDungScript : MonoBehaviour
{
    ObjectiveCounter objectiveCounter;
    GameObject mark;
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

    // ^ For testing if unable to rewmove mark in game

    private void MarkCleared()
    {
        cusGameManager.Instance.objectiveCount--;
        cusGameManager.Instance.objectiveCounter.DecrementCounter();
        Destroy(gameObject);
    }

    private void MarkOpacity()
    {
        Color newColour = this.GetComponent<MeshRenderer>().material.color;
        newColour.a -= Time.deltaTime * opacityDelay;
        this.GetComponent<MeshRenderer>().material.color = newColour;

        if (newColour.a <= 0f)
        {
            MarkCleared();
        }
    }

    void OnTriggerStay(Collider player)
    {
        if (player.gameObject.GetComponent<Player>() != null)
        {
            MarkOpacity();
        }
    }
}
