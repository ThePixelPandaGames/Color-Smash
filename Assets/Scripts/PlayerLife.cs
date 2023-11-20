using System.Collections;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public Sprite playerLifeSprite;


    public GameObject[] playerLifePosition;

    [SerializeField] private int MAX_PLAYER_LIFE = 3;
    public int CurrentPlayerLife { set; get; }

    private Stack playerLifePositionStack;

    void Start()
    {
        playerLifePositionStack = new Stack(3);
        playerLifePositionStack.Push(playerLifePosition[0]);
        playerLifePositionStack.Push(playerLifePosition[1]);
        playerLifePositionStack.Push(playerLifePosition[2]);

        CurrentPlayerLife = MAX_PLAYER_LIFE;
    }

    public void AddPlayerLife()
    {
        if (CurrentPlayerLife < MAX_PLAYER_LIFE)
        {
            CurrentPlayerLife++;

            switch (CurrentPlayerLife)
            {
                case 1:
                    {
                        playerLifePositionStack.Push(playerLifePosition[0]);
                        playerLifePosition[0].GetComponent<SpriteRenderer>().sprite = playerLifeSprite;
                    }
                    break;
                case 2:
                    {
                        playerLifePositionStack.Push(playerLifePosition[1]);
                        playerLifePosition[1].GetComponent<SpriteRenderer>().sprite = playerLifeSprite;

                    }
                    break;
                case 3:
                    {
                        playerLifePositionStack.Push(playerLifePosition[2]);
                        playerLifePosition[2].GetComponent<SpriteRenderer>().sprite = playerLifeSprite;

                    }
                    break;

            }
        }
    }

    public void RemovePlayerLife()
    {
        if (CurrentPlayerLife > 0)
        {
            CurrentPlayerLife--;
            GameObject deletedPlayerLifePosition = (GameObject)playerLifePositionStack.Pop();
            deletedPlayerLifePosition.GetComponent<SpriteRenderer>().sprite = null;
        }
    }
}
