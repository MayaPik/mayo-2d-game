using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Player")) {
            collision.gameObject.GetComponent<Player>().SetCanMove(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.gameObject.GetComponent<Player>().SetCanMove(true);
        }
    }
}
