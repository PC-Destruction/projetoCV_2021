using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audio_Source;

    public static AudioController instance;

    private void Start()
    {
        if (instance != null) {
            Destroy(this.gameObject);
        }
        instance = this;
    }

    public void PlaySound() {
        audio_Source.Play();
    }
}
