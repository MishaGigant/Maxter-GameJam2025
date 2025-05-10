using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public TextMeshPro text;

    public void ChangeAnimationState()
    {
        anim.SetTrigger("Appear");
    }
    public void ChangeText(string _text)
    {
        text.text = _text;
    }
}
