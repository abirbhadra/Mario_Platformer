using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum Type
    {
        Mushroom,
        Starman

    }

    public Type powerup;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            switch (powerup)
            {
                case Type.Mushroom:
                    collision.gameObject.GetComponent<PlayerController>().MushroomPowerup();
                    break;
                case Type.Starman:

                    break;

            }

        }
    }
}
