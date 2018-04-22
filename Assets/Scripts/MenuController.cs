using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static bool Music = true;
    public static bool SFX = true;
    bool GL;
    bool HD;
    public static int Player = 3;
    string Strecke = "GreenLight";

    public void MusicToggle()
    {
        if (Music)
            Music = false;
        else
            Music = true;
    }

    public void SFXToggle()
    {
        if (SFX)
            SFX = false;
        else
            SFX = true;
    }

    public void GLToggle()
    {
        if (SFX)
            SFX = false;
        else
            SFX = true;
    }

    public void HDToggle()
    {
        if (HD)
            SFX = false;
        else
            SFX = true;
    }

    public void Start1P()
    {
        Player = 1;
        SceneManager.LoadScene(Strecke);
    }
    public void Start2P()
    {
        Player = 2;
        SceneManager.LoadScene(Strecke);
    }
    public void Start3P()
    {
        Player = 3;
        SceneManager.LoadScene(Strecke);
    }
}