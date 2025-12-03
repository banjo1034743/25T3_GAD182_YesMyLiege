using UnityEngine;

public class LoadNewScene : MonoBehaviour

{
   // public int sceneNumber = 0;

    // HOW TRANSTION SCENE WORKS (in order):
     // - Microgame from pool with be randomly selected, for the next microgame to play and inforation to be displayed in this transition (X)
    // - When loaded into the scene, the scene will last for exactly 5 seconds (X)
    // - in that time I need to fit a small trumpet play, with turmpts rotating into view to play - Manage with Banjo ?
    // - A scroll will be visible on the side showing a sprite of the input you'll neeed for the next microgame
    // - King will say (with ui flavoured as a speech bubble) what to do next (next microgame chore thingy).
    // - transistion to next microgame (X)
    // ((X) = Done)

    private float totalTime = 5f;
    private float currentTime;

    public int microgameSelected;

    void Start()
    {
        PickRandomMicrogame();

        currentTime = totalTime;

    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        print(totalTime);

        if (currentTime <= 0)
        {
            BeginNextMicrogame();
        }

    }

    public void BeginNextMicrogame()
    {
        SceneSwapper.instance.LoadScene(microgameSelected);
    }

    private void PickRandomMicrogame()
    {
       microgameSelected = Random.Range(0,1);
       print ($"microgame selected: {microgameSelected}");
    }
}
