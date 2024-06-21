using UnityEngine;
using UnityEngine.EventSystems;

public class movementcamera : MonoBehaviour
{
    // Jarak antara kamera dan target
    public float distance = 10f;

    // Kecepatan rotasi kamera
    public float speed = 5f;

    public float maxYAngle = 120;

    // Kecepatan zoom kamera
    public float zoomSpeed = 2f;

    // Batas maksimum dan minimum untuk zoom
    public float minDistance = 5f;
    public float maxDistance = 15f;

    // Target yang akan diikuti oleh kamera
    public Transform target;

    // Sudut rotasi kamera
    private float angleX = 0f;
    private float angleY = 0f;

    // Inisialisasi awal
    void Start()
    {
        // Mengatur sudut rotasi kamera sesuai dengan posisi awal
        angleX = transform.eulerAngles.y;
        angleY = transform.eulerAngles.x;
    }

    // Update setiap frame
    void Update()
    {

        if (EventSystem.current.IsPointerOverGameObject())
        {
            // If pointer is over UI, do nothing (return)
            return;
        }
        // Jika user menekan tombol mouse kiri
        if (Input.GetMouseButton(0))
        {
            // Mendapatkan pergerakan mouse pada sumbu X dan Y
            float mouseX = Input.GetAxis("Mouse X") * speed;
            float mouseY = Input.GetAxis("Mouse Y") * speed;

            // Mengubah sudut rotasi kamera sesuai dengan pergerakan mouse dan kecepatan
            angleX += mouseX;
            angleY -= mouseY;

            // Jepit angleY ​​agar berada dalam rentang -maxYAngle hingga maxYAngle
            angleY = Mathf.Clamp(angleY, 5f, 180f);
        }

        // Zoom in atau zoom out berdasarkan input scroll mouse
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // Menghitung rotasi kamera berdasarkan sudut yang telah diubah
        Quaternion rotation = Quaternion.Euler(angleY, angleX, 0f);

        // Menghitung posisi kamera berdasarkan rotasi dan jarak dari target
        Vector3 position = rotation * new Vector3(0f, 0f, -distance) + target.position;

        // Mengatur posisi dan rotasi kamera
        transform.position = position;
        transform.rotation = rotation;

        Debug.Log("Camera Rotation X: " + angleX + ", Y: " + angleY);
    }
}
