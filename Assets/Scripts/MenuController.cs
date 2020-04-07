using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static bool MuteMusic;
    public static bool MuteSFX;
    public static int Players;
    public Toggle MusicToggle;
    public Toggle GreenLightToggle;
    public Toggle HappinessDistanceToggle;
    string Track = "GreenLight";
    bool GL = true;
    bool HD = false;

    private void Start()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            MuteMusic = true;
        }
        MusicToggle.isOn = !MuteMusic;
    }

    public void ToggleMusic()
    {
        MuteMusic = !MuteMusic;
        GameObject.FindWithTag("Music").GetComponent<AudioSource>().mute = MuteMusic;
    }

    public void ToggleSFX()
    {
        MuteSFX = !MuteSFX;
    }

    public void ToggleGreenLight()
    {
        if (GL)
        {
            HappinessDistanceToggle.isOn = true;
            GL = false;
        }
        else
        {
            HappinessDistanceToggle.isOn = false;
            GL = true;
        }

        if (GreenLightToggle.isOn == true)
        {
            Track = "GreenLight";
        }
        else if (HappinessDistanceToggle.isOn == true)
        {
            Track = "HappinessDistance";
        }
    }
    public void ToggleHappinessDistance()
    {
        if (HD)
        {
            GreenLightToggle.isOn = true;
            HD = false;
        }
        else
        {
            GreenLightToggle.isOn = false;
            HD = true;
        }

        if (GreenLightToggle.isOn == true)
        {
            Track = "GreenLight";
        }
        else if (HappinessDistanceToggle.isOn == true)
        {
            Track = "HappinessDistance";
        }
    }

    public void Start1P()
    {
        Players = 1;
        SceneManager.LoadScene(Track);
    }
    public void Start2P()
    {
        Players = 2;
        SceneManager.LoadScene(Track);
    }
    public void Start3P()
    {
        Players = 3;
        SceneManager.LoadScene(Track);
    }
}