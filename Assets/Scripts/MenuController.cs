using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static bool Music = true;
    public static bool SFX = true;
    public static int Player = 3;
    public GameObject MusicToggleObj;
    public GameObject GLToggleObj;
    public GameObject HDToggleObj;
    GameObject MusicObj;
    string Strecke = "GreenLight";
    bool GL = true;
    bool HD = false;


    private void Start()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            MusicToggleObj.GetComponent<Toggle>().isOn = false;
            Music = false;
        }
        MusicObj = GameObject.FindWithTag("Music");
    }

    private void FixedUpdate()
    {
        if (Music == false)
            MusicObj.GetComponent<AudioSource>().mute = true;
        else
            MusicObj.GetComponent<AudioSource>().mute = false;
    }

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
        if (GL)
        {
            HDToggleObj.GetComponent<Toggle>().isOn = true;
            GL = false;
        }
        else
        {
            HDToggleObj.GetComponent<Toggle>().isOn = false;
            GL = true;
        }

        if (GLToggleObj.GetComponent<Toggle>().isOn == true)
        {
            Strecke = "GreenLight";
        }
        else if (HDToggleObj.GetComponent<Toggle>().isOn == true)
        {
            Strecke = "HappinessDistance";
        }
    }

    public void HDToggle()
    {
        if (HD)
        {
            GLToggleObj.GetComponent<Toggle>().isOn = true;
            HD = false;
        }
        else
        {
            GLToggleObj.GetComponent<Toggle>().isOn = false;
            HD = true;
        }

        if (GLToggleObj.GetComponent<Toggle>().isOn == true)
        {
            Strecke = "GreenLight";
        }
        else if (HDToggleObj.GetComponent<Toggle>().isOn == true)
        {
            Strecke = "HappinessDistance";
        }
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
        if (GLToggleObj.GetComponent<Toggle>().isOn == true)
            Strecke = "GreenLight";
        else if (HDToggleObj.GetComponent<Toggle>().isOn == true)
            Strecke = "HappinessDistance";
        SceneManager.LoadScene(Strecke);
    }
}