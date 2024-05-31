using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioSource musicSource;

    void Start()
    {
        // Set the slider's value to the current volume
        volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        // Update the volume
        UpdateVolume();
    }

    // Call this method when the slider value changes
    public void UpdateVolume()
    {
        // Set the volume of the music source to the value of the slider
        musicSource.volume = volumeSlider.value;
        // Save the volume for future sessions
        PlayerPrefs.SetFloat("MusicVolume", volumeSlider.value);
    }
}
