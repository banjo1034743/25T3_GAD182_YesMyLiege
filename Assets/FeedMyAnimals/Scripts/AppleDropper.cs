using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

namespace DirtPoorPeasants.FeedMyAnimals
{
    public class AppleDropper : MonoBehaviour
    {
        #region Variables

        [Header("Objects")]

        [Tooltip("The prefab assigned to this will be what is instantiated when dropping apples")]
        [SerializeField] private GameObject _apple;

        [Header("Components")]

        [Tooltip("The transform component that is a child to the player object which we use as the position to drop apples from.")]
        [SerializeField] private Transform _positionToDropApples;

        [SerializeField] private InputActionAsset _actions;

        [SerializeField] private AudioMixerGroup _audioMixerGroup;

        private InputActionMap _feedMyAnimalsActionMap;

        private InputAction _dropAction;

        #endregion

        #region Methods

        public void DropApple()
        {
            if (_dropAction.WasPerformedThisFrame() && !GameManager.instance.GetGameOverValue())
            {
                if (AppleManager.instance.GetAppleCount() >= 0)
                {
                    GameObject tempApple = Instantiate(_apple, _positionToDropApples.position, Quaternion.identity);

                    if (tempApple.GetComponent<AudioSource>() != null)
                    {
                        AudioSource tempAudioSource = tempApple.GetComponent<AudioSource>();
                        tempAudioSource.volume = Random.Range(0.5f, 0.75f);
                        tempAudioSource.pitch = Random.Range(1f, 1.5f);
                        tempAudioSource.outputAudioMixerGroup = _audioMixerGroup;
                    }
                }
            }
        }

        private void InitializeScript()
        {
            _feedMyAnimalsActionMap = _actions.FindActionMap("Microgame/FeedMyAnimals");
            _dropAction = _feedMyAnimalsActionMap.FindAction("Drop");
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            InitializeScript();
        }

        // Update is called once per frame
        void Update()
        {
            DropApple();
        }

        #endregion
    }
}