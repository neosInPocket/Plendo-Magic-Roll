using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBorder : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public Vector2 Size
    {
        get => spriteRenderer.size;
        set => spriteRenderer.size = value;
    }
}
