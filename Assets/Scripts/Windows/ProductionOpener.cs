using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class ProductionOpener : WindowOpener
{
    public ProductionWindow window;

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
