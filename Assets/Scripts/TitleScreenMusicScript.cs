using UnityEngine;
using UnityEngine.Audio;

public class TitleScreenMusicScript : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioClip pureFuries;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioMixerSnapshot cutsceneShot;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        Debug.Log("ooh im playing music!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
