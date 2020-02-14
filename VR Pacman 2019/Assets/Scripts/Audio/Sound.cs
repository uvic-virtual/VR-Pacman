using UnityEngine.Audio;
using UnityEngine;

/* Contains all relevant information needed for any audioclip in the game.
   This custom class does not inherit MonoBehaviour and so in order for it to be shown in the 
   inspector [System.Serializable] is used*/

[System.Serializable]
public class Sound {

    public string clipname;

    public AudioClip clip;

    [Range(0f, 1f)] //used to create a slider in the inspector
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    [HideInInspector] //does not need to be shown in inspector
    public AudioSource source; //a variable so that other objects in the game can reference this sound

    public bool loop; //have the option in the inspector to loop the audio
}
