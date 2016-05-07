using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeChange : MonoBehaviour {

    public Slider VolumeSlider;
    
    private AudioSource source;

    public void ChangeVolume()
    {
        source.volume = VolumeSlider.value;
    }
}
