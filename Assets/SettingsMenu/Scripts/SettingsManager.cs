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
        [SerializeField] private Slider masterVolSlider;
        [SerializeField] private AudioMixer mainAudioMixer;

        private string currentScene;

        private void Awake()
        {
            masterVolSlider.value = PlayerPrefs.GetFloat("masterVolumeValue");
        }

        public void ChangeMasterVolume()
        {
            mainAudioMixer.SetFloat("masterVolume", masterVolSlider.value);
        }

        public void SaveChanges()
        {
            PlayerPrefs.SetFloat("masterVolumeValue", masterVolSlider.value);
        }
    }
}