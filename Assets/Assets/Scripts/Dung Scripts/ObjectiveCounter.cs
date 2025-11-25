using UnityEngine;
using TMPro;

public class ObjectiveCounter : MonoBehaviour

{
    public TMP_Text ObjectiveRemainingTextBox;
    public int ObjectiveRemaining;
    // private int dungTotal = DungLocationRandomizer.currentCount;

    public void SetCounter(int counterSet)
    {
        ObjectiveRemaining = counterSet;
        TextSet();

    }

    public int DecrementCounter()
    {
        ObjectiveRemaining--;
        TextSet();
        return ObjectiveRemaining;
    }
    
    public int IncrementCounter()
    {
        ObjectiveRemaining++;
        TextSet();
        return ObjectiveRemaining;
    }

    private void TextSet()
    {
        ObjectiveRemainingTextBox.SetText(ObjectiveRemaining.ToString());
    }

}
