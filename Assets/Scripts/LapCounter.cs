using UnityEngine;
using UnityEngine.UI;

public class LapCounter : MonoBehaviour
{
    int LapsPlayer1;
    int LapsPlayer2;
    int LapsPlayer3;
    bool won;
    public GameObject WinnerCanvas;
    public Text WinnerText;
    public Text LapText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player1":
                if (GameController.Player1CheckpointsPassed)
                {
                    LapsPlayer1++;
                    GameController.Player1CheckpointsPassed = false;
                }
                break;
            case "Player2":
                if (GameController.Player2CheckpointsPassed)
                {
                    LapsPlayer2++;
                    GameController.Player2CheckpointsPassed = false;
                }
                break;
            case "Player3":
                if (GameController.Player3CheckpointsPassed)
                {
                    LapsPlayer3++;
                    GameController.Player3CheckpointsPassed = false;
                }
                break;
        }

        LapText.text =
            "1: Lap " + LapsPlayer1 + "/3\n" +
            "2: Lap " + LapsPlayer2 + "/3\n" +
            "3: Lap " + LapsPlayer3 + "/3\n";

        if (!won)
        {
            if (LapsPlayer1 == 3)
            {
                WinnerCanvas.SetActive(true);
                WinnerText.text = "Player 1 won the race!";
                won = true;
            }

            else if (LapsPlayer2 == 3)
            {
                WinnerCanvas.SetActive(true);
                WinnerText.text = "Player 2 won the race!";
                won = true;
            }

            else if (LapsPlayer3 == 3)
            {
                WinnerCanvas.SetActive(true);
                WinnerText.text = "Player 3 won the race!";
                won = true;
            }
        }
    }
}