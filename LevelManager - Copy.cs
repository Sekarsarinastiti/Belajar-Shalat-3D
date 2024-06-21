using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Mendefinisikan kelas LevelManager yang mewarisi dari MonoBehaviour.
public class LevelManager : MonoBehaviour
{
    // Mendefinisikan metode public 'scene' yang menerima satu parameter string bernama 'scene'.
    public void scene(string scene)
    {
        // Memanggil metode LoadLevel dari kelas Application untuk memuat scene dengan nama yang diberikan.
        Application.LoadLevel(scene);
    }
}