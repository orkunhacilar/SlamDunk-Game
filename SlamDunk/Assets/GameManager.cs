using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Platform;

    [SerializeField] private Image[] GorevGorselleri;
    [SerializeField] private Sprite GorevTamamSprite;
    [SerializeField] private int AtilmasiGerekenTop;
    int BasketSayisi;


    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i < AtilmasiGerekenTop; i++)
        {
            GorevGorselleri[i].gameObject.SetActive(true);
        }

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
        BasketSayisi++;
        GorevGorselleri[BasketSayisi - 1].sprite = GorevTamamSprite;

        if(BasketSayisi == AtilmasiGerekenTop)
        {
            Debug.Log("KAZANDIN");
        }
    }

    public void Kaybettin()
    {
        Debug.Log("Kaybettin");
    }
}
