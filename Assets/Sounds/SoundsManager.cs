using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundsManager : MonoBehaviour
{


    [SerializeField] int _curMusic;




    [SerializeField] AudioSource _sourceForMusic;
    [SerializeField] AudioSource _sourceForSounds;
    [SerializeField] AudioSource _sourceForClicks;
    [SerializeField] AudioClip[] _musics;
    [SerializeField] AudioClip[] _sounds;
    [SerializeField] AudioClip[] _bubbles;
            
    [SerializeField] public Toggle _music;
    [SerializeField] public Toggle _sound;

    [SerializeField] public bool MusicToggle;
    [SerializeField] public bool SoundToggle;
    void Start()
    {
        _music.isOn = MusicToggle;
        _sound.isOn = SoundToggle;
    }
    public void ChangeToggleMusic()
    {
        _sourceForMusic.Stop();
        if (_music.isOn == true)
        {
            MusicToggle = true;
            PlaySong();
        }
        else
        {
            MusicToggle = false;
        }
    }
    public void PlaySoundClick()
    {
        if (SoundToggle)
        {
            _sourceForClicks.clip = _bubbles[Random.Range(0,_bubbles.Length)];
            _sourceForClicks.Play();
        }
    }
    public void ChangeToggleSound()
    {
        if (_sound.isOn == true)
        {
            SoundToggle = true;
        }
        else
        {
            SoundToggle = false;
        }
    }
    public void PlaySound(int index)
    {
        if (SoundToggle)
        {
            _sourceForSounds.clip = _sounds[index];
            _sourceForSounds.Play();
        }
    }
    public void PlaySong()
    {
        if (MusicToggle)
        {
            int NumberSong = -999;
            do
            {
                NumberSong = Random.Range(0, _musics.Length);
                _sourceForMusic.clip = _musics[NumberSong];
            }
            while (_curMusic == NumberSong);
            _curMusic = NumberSong;
            _sourceForMusic.Play();
        }
    }
    private void Update()
    {
        if (_sourceForMusic.isPlaying == false && MusicToggle )
        {
            PlaySong();
        }
    }
}
