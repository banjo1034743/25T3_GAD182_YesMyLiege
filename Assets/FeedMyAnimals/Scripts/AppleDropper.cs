using UnityEngine;
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

        private InputActionMap _feedMyAnimalsActionMap;

        private InputAction _dropAction;

        #endregion

        #region Methods

        public void DropApple()
        {
            if (_dropAction.WasPerformedThisFrame())
            {
                if (AppleManager.instance.GetAppleCount() >= 0)
                {
                    Instantiate(_apple, _positionToDropApples.position, Quaternion.identity);
                }
            }
        }

        private void InitializeScript()
        {
            _feedMyAnimalsActionMap = InputSystem.actions.FindActionMap("Microgame/FeedMyAnimals");
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