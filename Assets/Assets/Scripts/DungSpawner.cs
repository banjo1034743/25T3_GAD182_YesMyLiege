
using UnityEngine;

public class DungLocationRandomizer : MonoBehaviour
{
    int DungPlacements;
    public GameObject dung;
    private void Start()
    {
        int maxCount = 5;
        int currentCount = 0;
        while (currentCount <= maxCount)
            Debug.Log("count for dung went up");
        {
            currentCount++;
            int x = Random.Range(20, -20);
            Instantiate(dung, new Vector3(x, 0, 0), Quaternion.identity);
            Debug.Log("Spawned dung");

        }

    }
}

// could change to track number of dung till it switches off instaead of times it commanded for simplicity?

