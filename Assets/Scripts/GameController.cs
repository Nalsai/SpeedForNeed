using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject Music;

    public static bool RedCheat = true;
    public static bool BlueCheat = true;
    public static bool GreenCheat = true;

    public static float power = 7;
    public static float maxspeed = 10;
    public static float turnpower = 3;
    public static float friction = 3;

    private void Start()
    {
        if (MenuController.Music == false)
        {

        }
        if (MenuController.SFX == false)
        {

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
        SceneManager.LoadScene("scene1");
    }
}