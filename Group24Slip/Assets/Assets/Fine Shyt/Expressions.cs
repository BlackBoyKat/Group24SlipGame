using UnityEngine;
using UnityEngine.U2D.Animation;
public class Expressions : MonoBehaviour
{
    public SpriteResolver _spriteResolver;
    private void Awake()
    {
        _spriteResolver = GetComponent<SpriteResolver>();
        _spriteResolver.SetCategoryAndLabel("Expressions", "Happy");
    }
}