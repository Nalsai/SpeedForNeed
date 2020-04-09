using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static bool MuteMusic;
    public static bool MuteSFX;
    public static int Players;
    public Toggle SFXToggle;
    public Toggle MusicToggle;
    public Toggle GreenLightToggle;
    public Toggle HappinessDistanceToggle;

    private void Start()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            MuteMusic = true;
        }
        MusicToggle.isOn = !MuteMusic;
        SFXToggle.isOn = !MuteSFX;
    }

    public void ToggleMusic()
    {
        MuteMusic = !MusicToggle.isOn;
        GameObject.FindWithTag("Music").GetComponent<AudioSource>().mute = MuteMusic;
    }

    public void ToggleSFX()
    {
        MuteSFX = !SFXToggle.isOn;
    }

    public void GameStart(int players)
    {
        string track = "";
        if (GreenLightToggle.isOn)
        {
            track = "GreenLight";
        }
        else if (HappinessDistanceToggle.isOn)
        {
            track = "HappinessDistance";
        }
        Players = players;
        SceneManager.LoadScene(track);
    }
}