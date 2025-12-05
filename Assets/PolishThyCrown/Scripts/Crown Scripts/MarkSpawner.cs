
using UnityEngine;

public class MarkSpawner : MonoBehaviour
{
    int MarkPlacements;
    public PrefabMarkScript mark;
    // public int[] dungLocationSpaces; (Add for quaility of life to spawn dung off each other using array)
    private void Start()
    {
        int maxCount = 5;
        int currentCount = 0;

        while (currentCount < maxCount)
        {
            Debug.Log("count for Mark went up");
            currentCount++;
            float x = Random.Range(0.21f, -0.18f);
            float y = Random.Range(2.1f, 1.75f);
            // Set area on crown to spawn Marks
            Instantiate(mark, new Vector3(x, y, 1.950f), Quaternion.identity);
            Debug.Log("Spawned Mark");

        }
        ptcGameManager.Instance.objectiveCounter.SetCounter(currentCount);
        ptcGameManager.Instance.objectiveCount = currentCount;
    }
}

