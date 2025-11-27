using UnityEngine;

namespace DirtPoorPeasants.FeedMyAnimals
{
    public class AppleDestroyer : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if (GameManager.instance.GetGameOverValue())
            {
                Destroy(gameObject);
            }
        }
    }
}