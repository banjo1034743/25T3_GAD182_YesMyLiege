using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : PlayerPrefs
{
    public float masterVolumeValue = PlayerPrefs.GetFloat("masterVolumeValue", 0);
    public float musicVolumeValue = PlayerPrefs.GetFloat("musicVolumeValue", 0);
    public float sfxVolumeValue = PlayerPrefs.GetFloat("sfxVolumeValue", 0);
    public int graphicsValue = PlayerPrefs.GetInt("graphicsValue", 0);
    public float textSpeed = PlayerPrefs.GetFloat("textSpeed", 0.03f);
}

public class SettingsManager : MonoBehaviour
{
    public Slider masterVolSlider;
    public Slider musicVolSlider;
    public Slider sfxVolSlider;
    public AudioMixer mainAudioMixer;

    public Button graphicButtonLow;
    public Button graphicButtonModerate;
    public Button graphicButtonHigh;
    private int valueIntGraphics;

    public Button textButtonSlow;
    public Button textButtonMedium;
    public Button textButtonFast;
    [SerializeField] private float valueFloatText;

    private string currentScene;

    private void Awake()
    {
        masterVolSlider.value = PlayerPrefs.GetFloat("masterVolumeValue");
        musicVolSlider.value = PlayerPrefs.GetFloat("musicVolumeValue");
        sfxVolSlider.value = PlayerPrefs.GetFloat("sfxVolumeValue");

        valueIntGraphics = PlayerPrefs.GetInt("graphicsValue");
        QualitySettings.SetQualityLevel(valueIntGraphics);

        valueFloatText = PlayerPrefs.GetFloat("textSpeed");
        PlayerPrefs.SetFloat("textSpeed", valueFloatText);
    }

    public void ChangeMasterVolume()
    {
        mainAudioMixer.SetFloat("masterVolume", masterVolSlider.value);
    }

    public void ChangeMusicVolume()
    {
        mainAudioMixer.SetFloat("musicVolume", musicVolSlider.value);
    }

    public void ChangeSFXVolume()
    {
        mainAudioMixer.SetFloat("sfxVolume", sfxVolSlider.value);
    }

    public void ChangeGraphicsQuality(int graphicsSetting)
    {
        valueIntGraphics = graphicsSetting;

        QualitySettings.SetQualityLevel(valueIntGraphics);
    }

    public void ChangeTextSpeed(float speed)
    {
        valueFloatText = speed;
        PlayerPrefs.SetFloat("textSpeed", valueFloatText);
    }

    public void SaveChanges()
    {
        PlayerPrefs.SetFloat("masterVolumeValue", masterVolSlider.value);
        PlayerPrefs.SetFloat("musicVolumeValue", musicVolSlider.value);
        PlayerPrefs.SetFloat("sfxVolumeValue", sfxVolSlider.value);
        PlayerPrefs.SetInt("graphicsValue", valueIntGraphics);
        PlayerPrefs.SetFloat("textSpeed", valueFloatText);
    }
}