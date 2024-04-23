using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Untuk mengakses SceneManagement untuk berpindah scene.
using TMPro;


public class Dialog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textDisplay; // Variabel untuk menampung objek UI Text yang akan menampilkan teks dialog.
    [SerializeField] private Image imageDisplay; // Variabel untuk menampung objek UI Image yang akan menampilkan gambar.
    [SerializeField] private Sprite[] images; // Array untuk menyimpan gambar yang sesuai dengan setiap kalimat dalam dialog.
    [SerializeField] private string[] sentences; // Array untuk menyimpan kalimat-kalimat dalam dialog.
    private int index; // Variabel untuk melacak indeks kalimat yang sedang ditampilkan.
    [SerializeField] private float typingSpeed; // Kecepatan mengetik untuk setiap huruf dalam teks.
    [SerializeField] private GameObject continueButton; // Objek tombol lanjutkan dalam dialog.
    [SerializeField] private GameObject dialog;

    private void Start()
    {
        StartCoroutine(Type()); // Memulai proses mengetik teks dialog.
        continueButton.SetActive(false);
    }

    private void Update()
    {
        if (textDisplay.text == sentences[index]) // Memeriksa apakah teks yang ditampilkan sudah sama dengan kalimat yang sedang ditampilkan.
        {
            continueButton.SetActive(true); // Mengaktifkan tombol lanjutkan jika teks sudah selesai ditampilkan.
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray()) // Loop untuk menampilkan setiap huruf dalam kalimat.
        {
            textDisplay.text += letter; // Menambahkan huruf ke teks yang ditampilkan.
            yield return new WaitForSeconds(typingSpeed); // Menunggu sebelum menampilkan huruf berikutnya.
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false); // Menonaktifkan tombol lanjutkan.

        if (index < sentences.Length - 1) // Memeriksa apakah masih ada kalimat berikutnya dalam array kalimat.
        {
            index++; // Menambahkan indeks untuk beralih ke kalimat berikutnya.
            textDisplay.text = ""; // Mengosongkan teks yang ditampilkan.
            imageDisplay.sprite = images[index]; // Menetapkan gambar yang sesuai dengan kalimat yang akan ditampilkan.
            StartCoroutine(Type()); // Memulai proses mengetik kalimat berikutnya.
        }
        else
        {
            // Jika kalimat terakhir telah diucapkan, maka pindah ke scene selanjutnya.
            //SceneManager.LoadScene("Level 1");
            dialog.SetActive(false);
        }
    }
}
