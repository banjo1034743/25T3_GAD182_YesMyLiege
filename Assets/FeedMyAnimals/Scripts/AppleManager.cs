using UnityEngine;
using System.Collections.Generic;

namespace DirtPoorPeasants.FeedMyAnimals
{
    public class AppleManager : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [Tooltip("Represents the amount of apples that the player currently has. The player starts off with 6 apples")]
        [SerializeField] private int _appleAmount = 6;

        [Header("Objects")]

        [Tooltip("List of icons on the UI representing the amount of apples the player has to drop.")]
        [SerializeField] private List<GameObject> _appleIcons = new List<GameObject>();

        #endregion

        #region Methods

        public void UpdateAppleCount(int amountToUpdateBy)
        {
            _appleAmount += amountToUpdateBy;

            if (amountToUpdateBy < 0)
            {
                _appleIcons[_appleAmount].SetActive(false);
            }
        }

        public int GetAppleCount()
        {
            return _appleAmount;
        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        #endregion
    }
}