using System;
using UnityEngine;
public class PopUpPullData
{
    private GameOverPopUpVO _gameOverData;
    public GameOverPopUpVO gameOverData
    {
        set
        {
            _gameOverData = value;
        }
        get
        {
            return _gameOverData;
        }
    }

    private WinningPopUpVO _winningData;
    public WinningPopUpVO winningData {
        set
        {
            _winningData = value;
        }
        get
        {
            return _winningData;
        }
    }
}
