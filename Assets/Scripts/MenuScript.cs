using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MenuScript : MonoBehaviour
{
    public GameObject cam;
    public float speed = 500;
    public float Pos = 0;
    public bool moveCamInv;
    public bool moveCamHeroAttack;
    public bool moveCamMain;
    public bool moveCamShop;
    public GameObject shop;
    public GameObject main;
    public GameObject inv;    
    public GameObject HeroAttack;    
    public GameObject shopCheckPoint;
    public GameObject HeroAttackCheckPoint;
    public GameObject mainCheckPoint;
    public GameObject invCheckPoint;
    public Vector3 shopEndVector;
    public Vector3 HeroAttackEndVector;
    public Vector3 mainEndVector;
    public Vector3 invEndVector;

    public int resX = 0, resY = 0;
    public Resolution[] resol;

    [SerializeField] SoundsManager _sm;
    // Start is called before the first frame update
    void Start()
    {
        _sm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundsManager>();
        shopEndVector = shopCheckPoint.transform.position;
        mainEndVector = mainCheckPoint.transform.position;
        invEndVector = invCheckPoint.transform.position;
        HeroAttackEndVector = HeroAttackCheckPoint.transform.position;
        resol = Screen.resolutions;
        foreach (var res in resol)
        {
            resX = res.width;
            resY = res.height;
        }
        resX = 1080;
        resY = 1280;
        //cam.GetComponent<Transform>().position= new Vector3(0,0,0);
        camHeroAttack();
    }
    public void camShop()
    {

        moveCamMain = false;
        moveCamHeroAttack = false;
        moveCamInv = false;
        moveCamShop = true;
        _sm.PlaySound(0);
        inv.GetComponent<Image>().color = new Color32(0, 0, 0, 70);
        main.GetComponent<Image>().color = new Color32(0, 0, 0, 70);
        HeroAttack.GetComponent<Image>().color = new Color32(0, 0, 0, 70);
        shop.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
    }
    public void camInventory()
    {

        moveCamMain = false;
        moveCamHeroAttack = false;
        moveCamInv = true;
        moveCamShop = false;
        _sm.PlaySound(0);
        inv.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        main.GetComponent<Image>().color = new Color32(0, 0, 0, 70);
        shop.GetComponent<Image>().color = new Color32(0, 0, 0, 70);
        HeroAttack.GetComponent<Image>().color = new Color32(0, 0, 0, 70);

    }
    public void camHeroAttack()
    {

        moveCamMain = false;
        moveCamHeroAttack = true;
        moveCamInv = false;
        moveCamShop = false;
        _sm.PlaySound(0);
        HeroAttack.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        inv.GetComponent<Image>().color = new Color32(0, 0, 0, 70);
        main.GetComponent<Image>().color = new Color32(0, 0, 0, 70);
        shop.GetComponent<Image>().color = new Color32(0, 0, 0, 70);

    }
    public void camMain()
    {

        moveCamMain = true;
        moveCamHeroAttack = false;
        moveCamInv = false;
        moveCamShop = false;
        _sm.PlaySound(0);
        inv.GetComponent<Image>().color = new Color32(0, 0, 0, 70);
        HeroAttack.GetComponent<Image>().color = new Color32(0, 0, 0, 70);
        main.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        shop.GetComponent<Image>().color = new Color32(0, 0, 0, 70);
    }
    // Update is called once per frame
    void Update()
    {
        if (moveCamInv == true)
        {
            cam.GetComponent<Transform>().position = Vector3.Lerp(cam.transform.position, invEndVector, 20 * Time.deltaTime);
            if (Math.Round(cam.transform.position.x) == -resX * 2)
            {
                cam.GetComponent<Transform>().position = invEndVector;
                moveCamInv = false;
            }
        }

        if (moveCamShop == true)
        {
            cam.GetComponent<Transform>().position = Vector3.Lerp(cam.transform.position, HeroAttackEndVector, 20 * Time.deltaTime);
            if (Math.Round(cam.transform.position.x) == resX)
            {
                cam.GetComponent<Transform>().position = HeroAttackEndVector;
                moveCamInv = false;
            }
        }


        if (moveCamMain == true)
        {
            cam.GetComponent<Transform>().position = Vector3.Lerp(cam.transform.position, mainEndVector, 20 * Time.deltaTime);
            if (Math.Round(cam.transform.position.x) == 0)
            {
                cam.GetComponent<Transform>().position = mainEndVector;
                moveCamInv = false;
            }
        }
        if (moveCamHeroAttack == true)
        {
            cam.GetComponent<Transform>().position = Vector3.Lerp(cam.transform.position, shopEndVector, 20 * Time.deltaTime);
            if (Math.Round(cam.transform.position.x) == -resX)
            {
                cam.GetComponent<Transform>().position = HeroAttackEndVector;
                moveCamHeroAttack = false;
            }
        }
    }
}
