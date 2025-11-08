
using UnityEngine;

public class DungSpawner : MonoBehaviour
{
    int MarkPlacements;
    public PrefabDungScript mark;
    // public int[] dungLocationSpaces; (Add for quaility of life to spawn dung off each other using array)
    private void Start()
    {
        int maxCount = 5;
        int currentCount = 0;

        while (currentCount < maxCount)
        {
            Debug.Log("count for Mark went up");
            currentCount++;
            int x = Random.Range(9, -9);
            int y = Random.Range(9, -9);
            Instantiate(mark, new Vector3(x, y, 0), Quaternion.identity);
            Debug.Log("Spawned Mark");

        }
        cusGameManager.Instance.objectiveCounter.SetCounter(currentCount);
        cusGameManager.Instance.objectiveCount = currentCount;
    }
}

// could change to track number of dung till it switches off instaead of times it commanded for simplicity?

