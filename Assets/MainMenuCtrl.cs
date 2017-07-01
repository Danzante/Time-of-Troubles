using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCtrl : MonoBehaviour {

    GameObject col;
    GameObject main;
    GameObject net;
    GameObject game;
    GameObject shop;
    GameObject boost;

    // Use this for initialization
    void Start ()
    {
        col = GameObject.Find("/Collection");
        main = GameObject.Find("/Main");
        net = GameObject.Find("/Network");
        game = GameObject.Find("/Game");
        shop = GameObject.Find("/Shop");
        boost = GameObject.Find("/Boosters");
        ActivateMain();
    }

    public void ActivateMain()
    {
        main.SetActive(true);
        col.SetActive(false);
        net.SetActive(false);
        game.SetActive(false);
        shop.SetActive(false);
        boost.SetActive(false);
    }

    public void ActivateCollection()
    {
        main.SetActive(false);
        col.SetActive(true);
        net.SetActive(false);
        game.SetActive(false);
        shop.SetActive(false);
        boost.SetActive(false);
    }

    public void ActivateNetwork()
    {
        main.SetActive(false);
        col.SetActive(false);
        net.SetActive(true);
        game.SetActive(false);
        shop.SetActive(false);
        boost.SetActive(false);
    }

    public void ActivateGame()
    {
        main.SetActive(false);
        col.SetActive(false);
        net.SetActive(false);
        game.SetActive(true);
        shop.SetActive(false);
        boost.SetActive(false);
    }

    public void ActivateShop()
    {
        main.SetActive(false);
        col.SetActive(false);
        net.SetActive(false);
        game.SetActive(false);
        shop.SetActive(true);
        boost.SetActive(false);
    }

    public void ActivateBoosters()
    {
        main.SetActive(false);
        col.SetActive(false);
        net.SetActive(false);
        game.SetActive(false);
        shop.SetActive(false);
        boost.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
