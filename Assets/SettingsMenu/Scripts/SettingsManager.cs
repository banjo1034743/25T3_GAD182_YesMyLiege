using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace DirtPoorPeasants.Settings
{
    public class Settings : PlayerPrefs
    {
        public float masterVolumeValue = PlayerPrefs.GetFloat("masterVolumeValue", 0);
    }

    public class SettingsManager : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _settingsMenu;

        [Header("Master Volume")]

        [SerializeField] private Slider masterVolSlider;

        [SerializeField] private AudioMixer mainAudioMixer;

        #endregion

        #region Methods

        public void ChangeMasterVolume()
        {
            mainAudioMixer.SetFloat("masterVolume", masterVolSlider.value);
        }

        public void ToggleSettingsMenu()
        {
            switch (_settingsMenu.activeSelf)
            {
                case true:
                    _settingsMenu.SetActive(false);
                    break;
                case false:
                    _settingsMenu.SetActive(true);
                    break;
            }
        }

        public void SaveChanges()
        {
            PlayerPrefs.SetFloat("masterVolumeValue", masterVolSlider.value);
        }

        #endregion

        #region Unity Methods

        private void Awake()
        {
            masterVolSlider.value = PlayerPrefs.GetFloat("masterVolumeValue");
        }

        #endregion
    }
}