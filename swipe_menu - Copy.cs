using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class swipe_menu : MonoBehaviour
{
    public GameObject scrollbar; // GameObject scrollbar yang akan digunakan untuk mengontrol posisi scroll
    float scroll_pos = 0; // Variabel untuk menyimpan posisi scrollbar
    float[] pos; // Array untuk menyimpan posisi relatif setiap item di dalam menu

    // Start is called before the first frame update
    void Start()
    {
        // Metode Start kosong, tidak melakukan operasi saat GameObject pertama kali aktif
    }

    // Update is called once per frame
    void Update()
    {
        // Menginisialisasi array pos dengan panjang yang sama dengan jumlah anak-anak (child) yang dimiliki oleh GameObject yang mengandung script ini
        pos = new float[transform.childCount];

        // Menghitung jarak antara setiap posisi item di menu swipe
        float distance = 1f / (pos.Length - 1f);

        // Mengisi array pos dengan posisi relatif setiap item dalam menu swipe
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        // Memeriksa apakah tombol mouse kiri sedang ditekan
        if (Input.GetMouseButton(0))
        {
            // Jika ditekan, nilai scroll_pos diupdate dengan nilai scrollbar saat ini
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            // Jika tidak ditekan, melakukan perulangan untuk menentukan posisi scrollbar relatif terhadap setiap item dalam menu swipe
            for (int i = 0; i < pos.Length; i++)
            {
                // Memeriksa apakah posisi scrollbar berada di dekat posisi item tertentu
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    // Jika posisi scrollbar berada di dekat posisi item, mengubah nilai scrollbar secara bertahap untuk mencocokkan posisi item tersebut
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        // Memeriksa posisi scrollbar terhadap setiap item dalam menu swipe
        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                // Jika posisi scrollbar berada di dekat posisi item, mengubah skala (scale) dari item yang sedang aktif secara bertahap menjadi lebih besar
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                
                // Melakukan perulangan untuk mengubah skala (scale) dari item lain di luar item yang sedang aktif agar menjadi lebih kecil
                for (int a = 0; a < pos.Length; a++)
                {
                    if (a != i)
                    {
                        transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }
            }
        }
    }
}