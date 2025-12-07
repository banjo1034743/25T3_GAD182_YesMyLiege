using UnityEditor.SearchService;
using UnityEngine;

public class LoadNewScene : MonoBehaviour


{
    public Scroll scroll;
    private float totalTime = 2f;
    private float currentTime;

    public int microgameSelected;

    public GameObject transSceneHolder;

    void Start()
    {
        PickRandomMicrogame();

        currentTime = totalTime;

    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        
        if (currentTime <= 0)
        {
            BeginNextMicrogame();
            scroll.TransSceneSpritesReset();
        }

        else
        {
            print(currentTime);
        }

    }

    public void BeginNextMicrogame()
    {
        // print(SceneSwapper.instance.gameScenes[microgameSelected]);
        SceneSwapper.instance.LoadUnloadScene(SceneSwapper.instance.gameScenes[microgameSelected]);
        transSceneHolder.SetActive(false);
    }

    private void PickRandomMicrogame()
    {
       microgameSelected = Random.Range(1,6); // set to 1,8
       print ($"microgame selected: {microgameSelected}");
    }


    public void MoveToNextScene()
    {
        SceneSwapper.instance.LoadUnloadScene("TransitionScene");
        transSceneHolder.SetActive(true);
        
    }
}
