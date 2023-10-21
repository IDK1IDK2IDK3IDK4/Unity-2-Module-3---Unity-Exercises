using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDelay : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource aud;
    void Start()
    {
        aud = GetComponent<AudioSource>();
        print("hihi");
        StartCoroutine(DoSound());
    }
    IEnumerator DoSound() 
    {
        print("hoho");
        yield return new WaitForSeconds(2.0f);
        print("yaya");
        aud.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
