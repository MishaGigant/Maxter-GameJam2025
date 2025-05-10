using UnityEditor.PackageManager;
using UnityEngine;
using System;

public class WindowOpener : MonoBehaviour
{
    public bool isOpen;
    public AudioManager src;
    public string openSound, closeSound, spriteName;
    public SpriteRenderer spriteRenderer;

    public void Start()
    {
        WindowController.onWindowOpen += Close;
    }
    public void OnMouseDown()
    {
        if (isOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    public virtual void Open()
    {
        WindowController.onWindowOpen?.Invoke();
        if (openSound != null)
        {
            src.Play(openSound);
        }
        if (spriteName != null)
        {
            spriteRenderer.sprite = Resources.LoadAll<Sprite>(spriteName)[1];
        }
        isOpen = true;
    }
    public virtual void Close()
    {
        if (isOpen)
        {
            if (closeSound != null)
            {
                src.Play(closeSound);
            }
            if (spriteName != null)
            {
                spriteRenderer.sprite = Resources.LoadAll<Sprite>(spriteName)[0];
            }
            isOpen = false;
        }
    }
}