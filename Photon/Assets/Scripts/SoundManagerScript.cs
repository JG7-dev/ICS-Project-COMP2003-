using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip StepSound, SniperSound;
    static AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        StepSound = Resources.Load<AudioClip>("Steps");
        SniperSound = Resources.Load<AudioClip>("SniperShot");

        audiosrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Steps":
                audiosrc.PlayOneShot(StepSound);
                break;
            case "SniperShot":
                audiosrc.PlayOneShot(SniperSound);
                break;
        }
    }
}
