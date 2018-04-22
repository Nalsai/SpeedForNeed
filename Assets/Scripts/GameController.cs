using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject Music;

    public GameObject RedCarPre;
    public GameObject BlueCarPre;
    public GameObject GreenCarPre;
    public GameObject ComPre;
    GameObject RedCar;
    GameObject BlueCar;
    GameObject GreenCar;

    public static bool RedCheat = true;
    public static bool BlueCheat = true;
    public static bool GreenCheat = true;

    public static float power = 7;
    public static float maxspeed = 10;
    public static float turnpower = 3;
    public static float friction = 3;

    string SceneName;

    private void Start()
    {
        SceneName = SceneManager.GetActiveScene().name;

        if (MenuController.Player == 1)
        {
            Instantiate(RedCarPre);
            Instantiate(ComPre);
        }
        if (MenuController.Player == 2)
        {
            Instantiate(RedCarPre);
            Instantiate(BlueCarPre);
        }
        if (MenuController.Player == 3)
        {
            Instantiate(RedCarPre);
            Instantiate(BlueCarPre);
            Instantiate(GreenCarPre);
        }

        RedCar = GameObject.FindWithTag("Rot");
        BlueCar = GameObject.FindWithTag("Blau");
        GreenCar = GameObject.FindWithTag("Gruen");

        if (MenuController.Music == false)
            Music.GetComponent<AudioSource>().mute = true;
        else
            Music.GetComponent<AudioSource>().mute = false;
        if (MenuController.SFX == false)
        {
            RedCar.GetComponent<AudioSource>().mute = true;
            BlueCar.GetComponent<AudioSource>().mute = true;
            GreenCar.GetComponent<AudioSource>().mute = true;
        }
        else
        {
            RedCar.GetComponent<AudioSource>().mute = false;
            BlueCar.GetComponent<AudioSource>().mute = false;
            GreenCar.GetComponent<AudioSource>().mute = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Rot")
        {
            RedCheat = false;
        }
        if (collision.tag == "Blau")
        {
            BlueCheat = false;
        }
        if (collision.tag == "Gruen")
        {
            GreenCheat = false;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void GotoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}