using UnityEngine;
using TMPro;

public class MovementCamera : MonoBehaviour
{
    // Elemen TextMeshPro untuk menampilkan nilai rotasi
    private TextMeshProUGUI TextRotasi;
    // Jarak antara kamera dan target
    public float distance = 10f;

    // Batas maksimum sudut rotasi kamera pada sumbu Y
    public float maxYAngle = 90f;

    // Kecepatan rotasi kamera
    public float speed = 5f;

    // Target yang akan diikuti oleh kamera
    public Transform target;

    // Sudut rotasi kamera
    private float angleX;
    private float angleY;

    // Inisialisasi awal
    void Start()
    {
        // Mengatur sudut rotasi kamera sesuai dengan rotasi awal objek
        angleX = transform.eulerAngles.y;
        angleY = transform.eulerAngles.x;
    }

    // Update dipanggil setiap frame
    void Update()
    {
        // Jika pengguna menekan tombol mouse kiri
        if (Input.GetMouseButton(0))
        {
            // Mendapatkan pergerakan mouse pada sumbu X dan Y
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // Mengubah sudut rotasi kamera berdasarkan pergerakan mouse dan kecepatan
            angleX += mouseX * speed;
            angleY -= mouseY * speed;

            // Membatasi sudut rotasi kamera pada sumbu Y agar tidak terbalik
            angleY = Mathf.Clamp(angleY, -80f, 80f);
        }

        // Menghitung rotasi kamera berdasarkan sudut yang telah diubah
        Quaternion rotation = Quaternion.Euler(angleY, angleX, 0f);

        // Menghitung posisi kamera berdasarkan rotasi dan jarak dari target
        Vector3 position = rotation * new Vector3(0f, 0f, -distance) + target.position;

        // Mengatur posisi dan rotasi kamera
        transform.position = position;
        transform.rotation = rotation;

        // Menampilkan nilai rotasi menggunakan TextMeshPro
        if (TextRotasi != null)
        {
            TextRotasi.text = "Camera Rotation X: " + angleX.ToString("F2") + "\nCamera Rotation Y: " + angleY.ToString("F2");
        }
    }
}
