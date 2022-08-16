using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private AudioSource soundControl;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private GameObject SoundOn_panel;
    [SerializeField] private GameObject SoundOff_panel;
    [SerializeField] private GameObject MusicOn_panel;
    [SerializeField] private GameObject MusicOff_panel;
    [SerializeField] private GameObject Panel;
    [SerializeField] private Saver Saver;
    public bool m_sound;
    public bool m_music;

    public void CheckSave()
    {
        if (PlayerPrefs.HasKey("Sound"))
        { 
            if(PlayerPrefs.GetInt("Sound") == 1)
                m_sound = true;
            else
                m_sound = false;
        }
        else
            m_sound = true;
        if (PlayerPrefs.HasKey("Music"))
        {
            if (PlayerPrefs.GetInt("Music") == 1)
                m_music = true;
            else
                m_music = false;
        }
        else
            m_music = true;
        Initialise();
    }

    public void Initialise()
    {
        if(m_sound)
        {
            SoundOn_panel.SetActive(true);
            SoundOff_panel.SetActive(false);
            soundControl.mute = false;
        }
        else if(!m_sound)
        {
            SoundOn_panel.SetActive(false);
            SoundOff_panel.SetActive(true);
            soundControl.mute = true;
        }
        if(m_music)
        {
            MusicOn_panel.SetActive(true);
            MusicOff_panel.SetActive(false);
            backgroundMusic.mute = false;

        }
        else if (!m_music)
        {
            MusicOn_panel.SetActive(false);
            MusicOff_panel.SetActive(true);
            backgroundMusic.mute = true;
        }
    }
    
    public void DisplayPanel()
    {
        if (Panel.activeSelf)
            Panel.SetActive(false);
        else
        {
            Panel.SetActive(true);
            Initialise();
        }

    }
    public void SwitchSound()
    {
        if(SoundOn_panel.activeSelf)
        {
            m_sound = false;
            SoundOn_panel.SetActive(false);
            SoundOff_panel.SetActive(true);
            soundControl.mute = true;
            PlayerPrefs.SetInt("Sound", 0);
        }
        else
        {
            m_sound = true;
            SoundOn_panel.SetActive(true);
            SoundOff_panel.SetActive(false);
            soundControl.mute = false;
            PlayerPrefs.SetInt("Sound", 1);
        }
    }
    public void SwitchMusic()
    {
        if (MusicOn_panel.activeSelf)
        {
            m_music = false;
            MusicOn_panel.SetActive(false);
            MusicOff_panel.SetActive(true);
            backgroundMusic.mute = true;
            PlayerPrefs.SetInt("Music", 0);
        }
        else
        {
            m_music = true;
            MusicOn_panel.SetActive(true);
            MusicOff_panel.SetActive(false);
            backgroundMusic.mute = false;
            PlayerPrefs.SetInt("Music", 1);
        }
    }
    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        Saver.DeleteAllSaves();
    }
}
