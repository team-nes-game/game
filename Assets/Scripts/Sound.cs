using UnityEngine.Audio;
using UnityEngine;

// Making it serializable will allow this to be seen in the inspector
// inside of Unity
[System.Serializable]
public class Sound {
	// +--------+
	// | Public |
	// +--------+
	public bool LOOP; // Does it loop?
	public string NAME; // What's the clip called?
	public AudioClip AUDIO_CLIP; // The audio itself

	// These ranges allow us to create a slider inside of the
	// Unity inspector that ranges between the listed values
	[Range(0f, 1f)]
	public float VOLUME;
	[Range(.1f, 3f)]
	public float PITCH;

	// Don't need this to be shown in the inspector so tag it as such
	[HideInInspector]
	public AudioSource source;
}
