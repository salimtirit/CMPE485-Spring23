using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    [SerializeField] RawImage soundOff;
    [SerializeField] RawImage soundOn;

    private bool muted = false;

    private void UpdateButtonIcon(){
        if(muted){
            soundOff.enabled = true;
            soundOn.enabled = false;
        } else {
            soundOff.enabled = false;
            soundOn.enabled = true;
        }
    }

    public void ToggleSound() {
        if (muted) {
            muted = false;
            AudioListener.pause = false;
        } else {
            muted = true;
            AudioListener.pause = true;
        }

        Save();
        UpdateButtonIcon();
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted", 0) == 1;
        soundOff.enabled = muted;
        soundOn.enabled = !muted;
        AudioListener.pause = muted;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }


    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

}
