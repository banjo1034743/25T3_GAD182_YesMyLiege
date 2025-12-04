using TMPro;
using UnityEngine;

namespace DirtPoorPeasants.Settings
{
    public class HelpTextManager : MonoBehaviour
    {
        #region Variables

        [Header("Components")]

        [SerializeField] private TextMeshProUGUI _helpText;

        #endregion

        #region Methods

        /// <summary>
        /// Please add a case to the switch statement below for any settings
        /// options added that need help text.
        /// </summary>
        /// <param name="settingOption"></param>
        public void DisplayHelpText(string settingOption)
        {
            switch (settingOption)
            {
                case "Master Volume":
                    _helpText.text = "Adjust how quiet or loud the audio of the game is.";
                    break;
                default:
                    _helpText.text = "There exists no settings option with that name in the switch statement. Please make sure no typos are made and that the case has correct spelling";
                    break;
            }
        }

        private void ResetHelpText()
        {
            _helpText.text = string.Empty;
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            ResetHelpText();
        }

        #endregion
    }
}