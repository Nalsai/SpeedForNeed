using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject Car1Pre;
    public GameObject Car2Pre;
    public GameObject Car3Pre;
    public GameObject ComPre;

    GameObject Music;
    GameObject Player1;
    GameObject Player2;
    GameObject Player3;

    Vector3 Position;
    Quaternion Rotation;

    public static bool Player1CheckpointsPassed;
    public static bool Player2CheckpointsPassed;
    public static bool Player3CheckpointsPassed;

    string SceneName;

    private void Start()
    {
        SceneName = SceneManager.GetActiveScene().name;

        if (SceneName == "GreenLight")
        {
            Position = new Vector3(4.5f, 0f, -1f);
        }
        else if (SceneName == "HappinessDistance")
        {
            Position = new Vector3(-5.5f, -1.75f, -1f);
        }
        Rotation = Quaternion.Euler(0, 0, 0);

        SetKeybindings(Car1Pre, KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D);
        SetKeybindings(Car2Pre, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow);
        SetKeybindings(Car3Pre, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L);

        switch (MenuController.Players)
        {
            case 1:
                Position.x += 0.2f;
                Player1 = Instantiate(Car1Pre, Position, Rotation);
                Position.x -= 0.4f;
                Instantiate(ComPre, Position, Rotation);
                break;
            case 2:
                Position.x += 0.2f;
                Player1 = Instantiate(Car1Pre, Position, Rotation);
                Position.x -= 0.4f;
                Player2 = Instantiate(Car2Pre, Position, Rotation);
                break;
            case 3:
                Position.x += 0.3f;
                Player1 = Instantiate(Car1Pre, Position, Rotation);
                Position.x -= 0.3f;
                Player2 = Instantiate(Car2Pre, Position, Rotation);
                Position.x -= 0.3f;
                Player3 = Instantiate(Car3Pre, Position, Rotation);
                break;
        }

        Music = GameObject.FindWithTag("Music");

        Music.GetComponent<AudioSource>().mute = MenuController.MuteMusic;

        if (Player1)
        {
            Player1.GetComponent<AudioSource>().mute = MenuController.MuteSFX;
        }
        if (Player2)
        {
            Player2.GetComponent<AudioSource>().mute = MenuController.MuteSFX;
        }
        if (Player3)
        {
            Player3.GetComponent<AudioSource>().mute = MenuController.MuteSFX;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player1":
                Player1CheckpointsPassed = true;
                break;
            case "Player2":
                Player2CheckpointsPassed = true;
                break;
            case "Player3":
                Player3CheckpointsPassed = true;
                break;
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

    private void SetKeybindings(GameObject g, KeyCode up, KeyCode left, KeyCode down, KeyCode right)
    {
        Movement m = g.GetComponent<Movement>();
        m.KeyCodeUp = up;
        m.KeyCodeLeft = left;
        m.KeyCodeDown = down;
        m.KeyCodeRight = right;
    }
}