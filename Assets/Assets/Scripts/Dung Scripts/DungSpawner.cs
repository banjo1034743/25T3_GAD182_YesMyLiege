
using UnityEngine;

public class DungSpawner : MonoBehaviour
{
    int DungPlacements;
    public PrefabDungScript dung;
    // public int[] dungLocationSpaces; (Add for quaility of life to spawn dung off each other using array)
    private void Start()
    {
        int maxCount = 5;
        int currentCount = 0;

        while (currentCount < maxCount)
        {
            Debug.Log("count for dung went up");
            currentCount++;
            float x = Random.Range(9f, -9f);
            Instantiate(dung, new Vector3(x, 0, 0), Quaternion.Euler (0,0,90));
            Debug.Log("Spawned dung");

        }
        GameManager.Instance.objectiveCounter.SetCounter(currentCount);
        GameManager.Instance.objectiveCount = currentCount;
    }
}

// could change to track number of dung till it switches off instaead of times it commanded for simplicity?

