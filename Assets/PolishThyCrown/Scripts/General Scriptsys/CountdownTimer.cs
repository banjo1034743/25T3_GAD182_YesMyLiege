using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
// Timer Added incase hourglass is not completed by Project 3.
{
    private float startTime = 10f;
    private float currentTime;
    public TMP_Text countDownTimer;

    void Start()
    {
        currentTime = startTime;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            countDownTimer.text = Mathf.Ceil(currentTime).ToString();
        }
        else
        {
            countDownTimer.text = "0";
            // SceneManager.LoadScene("GameOverScene"); To be impleted once Game Over Scene is Made.

        }
    }

}
