using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;
using Text = UnityEngine.UI.Text;

public class TileChange : MonoBehaviour
{
    public Button button;
    public Sprite xTile;
    public Sprite oTile;
    public int buttonIndex;
    public GameObject text;

    // Game state 0 = X, 1 = O
    public static int stateValue = 0;
    public static int[,] boardState = new int[3, 3];

    // All buttons
    public GameObject[,] buttons = new GameObject[3, 3];

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChangeValue);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                boardState[i, j] = -1;
            }
        }
    }

    public void ChangeValue()
    {
        if (button.GetComponent<Button>().interactable == true)
        {
            if (stateValue == 0)
            {
                button.image.sprite = xTile;
                stateValue = 1;
                button.interactable = false;
                boardState[buttonIndex / 3, buttonIndex % 3] = 0;
            }
            else if (stateValue == 1)
            {
                button.image.sprite = oTile;
                stateValue = 0;
                button.interactable = false;
                boardState[buttonIndex / 3, buttonIndex % 3] = 1;
            }
            CheckForWin();
        }
    }
    public void CheckForWin()
    {
        // check rows
        for (int i = 0; i < 3; i++)
        {
            if (boardState[i, 0] != -1 && boardState[i, 0] == boardState[i, 1] && boardState[i, 1] == boardState[i, 2])
            {
                EndGame(boardState[i, 0]);
                return;
            }
        }
        // check columns
        for (int i = 0; i < 3; i++)
        {
            if (boardState[0, i] != -1 && boardState[0, i] == boardState[1, i] && boardState[1, i] == boardState[2, i])
            {
                EndGame(boardState[0, i]);
                return;
            }
        }
        // check diagonals
        if (boardState[0, 0] != -1 && boardState[0, 0] == boardState[1, 1] && boardState[1, 1] == boardState[2, 2])
        {
            EndGame(boardState[0, 0]);
            return;
        }
        if (boardState[0, 2] != -1 && boardState[0, 2] == boardState[1, 1] && boardState[1, 1] == boardState[2, 0])
        {
            EndGame(boardState[0, 2]);
            return;
        }
        // check for draw
        bool isDraw = true;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (
                    boardState[i, j] == -1)
                {
                    isDraw = false;
                    break;
                }
            }
        }
        if (isDraw)
        {
            EndGame(-1);
        }
    }
    public void EndGame(int winner)
    {
        if (winner == 0)
        {
            UnityEngine.Debug.Log("X wins!");
            
        }
        else if (winner == 1)
        {
            UnityEngine.Debug.Log("O wins!");
        }
        else
        {
            UnityEngine.Debug.Log("It's a draw!");
        }
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                buttons[i, j].GetComponent<Button>().interactable = false;
            }
        }
    }
}
    
