using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public Transform holdPosition;  // Position, an der das aufgenommene Objekt gehalten wird
    public GameObject boxPrefab;    // Die Prefab-Box, die erstellt werden soll
    private GameObject heldObject;  // Das aktuell gehaltene Objekt
    private Vector3 boxOriginalPosition;  // Ursprüngliche Position der Box
    public float pickupRadius = 2f; // Radius, in dem das Objekt aufgenommen werden kann


    void Update()
    {
        // Wenn die "E"-Taste gedrückt wird, versuche ein Objekt aufzuheben oder abzulegen
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                // Wenn kein Objekt gehalten wird, versuche ein Objekt aufzuheben
                TryPickUpObject();
            }
            else
            {
                // Wenn ein Objekt gehalten wird, lege es ab
                DropObject();
            }
        }

        // Wenn ein Objekt gehalten wird, folge der Position des Spielers
        if (heldObject != null)
        {
            heldObject.transform.position = holdPosition.position;
        }
    }

    // Funktion zum Aufheben eines Objekts
    void TryPickUpObject()
    {
        // Überprüfe, ob ein "Box"-Objekt in Reichweite ist
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, pickupRadius);

        foreach (var hit in hits)
        {
            if (hit.CompareTag("Box")) // Stelle sicher, dass es das richtige Tag hat
            {
                heldObject = hit.gameObject; // Speichere das aufgenommene Objekt
                boxOriginalPosition = heldObject.transform.position;  // Merke die ursprüngliche Position der Box
                heldObject.transform.SetParent(holdPosition); // Setze das Objekt als Kind des Spielers
                heldObject.GetComponent<Rigidbody2D>().isKinematic = true; // Deaktiviere die Physik für das Objekt
                break; // Breche ab, wenn das erste passende Objekt gefunden wurde
            }
        }
    }

    // Funktion zum Ablegen des Objekts
    void DropObject()
    {
        heldObject.transform.SetParent(null); // Entferne das Objekt von der Position des Spielers
        heldObject.GetComponent<Rigidbody2D>().isKinematic = false; // Reaktiviere die Physik

        // Erstelle eine neue Box an der ursprünglichen Position
        CreateNewBoxAtOriginalPosition();

        heldObject = null; // Setze das gehaltene Objekt auf null
    }

    // Funktion, um eine neue Box an der ursprünglichen Position zu erstellen
    void CreateNewBoxAtOriginalPosition()
    {
        if (boxPrefab != null)
        {
            boxPrefab = Instantiate(boxPrefab, boxOriginalPosition, Quaternion.identity); // Neue Box erzeugen 
        }
    }

    // Zeichnet den Radius, in dem Objekte aufgehoben werden können
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }
}