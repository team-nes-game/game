// +----------------------------------------------------------+
// |                     SOUND CREDITS                        |
// +----------------------------------------------------------+
// | Frozen Cave Scene - No More Magic:                       |
// |        Created by HorrorPen of opengameart.org           |
// |        https://opengameart.org/content/no-more-magic     |
// +----------------------------------------------------------+
// | Frozen Mountain Scene - Magical Theme:                   |
// |        Created by remaxim of opengameart.org             |
// |        https://opengameart.org/content/magical-theme     |
// +----------------------------------------------------------+
// | Forest Scene - Soliloquy                                 |
// |        Created by Matthew Pablo of opengameart.org       |
// |        https://opengameart.org/content/soliloquy         |
// +----------------------------------------------------------+
// | Desert Scene - Arabesque                                 |
// |        Created by brainiac256 of opengameart.org         |
// |        https://opengameart.org/content/arabesque         |
// +----------------------------------------------------------+
// | Temple Scene - Radakan - Old Crypt                       |
// |        Created by Janne Hanhisuanto for Radakan on       |
// |        opengameart.org                                   |
// |        https://opengameart.org/content/radakan-old-crypt |
// +----------------------------------------------------------+
// | Main Menu - Prologue                                     |
// |        Created by Telaron of opengameart.org             |
// |        https://opengameart.org/content/prologue          |
// +----------------------------------------------------------+
// | All Attack Sounds - Player, Abominable, Sand Raider      |
// |        Created by artisticdude of opengameart.org        |
// |        https://opengameart.org/content/rpg-sound-pack    |
// +----------------------------------------------------------+

using UnityEngine.Audio;
using UnityEngine;
using System;


// The controller was created using the following tutorial by Brackeys:
//      https://www.youtube.com/watch?v=6OT43pvUyfY
public class AudioController : MonoBehaviour {
	// +--------+
    // | Public |
	// +--------+
    public Sound[] SOUNDS;

    // Awake is called before start is when starting up the GameObject
    void Awake() {
        // Set up every sound with its own audio clip and personal settings
        // (does it loop? what's the volume? etc.)
    	foreach (Sound sound in SOUNDS) {
    		sound.source        = gameObject.AddComponent<AudioSource>();
    		sound.source.clip   = sound.AUDIO_CLIP;
    		sound.source.volume = sound.VOLUME;
    		sound.source.pitch  = sound.PITCH;
    		sound.source.loop   = sound.LOOP;
    	}
    }

    void Start() {
        // When starting up the script, play the theme for the area. This
        // even includes the main menu as it is only played once
    	Play("THEME");
    }

    public void Play(string name) {
        // Check through the sound array using some nice
        // C# syntax that's found in the System library
    	Sound s = Array.Find(SOUNDS, sound => sound.NAME == name);
    	if (s == null) {
    		Debug.LogWarning("Sound: " + name + " not found!");
    		return;
    	}
        // Play a sound 
    	s.source.Play();
    }
}
