using UnityEngine.Audio; //use this whenever you are working with sound
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/* AudioManager keeps track of most sounds in the game. Sounds are input in the array in the inspector.
 * A sound can be called from any script using:
 * 
 * StartCoroutine(FindObjectOfType<AudioManager>().Play("Sound", time delay));
 * 
 * There is an optional argument when calling ArrayAudio to play the sound after a delay
 * 
 */

public class AudioManager : MonoBehaviour {

    /*An array of type Sound, which is a custom class containing all relevant 
     *information for each audio clip in the game. AudioClips are added
     through the inspector.*/
    public Sound[] sounds; 


	void Awake () {  //by using Awake all AudioSources can be initialized before Start is called
        foreach (Sound s in sounds){ //index through each AudioClip in the list and add a AudioSource for each
            //creates a reference between the sound and its corresponding AudioSource
            s.source = gameObject.AddComponent<AudioSource>();
            //set the clip of the AudioSource to the clip already stored in sound
            s.source.clip = s.clip;
            //sets up volume and pitch of correspinding AudioSource
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;
        }
	}

    private void Start()
    {
        StartCoroutine(Play("Creepy_Startup_Music"));
        StartCoroutine(Play("Creepy_Background_Music", 6.556f));  //plays after startup music
    }

    //searches for passed in clipname in sounds array and plays it
    public IEnumerator Play(string clipname, float delayTime = 0){
        yield return new WaitForSeconds(delayTime);

        //Syntax: Array.Find(arrayname, object => object.attribute == attributeToCompareTo)
        Sound s = Array.Find(sounds, sound => sound.clipname == clipname);
        if (s == null)
        {
            Debug.LogWarning("Sound " + clipname + " not found");
            yield break;
        }
        s.source.Play();
    }

    //searches for passed in clipname and stops it (used for loop sounds)
    public void Stop(string clipname)
    {

        //Syntax: Array.Find(arrayname, object => object.attribute == attributeToCompareTo)
        Sound s = Array.Find(sounds, sound => sound.clipname == clipname);
        if (s == null)
        {
            Debug.LogWarning("Sound " + clipname + " not found");
            return;
        }
        s.source.Stop();
    }
}
