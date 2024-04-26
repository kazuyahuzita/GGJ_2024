using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bakudan : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip SE_Burst;
    bool isAudio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        isAudio = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -2.8f)
        {
            if (!isAudio)
            {
                audio.PlayOneShot(SE_Burst);
                isAudio = true;
            }
        }
    }
}
