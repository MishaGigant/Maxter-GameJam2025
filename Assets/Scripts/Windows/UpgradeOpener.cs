using UnityEngine;


public class UpgradeOpener : WindowOpener
{
    public UpgradeWindow window;

    public override void Open()
    {
        WindowController.onWindowOpen?.Invoke();
        isOpen = true;
        window.gameObject.SetActive(true);
    }
    public override void Close()
    {
        if (isOpen)
        {
            isOpen = false;
            window.gameObject.SetActive(false);
        }

    }
}
