using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject RedCarPre;
    public GameObject BlueCarPre;
    public GameObject GreenCarPre;
    public GameObject ComPre;
    GameObject Music;
    GameObject RedCar;
    GameObject BlueCar;
    GameObject GreenCar;
    Vector3 Position;
    Quaternion Rotation;

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


        if (SceneName == "GreenLight")
            Position = new Vector3(4.5f, 0f, -1f);
        else if (SceneName == "HappinessDistance")
            Position = new Vector3(-5.5f, -1.75f, -1f);

        if (MenuController.Player == 1)
        {
            Position.x = Position.x + 0.2f;
            Instantiate(RedCarPre, Position, Rotation);
            Position.x = Position.x - 0.4f;
            Instantiate(ComPre, Position, Rotation);
        }
        if (MenuController.Player == 2)
        {
            Position.x = Position.x + 0.2f;
            Instantiate(RedCarPre, Position, Rotation);
            Position.x = Position.x - 0.4f;
            Instantiate(BlueCarPre, Position, Rotation);
        }
        if (MenuController.Player == 3)
        {
            Position.x = Position.x + 0.3f;
            Instantiate(RedCarPre, Position, Rotation);
            Position.x = Position.x - 0.3f;
            Instantiate(BlueCarPre, Position, Rotation);
            Position.x = Position.x - 0.3f;
            Instantiate(GreenCarPre, Position, Rotation);
        }

        RedCar = GameObject.FindWithTag("Rot");
        BlueCar = GameObject.FindWithTag("Blau");
        GreenCar = GameObject.FindWithTag("Gruen");

        Music = GameObject.FindWithTag("Music");

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