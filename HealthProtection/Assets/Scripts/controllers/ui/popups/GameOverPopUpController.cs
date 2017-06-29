using UnityEngine;
using UnityEngine.UI;
public class GameOverPopUpController : PopUpController
{
    [SerializeField]
    private Text _message;

    public void Start()
    {
        if (_message == null)
        {
            LoggingManager.AddErrorToLog("_message doesnt exist");
        }
    }

    public override PopUpNameEnum popupName
    {
        get
        {
            return PopUpNameEnum.gameOver;
        }
    }

    public override void Activate()
    {
        base.Activate();
        _message.text = "GAME OVER FOR YOU Bro";
    }
    /*Buttons clicked 
     * */
    public void GoToMenuButtonClicked()
    {
        UIModel.Instance.ShowMainMenu();
    }

    public void RestartButtonClicked()
    {
        GameController.Instance.ResetRound();
    }
}
