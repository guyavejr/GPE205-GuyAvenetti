using UnityEngine;

public class ReturnToTitleScreenFromCredits : MonoBehaviour
{
    public void ToTitleScreenButton()
    {
        GameManager.instance.ExitToMainMenuFromWorld1();
    }
}
