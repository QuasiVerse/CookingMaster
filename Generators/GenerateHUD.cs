using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GenerateHUD : MonoBehaviour
{      

    private CookingManager manager;
    private Camera managercamera;
    public Canvas managercanvas;    
    private GuestManager guestmanager;
    
    private Text choosenumberplayers;
    
    public Button resetbutton;
    public Image resetbuttonimage;
    public Text resetbuttontext;
    
    public Button chooseonebutton;
    public Image chooseonebuttonimage;
    private Text chooseonebuttontext;
    
    public Button choosetwobutton;
    public Image choosetwobuttonimage;
    private Text choosetwobuttontext;


    public GameObject playeronetextobject;
    public Text playeronetimertext;
    
    public GameObject playeronescoreobject;
    public Text playeronescoretext;
    
    public GameObject playertwotextobject;
    public Text playertwotimertext;
    
    public GameObject playertwoscoreobject;
    public Text playertwoscoretext;
    
    public Image playeroneslotoneeggplant;
    public Image playeroneslotonetomato;
    public Image playeroneslotonezuccini;
    public Image playeroneslotonepotato;
    public Image playeroneslotonecorn;
    public Image playeroneslotonelettuce;
    
    public Image playeroneslottwoeggplant;
    public Image playeroneslottwotomato;
    public Image playeroneslottwozuccini;
    public Image playeroneslottwopotato;
    public Image playeroneslottwocorn;
    public Image playeroneslottwolettuce;
    
    public Image playertwoslotoneeggplant;
    public Image playertwoslotonetomato;
    public Image playertwoslotonezuccini;
    public Image playertwoslotonepotato;
    public Image playertwoslotonecorn;
    public Image playertwoslotonelettuce;
    
    public Image playertwoslottwoeggplant;
    public Image playertwoslottwotomato;
    public Image playertwoslottwozuccini;
    public Image playertwoslottwopotato;
    public Image playertwoslottwocorn;
    public Image playertwoslottwolettuce;
    public List<GameObject> guesttimers;
    public List<RectTransform> guesttimersrect;
    public List<RectTransform> guesttimerslidersrect;
    
    public Text winner;
    
    public Text highscoreone;
    public Text highscoretwo;
    public Text highscorethree;
    public Text highscorefour;
    public Text highscorefive;
    public Text highscoresix;
    public Text highscoreseven;
    public Text highscoreeight;
    public Text highscorenine;
    public Text highscoreten;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            ChooseOnePlayer();
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            ChooseTwoPlayer();
        }
    }
    
    public void Open()
    {
        playeronescoretext.enabled = false;
        playeronetimertext.enabled = false;
        playertwoscoretext.enabled = false;
        playertwotimertext.enabled = false;
        resetbutton.enabled = false;
        resetbuttonimage.enabled = false;
        resetbuttontext.enabled = false;
        winner.enabled = false;
        highscoreone.enabled = false;
        highscoretwo.enabled = false;
        highscorethree.enabled = false;
        highscorefour.enabled = false;
        highscorefive.enabled = false;
        highscoresix.enabled = false;
        highscoreseven.enabled = false;
        highscoreeight.enabled = false;
        highscorenine.enabled = false;
        highscoreten.enabled = false;
        chooseonebuttonimage.enabled = true;
        chooseonebutton.enabled = true;
        chooseonebuttontext.enabled = true;
        choosetwobuttonimage.enabled = true;
        choosetwobutton.enabled = true;
        choosetwobuttontext.enabled = true;
        choosenumberplayers.enabled = true;
    }
    
    public void ChooseOnePlayer()
    {
        chooseonebuttonimage.enabled = false;
        chooseonebutton.enabled = false;
        chooseonebuttontext.enabled = false;
        choosetwobuttonimage.enabled = false;
        choosetwobutton.enabled = false;
        choosetwobuttontext.enabled = false;
        choosenumberplayers.enabled = false;
        manager.playersinitiated = true;
        manager.playeronetimer = manager.playertime;
        playeronetimertext.enabled = true;
        playeronescoretext.enabled = true;
        PlayerGenerator.playerone.SetActive(true);
        manager.open = true;
    }
    
    public void ChooseTwoPlayer()
    {
        chooseonebuttonimage.enabled = false;
        chooseonebutton.enabled = false;
        chooseonebuttontext.enabled = false;
        choosetwobuttonimage.enabled = false;
        choosetwobutton.enabled = false;
        choosetwobuttontext.enabled = false;
        choosenumberplayers.enabled = false;
        manager.playersinitiated = true;
        manager.playeronetimer = manager.playertime;
        manager.playertwotimer = manager.playertime;
        playeronetimertext.enabled = true;
        playeronescoretext.enabled = true;
        playertwotimertext.enabled = true;
        playertwoscoretext.enabled = true;
        PlayerGenerator.playerone.SetActive(true);
        PlayerGenerator.playertwo.SetActive(true);
        manager.open = true;
    }
    
    public void GenerateCanvas()
    {
        Sprite circlesprite = (Sprite)AssetDatabase.GetBuiltinExtraResource(typeof(Sprite), "UI/Skin/Knob.psd");

        manager = GameObject.Find("Main Camera").GetComponent<CookingManager>();
        managercamera = manager.GetComponent<Camera>();
        guestmanager = manager.GetComponent<GuestManager>();
        
        // Canvas
        GameObject managercanvasobject = new GameObject();
        managercanvasobject.name = "TestCanvas";
        managercanvasobject.AddComponent<Canvas>();
        
        managercanvas = managercanvasobject.GetComponent<Canvas>();
        managercanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        managercanvasobject.AddComponent<CanvasScaler>();
        managercanvasobject.AddComponent<GraphicRaycaster>();
        
        //Guest Timer UI Lists
        guesttimers = new List<GameObject>();
        guesttimersrect = new List<RectTransform>();
        guesttimerslidersrect = new List<RectTransform>();
        
        //Reset UI
        GameObject resetbuttonobject = new GameObject();
        resetbuttonobject.transform.parent = managercanvasobject.transform;
        resetbuttonimage = resetbuttonobject.AddComponent<Image>();
        resetbuttonimage.sprite = circlesprite;
        resetbutton = resetbuttonobject.AddComponent<Button>();
        resetbutton.onClick.AddListener(Open);
        RectTransform recttransform = resetbutton.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(-500, 200, 0);
        recttransform.sizeDelta = new Vector2(200, 200);
        recttransform.anchorMin = new Vector2(.5f, .5f);
        recttransform.anchorMax = new Vector2(.5f, .5f);
        recttransform.pivot = new Vector2(0, 1); 
        Material newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.5f, .5f, .5f, 1));
        resetbuttonimage.material = newmaterial;
        resetbuttonimage.enabled = false;
        resetbutton.enabled = false;
        
        GameObject resetbuttontextobject = new GameObject();
        resetbuttontextobject.transform.parent = resetbuttonobject.transform;
        resetbuttontext = resetbuttontextobject.AddComponent<Text>();
        resetbuttontext.text = "RESET";
        resetbuttontext.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        resetbuttontext.fontSize = 25;
        recttransform = resetbuttontext.GetComponent<RectTransform>();
        recttransform.anchorMin = new Vector2(0, 1);
        recttransform.anchorMax = new Vector2(0, 1);
        recttransform.pivot = new Vector2(0, 1);  
        recttransform.localPosition = new Vector3(60, -85, 0);
        recttransform.sizeDelta = new Vector2(200, 200);
        resetbuttontext.enabled = false;
        
        //Choose Number Of Players
        GameObject choosenumberplayersobject = new GameObject();
        choosenumberplayersobject.transform.parent = managercanvasobject.transform;
        choosenumberplayers = choosenumberplayersobject.AddComponent<Text>();
        choosenumberplayers.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        choosenumberplayers.fontSize = 15;
        choosenumberplayers.text = "CHOOSE NUMBER OF PLAYERS";
        recttransform = choosenumberplayers.GetComponent<RectTransform>();
        recttransform.anchorMin = new Vector2(.5f, 1);
        recttransform.anchorMax = new Vector2(.5f, 1);
        recttransform.pivot = new Vector2(.5f, .5f); 
        recttransform.sizeDelta = new Vector2(275, 200);
        recttransform.localPosition = new Vector3(0, 50, 0);
        
        GameObject chooseonebuttonobject = new GameObject();
        chooseonebuttonobject.transform.parent = managercanvasobject.transform;
        chooseonebuttonimage = chooseonebuttonobject.AddComponent<Image>();
        chooseonebuttonimage.sprite = circlesprite;
        chooseonebutton = chooseonebuttonobject.AddComponent<Button>();
        chooseonebutton.onClick.AddListener(ChooseOnePlayer);
        recttransform = chooseonebutton.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(-500, 200, 0);
        recttransform.sizeDelta = new Vector2(400, 400);
        recttransform.anchorMin = new Vector2(.5f, .5f);
        recttransform.anchorMax = new Vector2(.5f, .5f);
        recttransform.pivot = new Vector2(0, 1); 
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.5f, .5f, .5f, 1));
        chooseonebuttonimage.material = newmaterial;
        
        GameObject chooseonebuttontextobject = new GameObject();
        chooseonebuttontextobject.transform.parent = chooseonebuttonobject.transform;
        chooseonebuttontext = chooseonebuttontextobject.AddComponent<Text>();
        chooseonebuttontext.text = "1";
        chooseonebuttontext.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        chooseonebuttontext.fontSize = 175;
        recttransform = chooseonebuttontext.GetComponent<RectTransform>();
        recttransform.anchorMin = new Vector2(0, 1);
        recttransform.anchorMax = new Vector2(0, 1);
        recttransform.pivot = new Vector2(0, 1);  
        recttransform.localPosition = new Vector3(145, -100, 0);
        recttransform.sizeDelta = new Vector2(200, 200);
        
        GameObject choosetwobuttonobject = new GameObject();
        choosetwobuttonobject.transform.parent = managercanvasobject.transform;
        choosetwobuttonimage = choosetwobuttonobject.AddComponent<Image>();
        choosetwobuttonimage.sprite = circlesprite;
        choosetwobutton = choosetwobuttonobject.AddComponent<Button>();
        choosetwobutton.onClick.AddListener(ChooseTwoPlayer);
        recttransform = choosetwobutton.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(75, 200, 0);
        recttransform.sizeDelta = new Vector2(400, 400);
        recttransform.anchorMin = new Vector2(.5f, .5f);
        recttransform.anchorMax = new Vector2(.5f, .5f);
        recttransform.pivot = new Vector2(0, 1); 
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.5f, .5f, .5f, 1));
        choosetwobuttonimage.material = newmaterial;
        
        GameObject choosetwobuttontextobject = new GameObject();
        choosetwobuttontextobject.transform.parent = choosetwobuttonobject.transform;
        choosetwobuttontext = choosetwobuttontextobject.AddComponent<Text>();
        choosetwobuttontext.text = "2";
        choosetwobuttontext.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        choosetwobuttontext.fontSize = 175;
        recttransform = choosetwobuttontext.GetComponent<RectTransform>();
        recttransform.anchorMin = new Vector2(0, 1);
        recttransform.anchorMax = new Vector2(0, 1);
        recttransform.pivot = new Vector2(0, 1);  
        recttransform.localPosition = new Vector3(145, -100, 0);
        recttransform.sizeDelta = new Vector2(200, 200);
        

        //Player One Timer
        GameObject playeronetimertextobject = new GameObject();
        playeronetimertextobject.transform.parent = managercanvasobject.transform;
        playeronetimertext = playeronetimertextobject.AddComponent<Text>();
        playeronetimertext.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        playeronetimertext.fontSize = 15;
        recttransform = playeronetimertext.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(25, -20, 0);
        recttransform.sizeDelta = new Vector2(400, 200);
        recttransform.anchorMin = new Vector2(0, 1);
        recttransform.anchorMax = new Vector2(0, 1);
        recttransform.pivot = new Vector2(0, 1);
        playeronetimertext.enabled = false;
        
        
        //Player Two Timer
        GameObject playertwotimertextobject = new GameObject();
        playertwotimertextobject.transform.parent = managercanvasobject.transform;
        playertwotimertext = playertwotimertextobject.AddComponent<Text>();
        playertwotimertext.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        playertwotimertext.fontSize = 15;
        recttransform = playertwotimertext.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(-135, -20, 0);
        recttransform.sizeDelta = new Vector2(400, 200);
        recttransform.anchorMin = new Vector2(1, 1);
        recttransform.anchorMax = new Vector2(1, 1);
        recttransform.pivot = new Vector2(0, 1); 
        playertwotimertext.enabled = false;
        
        //Player One Score
        GameObject playeronescoretextobject = new GameObject();
        playeronescoretextobject.transform.parent = managercanvasobject.transform;
        playeronescoretext = playeronescoretextobject.AddComponent<Text>();
        playeronescoretext.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        playeronescoretext.fontSize = 15;
        recttransform = playeronescoretext.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(25, -40, 0);
        recttransform.sizeDelta = new Vector2(400, 200);
        recttransform.anchorMin = new Vector2(0, 1);
        recttransform.anchorMax = new Vector2(0, 1);
        recttransform.pivot = new Vector2(0, 1); 
        playeronescoretext.enabled = false;
        
        //Player Two Score
        GameObject playertwoscoretextobject = new GameObject();
        playertwoscoretextobject.transform.parent = managercanvasobject.transform;
        playertwoscoretext = playertwoscoretextobject.AddComponent<Text>();
        playertwoscoretext.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        playertwoscoretext.fontSize = 15;
        recttransform = playertwoscoretext.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(-135, -40, 0);
        recttransform.sizeDelta = new Vector2(400, 200);
        recttransform.anchorMin = new Vector2(1, 1);
        recttransform.anchorMax = new Vector2(1, 1);
        recttransform.pivot = new Vector2(0, 1);  
        playertwoscoretext.enabled = false;

        //Player One Slot One
        GameObject playeroneslotoneeggplantobject = new GameObject();
        playeroneslotoneeggplantobject.name = "Eggplant";
        playeroneslotoneeggplantobject.transform.parent = managercanvasobject.transform;
        playeroneslotoneeggplant = playeroneslotoneeggplantobject.AddComponent<Image>();
        playeroneslotoneeggplant.sprite = circlesprite;
        recttransform = playeroneslotoneeggplant.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(0, -75, 0);
        recttransform.sizeDelta = new Vector2(125, 50);
        recttransform.anchorMin = new Vector2(0, 1);
        recttransform.anchorMax = new Vector2(0, 1);
        recttransform.pivot = new Vector2(0, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", LevelGenerator.eggplantcolor);
        playeroneslotoneeggplant.material = newmaterial;
        playeroneslotoneeggplant.enabled = false;
        
        GameObject playeroneslotonetomatoobject = new GameObject();
        playeroneslotonetomatoobject.name = "Tomato";
        playeroneslotonetomatoobject.transform.parent = managercanvasobject.transform;
        playeroneslotonetomato = playeroneslotonetomatoobject.AddComponent<Image>();
        playeroneslotonetomato.sprite = circlesprite;
        recttransform = playeroneslotonetomato.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(37.5f, -75, 0);
        recttransform.sizeDelta = new Vector2(50, 50);
        recttransform.anchorMin = new Vector2(0, 1);
        recttransform.anchorMax = new Vector2(0, 1);
        recttransform.pivot = new Vector2(0, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", LevelGenerator.tomatocolor);
        playeroneslotonetomato.material = newmaterial;
        playeroneslotonetomato.enabled = false;
        
        GameObject playeroneslotonezucciniobject = new GameObject();
        playeroneslotonezucciniobject.name = "Zuccini";
        playeroneslotonezucciniobject.transform.parent = managercanvasobject.transform;
        playeroneslotonezuccini = playeroneslotonezucciniobject.AddComponent<Image>();
        playeroneslotonezuccini.sprite = circlesprite;
        recttransform = playeroneslotonezuccini.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(0, -75, 0);
        recttransform.sizeDelta = new Vector2(125, 50);
        recttransform.anchorMin = new Vector2(0, 1);
        recttransform.anchorMax = new Vector2(0, 1);
        recttransform.pivot = new Vector2(0, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", LevelGenerator.zuccinicolor);
        playeroneslotonezuccini.material = newmaterial;
        playeroneslotonezuccini.enabled = false;
        
        GameObject playeroneslotonepotatoobject = new GameObject();
        playeroneslotonepotatoobject.name = "Potato";
        playeroneslotonepotatoobject.transform.parent = managercanvasobject.transform;
        playeroneslotonepotato = playeroneslotonepotatoobject.AddComponent<Image>();
        playeroneslotonepotato.sprite = circlesprite;
        recttransform = playeroneslotonepotato.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(37.5f, -75, 0);
        recttransform.sizeDelta = new Vector2(50, 50);
        recttransform.anchorMin = new Vector2(0, 1);
        recttransform.anchorMax = new Vector2(0, 1);
        recttransform.pivot = new Vector2(0, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", LevelGenerator.potatocolor);
        playeroneslotonepotato.material = newmaterial;
        playeroneslotonepotato.enabled = false;
        
        GameObject playeroneslotonecornobject = new GameObject();
        playeroneslotonecornobject.name = "Corn";
        playeroneslotonecornobject.transform.parent = managercanvasobject.transform;
        playeroneslotonecorn = playeroneslotonecornobject.AddComponent<Image>();
        playeroneslotonecorn.sprite = circlesprite;
        recttransform = playeroneslotonecorn.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(0, -75, 0);
        recttransform.sizeDelta = new Vector2(125, 50);
        recttransform.anchorMin = new Vector2(0, 1);
        recttransform.anchorMax = new Vector2(0, 1);
        recttransform.pivot = new Vector2(0, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", LevelGenerator.corncolor);
        playeroneslotonecorn.material = newmaterial;
        playeroneslotonecorn.enabled = false;
        
        GameObject playeroneslotonelettuceobject = new GameObject();
        playeroneslotonelettuceobject.name = "Lettuce";
        playeroneslotonelettuceobject.transform.parent = managercanvasobject.transform;
        playeroneslotonelettuce = playeroneslotonelettuceobject.AddComponent<Image>();
        playeroneslotonelettuce.sprite = circlesprite;
        recttransform = playeroneslotonelettuce.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(37.5f, -75, 0);
        recttransform.sizeDelta = new Vector2(50, 50);
        recttransform.anchorMin = new Vector2(0, 1);
        recttransform.anchorMax = new Vector2(0, 1);
        recttransform.pivot = new Vector2(0, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", LevelGenerator.lettucecolor);
        playeroneslotonelettuce.material = newmaterial;
        playeroneslotonelettuce.enabled = false;
        
        //Player One Slot Two
        GameObject playeroneslottwoeggplantobject = new GameObject();
        playeroneslottwoeggplantobject.name = "Eggplant";
        playeroneslottwoeggplantobject.transform.parent = managercanvasobject.transform;
        playeroneslottwoeggplant = playeroneslottwoeggplantobject.AddComponent<Image>();
        playeroneslottwoeggplant.sprite = circlesprite;
        recttransform = playeroneslottwoeggplant.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(0, -125, 0);
        recttransform.sizeDelta = new Vector2(125, 50);
        recttransform.anchorMin = new Vector2(0, 1);
        recttransform.anchorMax = new Vector2(0, 1);
        recttransform.pivot = new Vector2(0, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", LevelGenerator.eggplantcolor);
        playeroneslottwoeggplant.material = newmaterial;
        playeroneslottwoeggplant.enabled = false;
        
        GameObject playeroneslottwotomatoobject = new GameObject();
        playeroneslottwotomatoobject.name = "Tomato";
        playeroneslottwotomatoobject.transform.parent = managercanvasobject.transform;
        playeroneslottwotomato = playeroneslottwotomatoobject.AddComponent<Image>();
        playeroneslottwotomato.sprite = circlesprite;
        recttransform = playeroneslottwotomato.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(37.5f, -125, 0);
        recttransform.sizeDelta = new Vector2(50, 50);
        recttransform.anchorMin = new Vector2(0, 1);
        recttransform.anchorMax = new Vector2(0, 1);
        recttransform.pivot = new Vector2(0, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", LevelGenerator.tomatocolor);
        playeroneslottwotomato.material = newmaterial;
        playeroneslottwotomato.enabled = false;
        
        GameObject playeroneslottwozucciniobject = new GameObject();
        playeroneslottwozucciniobject.name = "Zuccini";
        playeroneslottwozucciniobject.transform.parent = managercanvasobject.transform;
        playeroneslottwozuccini = playeroneslottwozucciniobject.AddComponent<Image>();
        playeroneslottwozuccini.sprite = circlesprite;
        recttransform = playeroneslottwozuccini.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(0, -125, 0);
        recttransform.sizeDelta = new Vector2(125, 50);
        recttransform.anchorMin = new Vector2(0, 1);
        recttransform.anchorMax = new Vector2(0, 1);
        recttransform.pivot = new Vector2(0, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", LevelGenerator.zuccinicolor);
        playeroneslottwozuccini.material = newmaterial;
        playeroneslottwozuccini.enabled = false;
        
        GameObject playeroneslottwopotatoobject = new GameObject();
        playeroneslottwopotatoobject.name = "Potato";
        playeroneslottwopotatoobject.transform.parent = managercanvasobject.transform;
        playeroneslottwopotato = playeroneslottwopotatoobject.AddComponent<Image>();
        playeroneslottwopotato.sprite = circlesprite;
        recttransform = playeroneslottwopotato.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(37.5f, -125, 0);
        recttransform.sizeDelta = new Vector2(50, 50);
        recttransform.anchorMin = new Vector2(0, 1);
        recttransform.anchorMax = new Vector2(0, 1);
        recttransform.pivot = new Vector2(0, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", LevelGenerator.potatocolor);
        playeroneslottwopotato.material = newmaterial;
        playeroneslottwopotato.enabled = false;
        
        GameObject playeroneslottwocornobject = new GameObject();
        playeroneslottwocornobject.name = "Corn";
        playeroneslottwocornobject.transform.parent = managercanvasobject.transform;
        playeroneslottwocorn = playeroneslottwocornobject.AddComponent<Image>();
        playeroneslottwocorn.sprite = circlesprite;
        recttransform = playeroneslottwocorn.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(0, -125, 0);
        recttransform.sizeDelta = new Vector2(125, 50);
        recttransform.anchorMin = new Vector2(0, 1);
        recttransform.anchorMax = new Vector2(0, 1);
        recttransform.pivot = new Vector2(0, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", LevelGenerator.corncolor);
        playeroneslottwocorn.material = newmaterial;
        playeroneslottwocorn.enabled = false;
        
        GameObject playeroneslottwolettuceobject = new GameObject();
        playeroneslottwolettuceobject.name = "Lettuce";
        playeroneslottwolettuceobject.transform.parent = managercanvasobject.transform;
        playeroneslottwolettuce = playeroneslottwolettuceobject.AddComponent<Image>();
        playeroneslottwolettuce.sprite = circlesprite;
        recttransform = playeroneslottwolettuce.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(37.5f, -125, 0);
        recttransform.sizeDelta = new Vector2(50, 50);
        recttransform.anchorMin = new Vector2(0, 1);
        recttransform.anchorMax = new Vector2(0, 1);
        recttransform.pivot = new Vector2(0, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", LevelGenerator.lettucecolor);
        playeroneslottwolettuce.material = newmaterial;
        playeroneslottwolettuce.enabled = false;
        
        
        //Player Two Slot One
        GameObject playertwoslotoneeggplantobject = new GameObject();
        playertwoslotoneeggplantobject.name = "Eggplant";
        playertwoslotoneeggplantobject.transform.parent = managercanvasobject.transform;
        playertwoslotoneeggplant = playertwoslotoneeggplantobject.AddComponent<Image>();
        playertwoslotoneeggplant.sprite = circlesprite;
        recttransform = playertwoslotoneeggplant.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(0, -75, 0);
        recttransform.sizeDelta = new Vector2(125, 50);
        recttransform.anchorMin = new Vector2(1, 1);
        recttransform.anchorMax = new Vector2(1, 1);
        recttransform.pivot = new Vector2(1, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", LevelGenerator.eggplantcolor);
        playertwoslotoneeggplant.material = newmaterial;
        playertwoslotoneeggplant.enabled = false;
        
        GameObject playertwoslotonetomatoobject = new GameObject();
        playertwoslotonetomatoobject.name = "Tomato";
        playertwoslotonetomatoobject.transform.parent = managercanvasobject.transform;
        playertwoslotonetomato = playertwoslotonetomatoobject.AddComponent<Image>();
        playertwoslotonetomato.sprite = circlesprite;
        recttransform = playertwoslotonetomato.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(-37.5f, -75, 0);
        recttransform.sizeDelta = new Vector2(50, 50);
        recttransform.anchorMin = new Vector2(1, 1);
        recttransform.anchorMax = new Vector2(1, 1);
        recttransform.pivot = new Vector2(1, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", LevelGenerator.tomatocolor);
        playertwoslotonetomato.material = newmaterial;
        playertwoslotonetomato.enabled = false;
        
        GameObject playertwoslotonezucciniobject = new GameObject();
        playertwoslotonezucciniobject.name = "Zuccini";
        playertwoslotonezucciniobject.transform.parent = managercanvasobject.transform;
        playertwoslotonezuccini = playertwoslotonezucciniobject.AddComponent<Image>();
        playertwoslotonezuccini.sprite = circlesprite;
        recttransform = playertwoslotonezuccini.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(0, -75, 0);
        recttransform.sizeDelta = new Vector2(125, 50);
        recttransform.anchorMin = new Vector2(1, 1);
        recttransform.anchorMax = new Vector2(1, 1);
        recttransform.pivot = new Vector2(1, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", LevelGenerator.zuccinicolor);
        playertwoslotonezuccini.material = newmaterial;
        playertwoslotonezuccini.enabled = false;
        
        GameObject playertwoslotonepotatoobject = new GameObject();
        playertwoslotonepotatoobject.name = "Potato";
        playertwoslotonepotatoobject.transform.parent = managercanvasobject.transform;
        playertwoslotonepotato = playertwoslotonepotatoobject.AddComponent<Image>();
        playertwoslotonepotato.sprite = circlesprite;
        recttransform = playertwoslotonepotato.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(-37.5f, -75, 0);
        recttransform.sizeDelta = new Vector2(50, 50);
        recttransform.anchorMin = new Vector2(1, 1);
        recttransform.anchorMax = new Vector2(1, 1);
        recttransform.pivot = new Vector2(1, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", LevelGenerator.potatocolor);
        playertwoslotonepotato.material = newmaterial;
        playertwoslotonepotato.enabled = false;
        
        GameObject playertwoslotonecornobject = new GameObject();
        playertwoslotonecornobject.name = "Corn";
        playertwoslotonecornobject.transform.parent = managercanvasobject.transform;
        playertwoslotonecorn = playertwoslotonecornobject.AddComponent<Image>();
        playertwoslotonecorn.sprite = circlesprite;
        recttransform = playertwoslotonecorn.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(0, -75, 0);
        recttransform.sizeDelta = new Vector2(125, 50);
        recttransform.anchorMin = new Vector2(1, 1);
        recttransform.anchorMax = new Vector2(1, 1);
        recttransform.pivot = new Vector2(1, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", LevelGenerator.corncolor);
        playertwoslotonecorn.material = newmaterial;
        playertwoslotonecorn.enabled = false;
        
        GameObject playertwoslotonelettuceobject = new GameObject();
        playertwoslotonelettuceobject.name = "Lettuce";
        playertwoslotonelettuceobject.transform.parent = managercanvasobject.transform;
        playertwoslotonelettuce = playertwoslotonelettuceobject.AddComponent<Image>();
        playertwoslotonelettuce.sprite = circlesprite;
        recttransform = playertwoslotonelettuce.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(-37.5f, -75, 0);
        recttransform.sizeDelta = new Vector2(50, 50);
        recttransform.anchorMin = new Vector2(1, 1);
        recttransform.anchorMax = new Vector2(1, 1);
        recttransform.pivot = new Vector2(1, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", LevelGenerator.lettucecolor);
        playertwoslotonelettuce.material = newmaterial;
        playertwoslotonelettuce.enabled = false;
        
        //Player Two Slot Two
        GameObject playertwoslottwoeggplantobject = new GameObject();
        playertwoslottwoeggplantobject.name = "Eggplant";
        playertwoslottwoeggplantobject.transform.parent = managercanvasobject.transform;
        playertwoslottwoeggplant = playertwoslottwoeggplantobject.AddComponent<Image>();
        playertwoslottwoeggplant.sprite = circlesprite;
        recttransform = playertwoslottwoeggplant.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(0, -125, 0);
        recttransform.sizeDelta = new Vector2(125, 50);
        recttransform.anchorMin = new Vector2(1, 1);
        recttransform.anchorMax = new Vector2(1, 1);
        recttransform.pivot = new Vector2(1, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", LevelGenerator.eggplantcolor);
        playertwoslottwoeggplant.material = newmaterial;
        playertwoslottwoeggplant.enabled = false;
        
        GameObject playertwoslottwotomatoobject = new GameObject();
        playertwoslottwotomatoobject.name = "Tomato";
        playertwoslottwotomatoobject.transform.parent = managercanvasobject.transform;
        playertwoslottwotomato = playertwoslottwotomatoobject.AddComponent<Image>();
        playertwoslottwotomato.sprite = circlesprite;
        recttransform = playertwoslottwotomato.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(-37.5f, -125, 0);
        recttransform.sizeDelta = new Vector2(50, 50);
        recttransform.anchorMin = new Vector2(1, 1);
        recttransform.anchorMax = new Vector2(1, 1);
        recttransform.pivot = new Vector2(1, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", LevelGenerator.tomatocolor);
        playertwoslottwotomato.material = newmaterial;
        playertwoslottwotomato.enabled = false;
        
        GameObject playertwoslottwozucciniobject = new GameObject();
        playertwoslottwozucciniobject.name = "Zuccini";
        playertwoslottwozucciniobject.transform.parent = managercanvasobject.transform;
        playertwoslottwozuccini = playertwoslottwozucciniobject.AddComponent<Image>();
        playertwoslottwozuccini.sprite = circlesprite;
        recttransform = playertwoslottwozuccini.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(0, -125, 0);
        recttransform.sizeDelta = new Vector2(125, 50);
        recttransform.anchorMin = new Vector2(1, 1);
        recttransform.anchorMax = new Vector2(1, 1);
        recttransform.pivot = new Vector2(1, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", LevelGenerator.zuccinicolor);
        playertwoslottwozuccini.material = newmaterial;
        playertwoslottwozuccini.enabled = false;
        
        GameObject playertwoslottwopotatoobject = new GameObject();
        playertwoslottwopotatoobject.name = "Potato";
        playertwoslottwopotatoobject.transform.parent = managercanvasobject.transform;
        playertwoslottwopotato = playertwoslottwopotatoobject.AddComponent<Image>();
        playertwoslottwopotato.sprite = circlesprite;
        recttransform = playertwoslottwopotato.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(-37.5f, -125, 0);
        recttransform.sizeDelta = new Vector2(50, 50);
        recttransform.anchorMin = new Vector2(1, 1);
        recttransform.anchorMax = new Vector2(1, 1);
        recttransform.pivot = new Vector2(1, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", LevelGenerator.potatocolor);
        playertwoslottwopotato.material = newmaterial;
        playertwoslottwopotato.enabled = false;
        
        GameObject playertwoslottwocornobject = new GameObject();
        playertwoslottwocornobject.name = "Corn";
        playertwoslottwocornobject.transform.parent = managercanvasobject.transform;
        playertwoslottwocorn = playertwoslottwocornobject.AddComponent<Image>();
        playertwoslottwocorn.sprite = circlesprite;
        recttransform = playertwoslottwocorn.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(0, -125, 0);
        recttransform.sizeDelta = new Vector2(125, 50);
        recttransform.anchorMin = new Vector2(1, 1);
        recttransform.anchorMax = new Vector2(1, 1);
        recttransform.pivot = new Vector2(1, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", LevelGenerator.corncolor);
        playertwoslottwocorn.material = newmaterial;
        playertwoslottwocorn.enabled = false;
        
        GameObject playertwoslottwolettuceobject = new GameObject();
        playertwoslottwolettuceobject.name = "Lettuce";
        playertwoslottwolettuceobject.transform.parent = managercanvasobject.transform;
        playertwoslottwolettuce = playertwoslottwolettuceobject.AddComponent<Image>();
        playertwoslottwolettuce.sprite = circlesprite;
        recttransform = playertwoslottwolettuce.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(-37.5f, -125, 0);
        recttransform.sizeDelta = new Vector2(50, 50);
        recttransform.anchorMin = new Vector2(1, 1);
        recttransform.anchorMax = new Vector2(1, 1);
        recttransform.pivot = new Vector2(1, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", LevelGenerator.lettucecolor);
        playertwoslottwolettuce.material = newmaterial;
        playertwoslottwolettuce.enabled = false;
        
        GameObject guestonetimerobject = new GameObject();
        guestonetimerobject.name = "Guest One Timer";
        guestonetimerobject.transform.parent = managercanvasobject.transform;
        guesttimers.Add(guestonetimerobject);
        Image guestonetimer = guestonetimerobject.AddComponent<Image>();
        recttransform = guestonetimer.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(0, 0, 0);
        recttransform.sizeDelta = new Vector2(125, 50);
        recttransform.anchorMin = new Vector2(0, 0);
        recttransform.anchorMax = new Vector2(0, 0);
        recttransform.pivot = new Vector2(.5f, .5f);
        recttransform.localScale = new Vector3(.5f, .2f, 1);
        guesttimersrect.Add(recttransform);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.3f, .3f, .3f, 1));
        guestonetimer.material = newmaterial;
        guestonetimerobject.SetActive(false);
        
        GameObject guestonetimersliderobject = new GameObject();
        guestonetimersliderobject.name = "Guest One Timer Slider";
        guestonetimersliderobject.transform.parent = guestonetimerobject.transform;
        Image guestonetimerslider = guestonetimersliderobject.AddComponent<Image>();
        recttransform = guestonetimerslider.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(0, 0, 0);
        recttransform.sizeDelta = new Vector2(125, 50);
        recttransform.anchorMin = new Vector2(0, 1);
        recttransform.anchorMax = new Vector2(0, 1);
        recttransform.pivot = new Vector2(1, 1);
        recttransform.localScale = new Vector3(-1, 1, 1);
        guesttimerslidersrect.Add(recttransform);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.5f, .5f, .5f, 1));
        guestonetimerslider.material = newmaterial;
        
        GameObject guesttwotimerobject = new GameObject();
        guesttwotimerobject.name = "Guest Two Timer";
        guesttwotimerobject.transform.parent = managercanvasobject.transform;
        guesttimers.Add(guesttwotimerobject);
        Image guesttwotimer = guesttwotimerobject.AddComponent<Image>();
        recttransform = guesttwotimer.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(0, 0, 0);
        recttransform.sizeDelta = new Vector2(125, 50);
        recttransform.anchorMin = new Vector2(0, 0);
        recttransform.anchorMax = new Vector2(0, 0);
        recttransform.pivot = new Vector2(.5f, .5f);
        recttransform.localScale = new Vector3(.5f, .2f, 1);
        guesttimersrect.Add(recttransform);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.3f, .3f, .3f, 1));
        guesttwotimer.material = newmaterial;
        guesttwotimerobject.SetActive(false);
        
        GameObject guesttwotimersliderobject = new GameObject();
        guesttwotimersliderobject.name = "Guest Two Timer Slider";
        guesttwotimersliderobject.transform.parent = guesttwotimerobject.transform;
        Image guesttwotimerslider = guesttwotimersliderobject.AddComponent<Image>();
        recttransform = guesttwotimerslider.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(0, 0, 0);
        recttransform.sizeDelta = new Vector2(125, 50);
        recttransform.anchorMin = new Vector2(0, 1);
        recttransform.anchorMax = new Vector2(0, 1);
        recttransform.pivot = new Vector2(1, 1);
        recttransform.localScale = new Vector3(-1, 1, 1);
        guesttimerslidersrect.Add(recttransform);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.5f, .5f, .5f, 1));
        guesttwotimerslider.material = newmaterial;
        
        GameObject guestthreetimerobject = new GameObject();
        guestthreetimerobject.name = "Guest Three Timer";
        guestthreetimerobject.transform.parent = managercanvasobject.transform;
        guesttimers.Add(guestthreetimerobject);
        Image guestthreetimer = guestthreetimerobject.AddComponent<Image>();
        recttransform = guestthreetimer.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(0, 0, 0);
        recttransform.sizeDelta = new Vector2(125, 50);
        recttransform.anchorMin = new Vector2(0, 0);
        recttransform.anchorMax = new Vector2(0, 0);
        recttransform.pivot = new Vector2(.5f, .5f);
        recttransform.localScale = new Vector3(.5f, .2f, 1);
        guesttimersrect.Add(recttransform);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.3f, .3f, .3f, 1));
        guestthreetimer.material = newmaterial;
        guestthreetimerobject.SetActive(false);
        
        GameObject guestthreetimersliderobject = new GameObject();
        guestthreetimersliderobject.name = "Guest Three Timer Slider";
        guestthreetimersliderobject.transform.parent = guestthreetimerobject.transform;
        Image guestthreetimerslider = guestthreetimersliderobject.AddComponent<Image>();
        recttransform = guestthreetimerslider.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(0, 0, 0);
        recttransform.sizeDelta = new Vector2(125, 50);
        recttransform.anchorMin = new Vector2(0, 1);
        recttransform.anchorMax = new Vector2(0, 1);
        recttransform.pivot = new Vector2(1, 1);
        recttransform.localScale = new Vector3(-1, 1, 1);
        guesttimerslidersrect.Add(recttransform);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.5f, .5f, .5f, 1));
        guestthreetimerslider.material = newmaterial;
        
        GameObject guestfourtimerobject = new GameObject();
        guestfourtimerobject.name = "Guest Four Timer";
        guestfourtimerobject.transform.parent = managercanvasobject.transform;
        guesttimers.Add(guestfourtimerobject);
        Image guestfourtimer = guestfourtimerobject.AddComponent<Image>();
        recttransform = guestfourtimer.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(0, 0, 0);
        recttransform.sizeDelta = new Vector2(125, 50);
        recttransform.anchorMin = new Vector2(0, 0);
        recttransform.anchorMax = new Vector2(0, 0);
        recttransform.pivot = new Vector2(.5f, .5f);
        recttransform.localScale = new Vector3(.5f, .2f, 1);
        guesttimersrect.Add(recttransform);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.3f, .3f, .3f, 1));
        guestfourtimer.material = newmaterial;
        guestfourtimerobject.SetActive(false);

        GameObject guestfourtimersliderobject = new GameObject();
        guestfourtimersliderobject.name = "Guest Four Timer Slider";
        guestfourtimersliderobject.transform.parent = guestfourtimerobject.transform;
        Image guestfourtimerslider = guestfourtimersliderobject.AddComponent<Image>();
        recttransform = guestfourtimerslider.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(0, 0, 0);
        recttransform.sizeDelta = new Vector2(125, 50);
        recttransform.anchorMin = new Vector2(0, 1);
        recttransform.anchorMax = new Vector2(0, 1);
        recttransform.pivot = new Vector2(1, 1);
        recttransform.localScale = new Vector3(-1, 1, 1);
        guesttimerslidersrect.Add(recttransform);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.5f, .5f, .5f, 1));
        guestfourtimerslider.material = newmaterial;
        
        GameObject guestfivetimerobject = new GameObject();
        guestfivetimerobject.name = "Guest Five Timer";
        guestfivetimerobject.transform.parent = managercanvasobject.transform;
        guesttimers.Add(guestfivetimerobject);
        Image guestfivetimer = guestfivetimerobject.AddComponent<Image>();
        recttransform = guestfivetimer.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(0, 0, 0);
        recttransform.sizeDelta = new Vector2(125, 50);
        recttransform.anchorMin = new Vector2(0, 0);
        recttransform.anchorMax = new Vector2(0, 0);
        recttransform.pivot = new Vector2(.5f, .5f);
        recttransform.localScale = new Vector3(.5f, .2f, 1);
        guesttimersrect.Add(recttransform);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.3f, .3f, .3f, 1));
        guestfivetimer.material = newmaterial;
        guestfivetimerobject.SetActive(false);
        
        GameObject guestfivetimersliderobject = new GameObject();
        guestfivetimersliderobject.name = "Guest Five Timer Slider";
        guestfivetimersliderobject.transform.parent = guestfivetimerobject.transform;
        Image guestfivetimerslider = guestfivetimersliderobject.AddComponent<Image>();
        recttransform = guestfivetimerslider.GetComponent<RectTransform>();
        recttransform.localPosition = new Vector3(0, 0, 0);
        recttransform.sizeDelta = new Vector2(125, 50);
        recttransform.anchorMin = new Vector2(0, 1);
        recttransform.anchorMax = new Vector2(0, 1);
        recttransform.pivot = new Vector2(1, 1);
        recttransform.localScale = new Vector3(-1, 1, 1);
        guesttimerslidersrect.Add(recttransform);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.5f, .5f, .5f, 1));
        guestfivetimerslider.material = newmaterial;
        
        //Generate Winner
        GameObject winnerobject = new GameObject();
        winnerobject.transform.parent = managercanvasobject.transform;
        winner = winnerobject.AddComponent<Text>();
        winner.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        winner.fontSize = 50;
        recttransform = winner.GetComponent<RectTransform>();
        recttransform.anchorMin = new Vector2(.5f, 1);
        recttransform.anchorMax = new Vector2(.5f, 1);
        recttransform.pivot = new Vector2(.5f, .5f); 
        recttransform.sizeDelta = new Vector2(500, 200);
        recttransform.localPosition = new Vector3(0, -120, 0);
        winner.enabled = false;
        
        //Generate High Scores
        GameObject highscoreoneobject = new GameObject();
        highscoreoneobject.transform.parent = managercanvasobject.transform;
        highscoreone = highscoreoneobject.AddComponent<Text>();
        highscoreone.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        highscoreone.fontSize = 50;
        recttransform = highscoreone.GetComponent<RectTransform>();
        recttransform.anchorMin = new Vector2(.5f, 1);
        recttransform.anchorMax = new Vector2(.5f, 1);
        recttransform.pivot = new Vector2(.5f, .5f); 
        recttransform.sizeDelta = new Vector2(100, 200);
        recttransform.localPosition = new Vector3(0, 30, 0);
        highscoreone.enabled = false;
        
        GameObject highscoretwoobject = new GameObject();
        highscoretwoobject.transform.parent = managercanvasobject.transform;
        highscoretwo = highscoretwoobject.AddComponent<Text>();
        highscoretwo.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        highscoretwo.fontSize = 50;
        recttransform = highscoretwo.GetComponent<RectTransform>();
        recttransform.anchorMin = new Vector2(.5f, 1);
        recttransform.anchorMax = new Vector2(.5f, 1);
        recttransform.pivot = new Vector2(.5f, .5f); 
        recttransform.sizeDelta = new Vector2(100, 200);
        recttransform.localPosition = new Vector3(0, -10, 0);
        highscoretwo.enabled = false;

        GameObject highscorethreeobject = new GameObject();
        highscorethreeobject.transform.parent = managercanvasobject.transform;
        highscorethree = highscorethreeobject.AddComponent<Text>();
        highscorethree.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        highscorethree.fontSize = 50;
        recttransform = highscorethree.GetComponent<RectTransform>();
        recttransform.anchorMin = new Vector2(.5f, 1);
        recttransform.anchorMax = new Vector2(.5f, 1);
        recttransform.pivot = new Vector2(.5f, .5f); 
        recttransform.sizeDelta = new Vector2(100, 200);
        recttransform.localPosition = new Vector3(0, -50, 0);
        highscorethree.enabled = false;

        GameObject highscorefourobject = new GameObject();
        highscorefourobject.transform.parent = managercanvasobject.transform;
        highscorefour = highscorefourobject.AddComponent<Text>();
        highscorefour.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        highscorefour.fontSize = 50;
        recttransform = highscorefour.GetComponent<RectTransform>();
        recttransform.anchorMin = new Vector2(.5f, 1);
        recttransform.anchorMax = new Vector2(.5f, 1);
        recttransform.pivot = new Vector2(.5f, .5f); 
        recttransform.sizeDelta = new Vector2(100, 200);
        recttransform.localPosition = new Vector3(0, -90, 0);
        highscorefour.enabled = false;
        
        GameObject highscorefiveobject = new GameObject();
        highscorefiveobject.transform.parent = managercanvasobject.transform;
        highscorefive = highscorefiveobject.AddComponent<Text>();
        highscorefive.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        highscorefive.fontSize = 50;
        recttransform = highscorefive.GetComponent<RectTransform>();
        recttransform.anchorMin = new Vector2(.5f, 1);
        recttransform.anchorMax = new Vector2(.5f, 1);
        recttransform.pivot = new Vector2(.5f, .5f); 
        recttransform.sizeDelta = new Vector2(100, 200);
        recttransform.localPosition = new Vector3(0, -130, 0);
        highscorefive.enabled = false;
        
        GameObject highscoresixobject = new GameObject();
        highscoresixobject.transform.parent = managercanvasobject.transform;
        highscoresix = highscoresixobject.AddComponent<Text>();
        highscoresix.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        highscoresix.fontSize = 50;
        recttransform = highscoresix.GetComponent<RectTransform>();
        recttransform.anchorMin = new Vector2(.5f, 1);
        recttransform.anchorMax = new Vector2(.5f, 1);
        recttransform.pivot = new Vector2(.5f, .5f); 
        recttransform.sizeDelta = new Vector2(100, 200);
        recttransform.localPosition = new Vector3(0, -170, 0);
        highscoresix.enabled = false;
        
        GameObject highscoresevenobject = new GameObject();
        highscoresevenobject.transform.parent = managercanvasobject.transform;
        highscoreseven = highscoresevenobject.AddComponent<Text>();
        highscoreseven.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        highscoreseven.fontSize = 50;
        recttransform = highscoreseven.GetComponent<RectTransform>();
        recttransform.anchorMin = new Vector2(.5f, 1);
        recttransform.anchorMax = new Vector2(.5f, 1);
        recttransform.pivot = new Vector2(.5f, .5f); 
        recttransform.sizeDelta = new Vector2(100, 200);
        recttransform.localPosition = new Vector3(0, -210, 0);
        highscoreseven.enabled = false;
        
        GameObject highscoreeightobject = new GameObject();
        highscoreeightobject.transform.parent = managercanvasobject.transform;
        highscoreeight = highscoreeightobject.AddComponent<Text>();
        highscoreeight.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        highscoreeight.fontSize = 50;
        recttransform = highscoreeight.GetComponent<RectTransform>();
        recttransform.anchorMin = new Vector2(.5f, 1);
        recttransform.anchorMax = new Vector2(.5f, 1);
        recttransform.pivot = new Vector2(.5f, .5f); 
        recttransform.sizeDelta = new Vector2(100, 200);
        recttransform.localPosition = new Vector3(0, -250, 0);
        highscoreeight.enabled = false;
        
        GameObject highscorenineobject = new GameObject();
        highscorenineobject.transform.parent = managercanvasobject.transform;
        highscorenine = highscorenineobject.AddComponent<Text>();
        highscorenine.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        highscorenine.fontSize = 50;
        recttransform = highscorenine.GetComponent<RectTransform>();
        recttransform.anchorMin = new Vector2(.5f, 1);
        recttransform.anchorMax = new Vector2(.5f, 1);
        recttransform.pivot = new Vector2(.5f, .5f); 
        recttransform.sizeDelta = new Vector2(100, 200);
        recttransform.localPosition = new Vector3(0, -290, 0);
        highscorenine.enabled = false;
        
        GameObject highscoretenobject = new GameObject();
        highscoretenobject.transform.parent = managercanvasobject.transform;
        highscoreten = highscoretenobject.AddComponent<Text>();
        highscoreten.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        highscoreten.fontSize = 50;
        recttransform = highscoreten.GetComponent<RectTransform>();
        recttransform.anchorMin = new Vector2(.5f, 1);
        recttransform.anchorMax = new Vector2(.5f, 1);
        recttransform.pivot = new Vector2(.5f, .5f); 
        recttransform.sizeDelta = new Vector2(100, 200);
        recttransform.localPosition = new Vector3(0, -330, 0);
        highscoreten.enabled = false;
        
    }
    
    public void ChangeGuestLocations(int guestnumber, float guesttimer, GameObject target)
    {
        guesttimersrect[guestnumber].anchoredPosition = managercamera.WorldToScreenPoint(target.transform.position);
        guesttimerslidersrect[guestnumber].localScale = new Vector3(-1 * guesttimer/guestmanager.guestmaxtimer, 1, 1);
    }
}
