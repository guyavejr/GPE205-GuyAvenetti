using UnityEngine;

public class ReturnToTitleScreenFromCredits : MonoBehaviour
{
    public void ToTitleScreenButton()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.gameStateMachine.TitleScreen(gameObject);
        }
    }
}
