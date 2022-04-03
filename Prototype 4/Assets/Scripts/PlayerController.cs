using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody playerRb;
    public float speed = 5.0f;
    private float powerupStrength = 15.0f;
    public bool hasPowerUp;
    public GameObject powerupIndicator;
    private GameObject focalPoint;
    // Start is called before the first frame update
    void Start () {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update () {
        float forwardInput = Input.GetAxis("Vertical");
        // playerRb.AddForce (Vector3.forward * speed * forwardInput);
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        powerupIndicator.transform.position = transform.position + new Vector3(0,-0.5f,0);

    }

    // understanding triggers between colliders
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }
    // with physics use oncollission enter
    private void OnCollisionEnter(Collision collission) {
        if (collission.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRb = collission.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collission.gameObject.transform.position - transform.position);
            Debug.Log("collided with " +collission.gameObject.name+" and powerup set to "+hasPowerUp);
            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine() {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}