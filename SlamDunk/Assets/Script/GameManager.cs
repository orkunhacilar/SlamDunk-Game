using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("---LEVEL TEMEL OBJELERI")]
    [SerializeField] private GameObject Platform;
    [SerializeField] private GameObject Pota;
    [SerializeField] private GameObject PotaBuyume;
    [SerializeField] private GameObject[] OzellikOlusturmaNoktalari;

    [Header("---UI OBJELERI")]
    [SerializeField] private Image[] GorevGorselleri;
    [SerializeField] private Sprite GorevTamamSprite;
    [SerializeField] private int AtilmasiGerekenTop;
    int BasketSayisi;

    [Header("---SESLER")]

    public AudioSource[] sesler;

    [Header("---Efektler")]

    public ParticleSystem basketefekt;
    public GameObject kaybetme;



    

    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i < AtilmasiGerekenTop; i++)
        {
            GorevGorselleri[i].gameObject.SetActive(true);
        }
       // Invoke("ozellikolussun", 3f);
    }

    void ozellikolussun()
    {
        // int RandomSayi = Random.Range(0, 2); //random sayi uretmek icin metod
        int RandomSayi = Random.Range(0, OzellikOlusturmaNoktalari.Length-1);

        PotaBuyume.transform.position = OzellikOlusturmaNoktalari[RandomSayi].transform.position;
        PotaBuyume.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(Platform.transform.position.x > -1.45) 
            Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3(Platform.transform.position.x - 1f,
               Platform.transform.position.y, Platform.transform.position.z), .050f);

        }else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (Platform.transform.position.x < 1.45)
                Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3(Platform.transform.position.x + 1f,
               Platform.transform.position.y, Platform.transform.position.z), .050f);
        }

    }

    public void Basket()
    {
        
        basketefekt.Play();
        sesler[0].Play();
        BasketSayisi++;
        GorevGorselleri[BasketSayisi - 1].sprite = GorevTamamSprite;

        if(BasketSayisi == AtilmasiGerekenTop)
        {
            Debug.Log("KAZANDIN");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // aktif olan sahneyi bir daha yukle
        }
        if (BasketSayisi == 1)
        {
            ozellikolussun();
        }
        
    }

    

    public void Kaybettin()
    {
        kaybetme.SetActive(true);
        sesler[3].Play();
        Debug.Log("Kaybettin");
        Invoke("tekrarYukle", 1f);
    }

    public void PotaBuyut()
    {
        sesler[2].Play();
        Pota.transform.localScale = new Vector3(55f, 55f, 55f); // bir cismin degerlerini degistiriyoruz
    }

    public void tekrarYukle()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // aktif olan sahneyi bir daha yukle
    }
   
}
