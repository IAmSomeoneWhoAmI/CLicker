using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ItemDistribution : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI _NameText, _Money, _Auto_Money, _New_Money, TMPGalery1, TMPGalery2, TMPGalery3, TMPGalery4, TMPGalery5, TMPGalery6;

    [SerializeField]
    private Image _HpBar, _ItemImage ,ImageGalery1, ImageGalery2, ImageGalery3, ImageGalery4, ImageGalery5, ImageGalery6;

    [SerializeField]
    public SellingItems _CurrentItem;
    
    private float _Hp, _ItemValue,_AutoPrice, _MyPrice, _NewPrice, _NewCount, _galeryName;

    private bool Notification = false;

    public Animator _Animator_Clicker, _Animator_Coin;
    

    [SerializeField]
    private SellingItems[] _Random;   

    [SerializeField]
    private Button _auto;
    [SerializeField]
    public GameObject Red_Dot;

    void Start()
    {
        ReadItem(_Random[Random.Range(0,0)]);
        _AutoPrice = 1;
        _NewPrice = 50;
        _NewCount = 0;
        _MyPrice = 0;
        Red_Dot.SetActive(false);
        
    }

    void Update()
    {
        _Auto_Money.text = _AutoPrice.ToString("0");
        _New_Money.text = _NewPrice.ToString("0");
        if (_NewCount >= 5)
        {
            _New_Money.text = _NewPrice.ToString("MAX");
            _NewPrice = 0;
        }

    }

    public void ReduceHp()
    {
        
        if (_HpBar.fillAmount <= 0)
        {
            
            _Money.text = _ItemValue.ToString("0");
            _MyPrice += _ItemValue;
            _Money.text = _MyPrice.ToString();
            Debug.Log(_ItemValue);
            Debug.Log(_NewCount);

            if (_NewCount == 0)
            {
                ReadItem(_Random[Random.Range(0, 0)]);
                TMPGalery1.text = _galeryName.ToString("Tiny Crystal");
                ImageGalery1.color = Color.white;
                
                
            }
            if (_NewCount ==  1)
            {
                ReadItem(_Random[Random.Range(0, 2)]);
                TMPGalery1.text = _galeryName.ToString("Tiny Crystal");
                ImageGalery1.color = Color.white;
                TMPGalery2.text = _galeryName.ToString("Magical Clover");
                ImageGalery2.color = Color.white;
                
            }
            if (_NewCount == 2)
            {
                ReadItem(_Random[Random.Range(0, 3)]);
                TMPGalery1.text = _galeryName.ToString("Tiny Crystal");
                ImageGalery1.color = Color.white;
                TMPGalery2.text = _galeryName.ToString("Magical Clover");
                ImageGalery2.color = Color.white;
                TMPGalery3.text = _galeryName.ToString("Crystal ball");
                ImageGalery3.color = Color.white;
                
            }
            if (_NewCount == 3)
            {
                ReadItem(_Random[Random.Range(0, 4)]);
                TMPGalery1.text = _galeryName.ToString("Tiny Crystal");
                ImageGalery1.color = Color.white;
                TMPGalery2.text = _galeryName.ToString("Magical Clover");
                ImageGalery2.color = Color.white;
                TMPGalery3.text = _galeryName.ToString("Crystal ball");
                ImageGalery3.color = Color.white;
                TMPGalery4.text = _galeryName.ToString("Greek eye");
                ImageGalery4.color = Color.white;
                
            }
            if (_NewCount == 4)
            {
                ReadItem(_Random[Random.Range(0, 5)]);
                TMPGalery1.text = _galeryName.ToString("Tiny Crystal");
                ImageGalery1.color = Color.white;
                TMPGalery2.text = _galeryName.ToString("Magical Clover");
                ImageGalery2.color = Color.white;
                TMPGalery3.text = _galeryName.ToString("Crystal ball");
                ImageGalery3.color = Color.white;
                TMPGalery4.text = _galeryName.ToString("Greek eye");
                ImageGalery4.color = Color.white;
                TMPGalery5.text = _galeryName.ToString("Sacred Diamond");
                ImageGalery5.color = Color.white;
                
            }
            if (_NewCount >= 5)
            {
                TMPGalery1.text = _galeryName.ToString("Tiny Crystal");
                ImageGalery1.color = Color.white;
                TMPGalery2.text = _galeryName.ToString("Magical Clover");
                ImageGalery2.color = Color.white;
                TMPGalery3.text = _galeryName.ToString("Crystal ball");
                ImageGalery3.color = Color.white;
                TMPGalery4.text = _galeryName.ToString("Greek eye");
                ImageGalery4.color = Color.white;
                TMPGalery5.text = _galeryName.ToString("Sacred Diamond");
                ImageGalery5.color = Color.white;
                ReadItem(_Random[Random.Range(0, _Random.Length)]);
                TMPGalery6.text = _galeryName.ToString("Zodiacs");
                ImageGalery6.color = Color.white;
                



            }
            if (!Notification)
            {
                Red_Dot.SetActive(true);
                Notification = true;
            }
            
            _Hp = _CurrentItem.ItemHp;
            _Animator_Coin.SetTrigger("0hp");
        }
        _Hp --;
        _Animator_Clicker.SetTrigger("grow");
        _HpBar.fillAmount = (float)_Hp / (float)_CurrentItem.ItemHp;
        




    }
    private void ReadItem(SellingItems newItem)
    {
        _CurrentItem = newItem;

        _Hp = _CurrentItem.ItemHp;

        _ItemValue = _CurrentItem.Value;

        _NameText.text = _CurrentItem.ItemName.ToString();

        _ItemImage.sprite = _CurrentItem.ItemImage;

        
    }
    public IEnumerator MaCoroutine()
    {
        while (true)
        {            
            ReduceHp();
            _Animator_Clicker.Play("grow");
            yield return new WaitForSeconds(1f);           
        }

    }

    public void BuyAuto(int i)
    {
        if (_AutoPrice <= _MyPrice)
            
        {
            
            _MyPrice -= _AutoPrice;
            _Money.text = _MyPrice.ToString();
            _AutoPrice *= 2;
            




            StartCoroutine(MaCoroutine());

        }
        

    }

    public void BuyNew()
    {
        if (_NewPrice <= _MyPrice)

        {

            _MyPrice -= _NewPrice;
            _Money.text = _MyPrice.ToString();
            _NewPrice *= 3;
            _NewCount += 1;
            Red_Dot.SetActive(true);




        }


    }

    public void Notif() 
    {
        Red_Dot.SetActive(false);
    }

    
}
