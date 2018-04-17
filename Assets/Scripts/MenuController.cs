using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static bool Music = false;
    public static bool SFX = true;

    void Start()
    {

    }

    void Update()
    {

    }
    public void Start3P()
    {
        SceneManager.LoadScene("scene1");
    }
}