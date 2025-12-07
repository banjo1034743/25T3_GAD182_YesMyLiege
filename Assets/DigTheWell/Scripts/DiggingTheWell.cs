using UnityEngine;

public class DiggingTheWell : MonoBehaviour
{
    public float moveAmount;
    private int clickCount = 0;
    private bool isCleared = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.Find("dirt").transform.position += new Vector3(0, moveAmount, 0);
            clickCount++;
            Debug.Log("Mouse button clicked " + clickCount);
        }
        if (clickCount >= 20 && !isCleared)
        {
            Debug.Log("Cleared");
            isCleared = true;
            //end scene here
        }
    }
}
