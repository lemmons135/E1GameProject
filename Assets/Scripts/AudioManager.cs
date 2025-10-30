using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioClip pureFuries;
    [SerializeField] AudioSource defaultSource;
    [SerializeField] AudioMixerSnapshot cutsceneShot;
    private void Start()
    {
        cutsceneShot.TransitionTo(5f);
    }

    public void PlayJump()
    {
        defaultSource.PlayOneShot(pureFuries);
    }
    public void ChangeVolume(float volume)
    {
        Debug.Log(volume);
        mixer.SetFloat("Master Volume", 0.01f*volume);
    }
}
