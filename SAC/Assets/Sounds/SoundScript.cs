using UnityEngine.Audio;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public Sound[] sounds;
    void Awake()
    {
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
        
        //play bg
        Play("Seewave");


    }


    public void Play(string name)
    {
        for (int i = 0; i < sounds.Length; i++) {
            if (sounds[i].name == name)
            {
                sounds[i].source.Play();
            
            }
        }
    }



}

//make a Sound class
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume=0.5f;
    [Range(0.1f, 3f)]
    public float pitch=1f;
    public bool loop;
    [HideInInspector]
    public AudioSource source;
}
