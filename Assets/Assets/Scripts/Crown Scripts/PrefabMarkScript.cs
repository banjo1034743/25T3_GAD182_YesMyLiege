
using Unity.VisualScripting;
using UnityEngine;

public class PrefabMarkScript : MonoBehaviour
{
    ObjectiveCounter objectiveCounter;
    GameObject mark;
    Player player;
    float opacityDelay = 0.5f;

     Vector3 lastPos;


    void Start()
    {
        lastPos = this.gameObject.transform.position;
    }




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
        GameManager.Instance.objectiveCount--;
        GameManager.Instance.objectiveCounter.DecrementCounter();
        Destroy(gameObject);
    }

    private void MarkOpacity()
    {
        Color newColour = this.GetComponent<SpriteRenderer>().material.color;
        newColour.a -= Time.deltaTime * opacityDelay;
        this.GetComponent<SpriteRenderer>().material.color = newColour;

        if (newColour.a <= 0f)
        {
            MarkCleared();
        }
    }
    void OnTriggerStay(Collider ragTrigger)
    {
        if (ragTrigger.gameObject.GetComponent<Player>() != null && ragTrigger.gameObject.transform.position != lastPos)
        {
            MarkOpacity();
            print("Detected mark with rag");
            lastPos = ragTrigger.gameObject.transform.position;

        }
    }
}
