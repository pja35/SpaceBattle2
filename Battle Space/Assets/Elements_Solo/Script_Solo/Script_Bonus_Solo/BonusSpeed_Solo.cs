﻿/* BonusSpeed_Solo.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Resprensent a speed bonus that increase spaceship's velocity.
/// </summary>
public class BonusSpeed_Solo : MonoBehaviour
{
    // BONUS OPTION //
    public float duration;
    public float multiplier;

    /// <summary>
    /// Occurs when there is a collision between the bonus and a spaceship.
    /// The spaceship gets the bonus effect.
    /// </summary>
    /// <param name="other">A game object with a 2d collider.</param>
    /// <seealso cref="Coroutine"/>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Spaceship_solo spaceship = other.GetComponent<Spaceship_solo>();
            if (!spaceship.hasSpeedBonus)
            {
                StartCoroutine(Pickup(spaceship));
            }
        }
    }

    /// <summary>
    /// Occurs when <param name="other"/> is inside the bonus's detection radius.
    /// The spaceship gets the bonus effect.
    /// </summary>
    /// <param name="other">A game object with a 2d collider.</param>
    /// <seealso cref="Coroutine"/>
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Spaceship_solo spaceship = other.GetComponent<Spaceship_solo>();
            if (!spaceship.hasSpeedBonus)
            {
                StartCoroutine(Pickup(spaceship));
            }
        }
    }

    /// <summary>
    /// Apply bonus effect on <param name="spaceship"/>.
    /// </summary>
    /// <param name="spaceship">The lucky owner of the bonus.</param>
    /// <returns>
    /// A temporary suspension of the StartCoroutine method 
    /// implying the duration of the bonus.
    /// </returns>
    /// <seealso cref="YieldInstruction"/>
    /// <seealso cref="Coroutine"/>
    IEnumerator Pickup(Spaceship_solo spaceship)
    {
        // START EFFECT //
        spaceship.hasSpeedBonus = true;
        spaceship.speed *= multiplier;

        // DISABLE BONUS ENTITY //
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

        // WAIT DURATION //
        yield return new WaitForSeconds(duration);

        // END EFFECT //
        spaceship.hasSpeedBonus = false;
        spaceship.speed /= multiplier;

        Destroy(gameObject);
    }
}