using UnityEngine;

namespace DirtPoorPeasants.FeedMyAnimals
{
    public class GameManager : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [SerializeField] private bool _gameOver = false;

        [Header("Components")]

        [SerializeField] private AudioListener _audioListener;

        [Header("Scripts")]

        [SerializeField] private GronknoliusSoundPlayer _gronknoliusSoundPlayer;

        public static GameManager instance;

        #endregion

        #region Methods

        public void ToggleGameOver()
        {
            switch (_gameOver)
            {
                case false:
                    _gameOver = true;
                    Time.timeScale = 0;
                    //_gronknoliusSoundPlayer.PlaySFX(1, Vector3.zero); // Remove this when win sequence is completed
                    //Debug.Log("You lost the microgame!");
                    break;
                case true:
                    _gameOver= false;
                    Time.timeScale = 1;
                    //Debug.Log("You won the microgame!");
                    break;
            }
        }

        public bool GetGameOverValue()
        {
            return _gameOver;
        }

        #endregion

        #region Unity Methods

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        #endregion
    }
}