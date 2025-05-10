using UnityEngine;

public class ButtonsProduction : MonoBehaviour
{
    public ProductionWindow window;
    public bool isLeft;
    public bool isRight;

    public void OnMouseDown()
    {
        if (isLeft)
        {
            window.PrevSkin();
        }
        else if (isRight)
        {
            window.NextItem();
        }
        else
        {
            window.BuyItem();
        }
    }
}
