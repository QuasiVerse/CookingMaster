using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class CookingManager : MonoBehaviour
{
    
    private GenerateHUD hud;
    private Canvas managercanvas;
    private GenerateHUD canvasgenerator;
    
    public bool playersinitiated;
    
    public float playertime = 250;
    
    public float playeronescore;
    public float playertwoscore;
    
    private Text playeronescoretext;
    private Text playertwoscoretext;
        
    public Text playeronetimertext;
    public Text playertwotimertext;
    
    public float playeronetimer;
    public float playertwotimer;
    
    public List<float> highscores;
    
    private Text winner;
    private Text highscoreone;
    private Text highscoretwo;
    private Text highscorethree;
    private Text highscorefour;
    private Text highscorefive;
    private Text highscoresix;
    private Text highscoreseven;
    private Text highscoreeight;
    private Text highscorenine;
    private Text highscoreten;
    
    private Button resetbutton;
    private Image resetbuttonimage;
    private Text resetbuttontext;
    
    public bool open = false;
    
    void Start()
    {
        Load();
        
        hud = this.transform.GetComponent<GenerateHUD>();
        
        playeronetimer = playertime;
        playertwotimer = playertime;
        
        //Procedurally Generate Scene
        LevelGenerator.GenerateLevel();
        PlayerGenerator.GeneratePlayer();
        GuestGenerator.GenerateGuest();
        this.gameObject.AddComponent<GuestManager>();
        
        //Initialize Lights
        this.gameObject.AddComponent<CameraController>();
        GameObject light = GameObject.Find("Directional Light");
        light.transform.GetComponent<Light>().type = LightType.Point;
        light.transform.GetComponent<Light>().range = 200;
        light.transform.position = new Vector3(LevelGenerator.floorlength/2, 9, LevelGenerator.floorwidth/2);
        
        //Generate HUD
        canvasgenerator = this.gameObject.AddComponent<GenerateHUD>();
        canvasgenerator.GenerateCanvas();
        managercanvas = canvasgenerator.managercanvas;        
        playeronescoretext = canvasgenerator.playeronescoretext;
        playertwoscoretext = canvasgenerator.playertwoscoretext;
        
        playeronetimertext = canvasgenerator.playeronetimertext;
        playertwotimertext = canvasgenerator.playertwotimertext;

        winner = canvasgenerator.winner;
        highscoreone = canvasgenerator.highscoreone;
        highscoretwo = canvasgenerator.highscoretwo;
        highscorethree = canvasgenerator.highscorethree;
        highscorefour = canvasgenerator.highscorefour;
        highscorefive = canvasgenerator.highscorefive;
        highscoresix = canvasgenerator.highscoresix;
        highscoreseven = canvasgenerator.highscoreseven;
        highscoreeight = canvasgenerator.highscoreeight;
        highscorenine = canvasgenerator.highscorenine;
        highscoreten = canvasgenerator.highscoreten;
        
        resetbutton = canvasgenerator.resetbutton;
        resetbuttonimage = canvasgenerator.resetbuttonimage;
        resetbuttontext = canvasgenerator.resetbuttontext;

    }

    void Update()
    {   
        if(playersinitiated == true)
        {
            playeronetimer -= Time.deltaTime;
            playertwotimer -= Time.deltaTime;
        }
        playeronetimertext.text = "    Time: " + playeronetimer.ToString("0");
        playertwotimertext.text = "    Time: " + playertwotimer.ToString("0");
        playeronescoretext.text = "    SCORE: " + playeronescore.ToString();
        playertwoscoretext.text = "    SCORE: " + playertwoscore.ToString();
                
        if(playeronetimer <= 0)
        {
            PlayerGenerator.playerone.GetComponent<PlayerController>().enabled = false;
        }
        if(playertwotimer <= 0)
        {
            PlayerGenerator.playertwo.GetComponent<PlayerController>().enabled = false;
        }
        if(playeronetimer > 0)
        {
            PlayerGenerator.playerone.GetComponent<PlayerController>().enabled = true;
        }
        if(playertwotimer > 0)
        {
            PlayerGenerator.playertwo.GetComponent<PlayerController>().enabled = true;
        }
        if(playeronetimer <= 0 && playertwotimer <= 0 && open == true)
        {
            open = false;
            if(playeronescore > playertwoscore)
            {
                Close(1, playeronescore);
            }
            if(playertwoscore > playeronescore)
            {
                Close(2, playertwoscore);
            }
            if(playeronescore == playertwoscore)
            {
                Close(0, playeronescore);
            }
        }
    }
    
    public void Report(float positive, float player, float expense)
    {
        
        if(player == 1){
            playeronescore += expense * positive;
        }
        if(player == 2){
            playertwoscore += expense * positive;
        }
    }

    
    void Close(int playernumber, float winnerscore)
    {
        playeronescoretext.enabled = false;
        playeronetimertext.enabled = false;
        playertwoscoretext.enabled = false;
        playertwotimertext.enabled = false;
        resetbutton.enabled = true;
        resetbuttonimage.enabled = true;
        resetbuttonimage.enabled = false;
        winner.enabled = true;
        highscoreone.enabled = true;
        highscoretwo.enabled = true;
        highscorethree.enabled = true;
        highscorefour.enabled = true;
        highscorefive.enabled = true;
        highscoresix.enabled = true;
        highscoreseven.enabled = true;
        highscoreeight.enabled = true;
        highscorenine.enabled = true;
        highscoreten.enabled = true;
        for(int x = 0; x < highscores.Count; x++)
        {   
            if(winnerscore > highscores[x])
            {
                highscores.Insert(x, winnerscore);
            }
        }
        winner.text = "Player " + playernumber.ToString() + ": " + winnerscore.ToString();
        highscoreone.text = highscores[0].ToString();
        highscoretwo.text = highscores[1].ToString();
        highscorethree.text = highscores[2].ToString();
        highscorefour.text = highscores[3].ToString();
        highscorefive.text = highscores[4].ToString();
        highscoresix.text = highscores[5].ToString();
        highscoreseven.text = highscores[6].ToString();
        highscoreeight.text = highscores[7].ToString();
        highscorenine.text = highscores[8].ToString();
        highscoreten.text = highscores[9].ToString();
        
        Save(highscores[0], highscores[1], highscores[2], highscores[3], highscores[4], highscores[5], highscores[6], highscores[7], highscores[8], highscores[9]);
    }
    
    void Load()
    {
        highscores = new List<float>();
        highscores.Add(PlayerPrefs.GetFloat("One"));
        highscores.Add(PlayerPrefs.GetFloat("Two"));
        highscores.Add(PlayerPrefs.GetFloat("Three"));
        highscores.Add(PlayerPrefs.GetFloat("Four"));
        highscores.Add(PlayerPrefs.GetFloat("Five"));
        highscores.Add(PlayerPrefs.GetFloat("Six"));
        highscores.Add(PlayerPrefs.GetFloat("Seven"));
        highscores.Add(PlayerPrefs.GetFloat("Eight"));
        highscores.Add(PlayerPrefs.GetFloat("Nine"));
        highscores.Add(PlayerPrefs.GetFloat("Ten"));
    }
    
    void Save(float scoreone, float scoretwo, float scorethree, float scorefour, float scorefive, float scoresix, float scoreseven, float scoreeight, float scorenine, float scoreten)
    {   
        Debug.Log("Saving");
        PlayerPrefs.SetFloat("One", scoreone);
        PlayerPrefs.SetFloat("Two", scoretwo);
        PlayerPrefs.SetFloat("Three", scorethree);
        PlayerPrefs.SetFloat("Four", scorefour);
        PlayerPrefs.SetFloat("Five", scorefive);
        PlayerPrefs.SetFloat("Six", scoresix);
        PlayerPrefs.SetFloat("Seven", scoreseven);
        PlayerPrefs.SetFloat("Eight", scoreeight);
        PlayerPrefs.SetFloat("Nine", scorenine);
        PlayerPrefs.SetFloat("Ten", scoreten);
        PlayerPrefs.Save();
    }
}
