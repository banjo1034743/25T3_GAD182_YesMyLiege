using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scroll : MonoBehaviour
{
   public LoadNewScene loadnewScene;
    public SpriteRenderer aIcon;
    public SpriteRenderer dIcon;
    public SpriteRenderer leftMouseClickIcon;
    public SpriteRenderer moveMouseIcon;
    public TextMeshPro scrollText;

    public SceneManager TransitionScene;

    /* Microgame Selection Guide
    1 = Polish Thy Crown
    2 = Clean Up Stables
    3 = Feed My Animals
    4 = Dig The Well
    5 = Hammer The Post
    6 = Parry The Knight
    7 = Royal Marksman
    */


   // public Sprite[] iconList;

    void Start()
    {
        ScrollTip();
    }

    private void ScrollTip()
    {   
         if (loadnewScene.microgameSelected == 1) 
        {
            moveMouseIcon.enabled = true;
            scrollText.text = "Polish Thy Crown";
        }

        else if (loadnewScene.microgameSelected == 2)
        {
            aIcon.enabled = true;
            dIcon.enabled = true;
            scrollText.text = "Clean Up Stables";
        }
        
         else if (loadnewScene.microgameSelected == 3)
        {
            moveMouseIcon.enabled = true;
            scrollText.text = "Feed My Animals";
        }

         else if (loadnewScene.microgameSelected == 4)
        {
            
        }
         else if (loadnewScene.microgameSelected == 5)
        {
            
        }

         else if (loadnewScene.microgameSelected == 6)
        {
            
        }

         else if (loadnewScene.microgameSelected == 7)
        {
            
        }
        else
        {
            print("No microgame was selected.");
        }
        
        // I love balatro coding!
    }

    public void TransSceneSpritesReset()
    {
        if (SceneManager.GetSceneByName("TransitionScene") != SceneManager.GetActiveScene())
        {
            aIcon.enabled = false;
            dIcon.enabled = false;
            leftMouseClickIcon.enabled = false;
            moveMouseIcon.enabled = false;
        }
    }
}
