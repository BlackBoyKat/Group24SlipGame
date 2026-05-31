using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float knockbackTime = 0.2f;
    public float hitDirectionForce = 10f;
    public float constForce = 5f;
    public float inputForce = 7.5f;

    private Rigidbody2D rb;

    private Coroutine knockbackCouroutine;

    public bool IsBeingKnockedBack { get; private set; }

    public IEnumerator KnockbackAction(Vector2 hitDirection, Vector2 constantForceDirection, float inputDirection)
    {
        IsBeingKnockedBack = true;
        Vector2 _hitForce;
        Vector2 _constantForce;
        Vector2 _knockbackForce;
        Vector2 _combinedForce;

        _hitForce = hitDirection * hitDirectionForce;
        _constantForce = constantForceDirection * constForce;

        float _elapsedTime = 0f;
        while (_elapsedTime < knockbackTime)
        {// iterate the timer

            _elapsedTime += Time.fixedDeltaTime;
            //combine hitforce and constantForce
            _knockbackForce = _hitForce + _constantForce;

            if (inputDirection != 0)
            {
                _combinedForce = _knockbackForce + new Vector2(inputDirection * inputForce, 0f);
            }
            else
            {
                _combinedForce = _knockbackForce;
            }
            //apply knockback to rigidbody

            rb.linearVelocity = _combinedForce;
            yield return new WaitForFixedUpdate();
        }
        IsBeingKnockedBack = false;

    }

    public void CallKnockback(Vector2 hitDirection, Vector2 constantForceDirection, float inputDirection)

    {
        knockbackCouroutine = StartCoroutine(KnockbackAction(hitDirection, constantForceDirection, inputDirection));
    }
}


//Sasquatch B Studio,Lets Makethe Best Knockback Function with Combined Forces 
