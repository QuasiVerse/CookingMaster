using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GenerateHUD : MonoBehaviour
{      

    public Canvas managercanvas;
    
    
    private Text choosenumberplayers;
    
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
    
    public void ChooseOnePlayer()
    {
        chooseonebuttonimage.enabled = false;
        chooseonebutton.enabled = false;
        chooseonebuttontext.enabled = false;
        choosetwobuttonimage.enabled = false;
        choosetwobutton.enabled = false;
        choosetwobuttontext.enabled = false;
        choosenumberplayers.enabled = false;
        PlayerGenerator.playerone.SetActive(true);
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
        PlayerGenerator.playerone.SetActive(true);
        PlayerGenerator.playertwo.SetActive(true);
    }
    
    public void GenerateCanvas()
    {
        GameObject managercanvasobject;
        RectTransform rectTransform;
        Sprite circlesprite = (Sprite)AssetDatabase.GetBuiltinExtraResource(typeof(Sprite), "UI/Skin/Knob.psd");

        // Canvas
        managercanvasobject = new GameObject();
        managercanvasobject.name = "TestCanvas";
        managercanvasobject.AddComponent<Canvas>();
        
        managercanvas = managercanvasobject.GetComponent<Canvas>();
        managercanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        managercanvasobject.AddComponent<CanvasScaler>();
        managercanvasobject.AddComponent<GraphicRaycaster>();
        
        //Choose Number Of Players
        
        GameObject choosenumberplayersobject = new GameObject();
        choosenumberplayersobject.transform.parent = managercanvasobject.transform;
        choosenumberplayers = choosenumberplayersobject.AddComponent<Text>();
        choosenumberplayers.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        choosenumberplayers.fontSize = 15;
        choosenumberplayers.text = "CHOOSE NUMBER OF PLAYERS";
        rectTransform = choosenumberplayers.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(.5f, 1);
        rectTransform.anchorMax = new Vector2(.5f, 1);
        rectTransform.pivot = new Vector2(0, 1); 
        rectTransform.sizeDelta = new Vector2(400, 200);
        rectTransform.localPosition = new Vector3(-215, 0, 0);
        
        GameObject chooseonebuttonobject = new GameObject();
        chooseonebuttonobject.transform.parent = managercanvasobject.transform;
        chooseonebuttonimage = chooseonebuttonobject.AddComponent<Image>();
        chooseonebuttonimage.sprite = circlesprite;
        chooseonebutton = chooseonebuttonobject.AddComponent<Button>();
        chooseonebutton.onClick.AddListener(ChooseOnePlayer);
        rectTransform = chooseonebutton.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-500, 200, 0);
        rectTransform.sizeDelta = new Vector2(400, 400);
        rectTransform.anchorMin = new Vector2(.5f, .5f);
        rectTransform.anchorMax = new Vector2(.5f, .5f);
        rectTransform.pivot = new Vector2(0, 1); 
        Material newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.5f, .5f, .5f, 1));
        chooseonebuttonimage.material = newmaterial;
        
        GameObject chooseonebuttontextobject = new GameObject();
        chooseonebuttontextobject.transform.parent = chooseonebuttonobject.transform;
        chooseonebuttontext = chooseonebuttontextobject.AddComponent<Text>();
        chooseonebuttontext.text = "1";
        chooseonebuttontext.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        chooseonebuttontext.fontSize = 175;
        rectTransform = chooseonebuttontext.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);
        rectTransform.pivot = new Vector2(0, 1);  
        rectTransform.localPosition = new Vector3(145, -100, 0);
        rectTransform.sizeDelta = new Vector2(200, 200);
        
        GameObject choosetwobuttonobject = new GameObject();
        choosetwobuttonobject.transform.parent = managercanvasobject.transform;
        choosetwobuttonimage = choosetwobuttonobject.AddComponent<Image>();
        choosetwobuttonimage.sprite = circlesprite;
        choosetwobutton = choosetwobuttonobject.AddComponent<Button>();
        choosetwobutton.onClick.AddListener(ChooseTwoPlayer);
        rectTransform = choosetwobutton.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(75, 200, 0);
        rectTransform.sizeDelta = new Vector2(400, 400);
        rectTransform.anchorMin = new Vector2(.5f, .5f);
        rectTransform.anchorMax = new Vector2(.5f, .5f);
        rectTransform.pivot = new Vector2(0, 1); 
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.5f, .5f, .5f, 1));
        choosetwobuttonimage.material = newmaterial;
        
        GameObject choosetwobuttontextobject = new GameObject();
        choosetwobuttontextobject.transform.parent = choosetwobuttonobject.transform;
        choosetwobuttontext = choosetwobuttontextobject.AddComponent<Text>();
        choosetwobuttontext.text = "2";
        choosetwobuttontext.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        choosetwobuttontext.fontSize = 175;
        rectTransform = choosetwobuttontext.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);
        rectTransform.pivot = new Vector2(0, 1);  
        rectTransform.localPosition = new Vector3(145, -100, 0);
        rectTransform.sizeDelta = new Vector2(200, 200);
        

        //Player One Timer
        GameObject playeronetimertextobject = new GameObject();
        playeronetimertextobject.transform.parent = managercanvasobject.transform;
        playeronetimertext = playeronetimertextobject.AddComponent<Text>();
        playeronetimertext.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        playeronetimertext.fontSize = 15;
        rectTransform = playeronetimertext.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(5, -20, 0);
        rectTransform.sizeDelta = new Vector2(400, 200);
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);
        rectTransform.pivot = new Vector2(0, 1);    
        
        //Player One Score
        GameObject playeronescoretextobject = new GameObject();
        playeronescoretextobject.transform.parent = managercanvasobject.transform;
        playeronescoretext = playeronescoretextobject.AddComponent<Text>();
        playeronescoretext.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        playeronescoretext.fontSize = 15;
        rectTransform = playeronescoretext.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(5, -40, 0);
        rectTransform.sizeDelta = new Vector2(400, 200);
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);
        rectTransform.pivot = new Vector2(0, 1);   
        
        //Player One Slot One
        GameObject playeroneslotoneeggplantobject = new GameObject();
        playeroneslotoneeggplantobject.name = "Eggplant";
        playeroneslotoneeggplantobject.transform.parent = managercanvasobject.transform;
        playeroneslotoneeggplant = playeroneslotoneeggplantobject.AddComponent<Image>();
        playeroneslotoneeggplant.sprite = circlesprite;
        rectTransform = playeroneslotoneeggplant.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -75, 0);
        rectTransform.sizeDelta = new Vector2(125, 50);
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);
        rectTransform.pivot = new Vector2(0, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.6f, .2f, .6f, 1));
        playeroneslotoneeggplant.material = newmaterial;
        playeroneslotoneeggplant.enabled = false;
        
        GameObject playeroneslotonetomatoobject = new GameObject();
        playeroneslotonetomatoobject.name = "Tomato";
        playeroneslotonetomatoobject.transform.parent = managercanvasobject.transform;
        playeroneslotonetomato = playeroneslotonetomatoobject.AddComponent<Image>();
        playeroneslotonetomato.sprite = circlesprite;
        rectTransform = playeroneslotonetomato.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(37.5f, -75, 0);
        rectTransform.sizeDelta = new Vector2(50, 50);
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);
        rectTransform.pivot = new Vector2(0, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(1 ,0, 0, 1));
        playeroneslotonetomato.material = newmaterial;
        playeroneslotonetomato.enabled = false;
        
        GameObject playeroneslotonezucciniobject = new GameObject();
        playeroneslotonezucciniobject.name = "Zuccini";
        playeroneslotonezucciniobject.transform.parent = managercanvasobject.transform;
        playeroneslotonezuccini = playeroneslotonezucciniobject.AddComponent<Image>();
        playeroneslotonezuccini.sprite = circlesprite;
        rectTransform = playeroneslotonezuccini.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -75, 0);
        rectTransform.sizeDelta = new Vector2(125, 50);
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);
        rectTransform.pivot = new Vector2(0, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.2f, .4f, .2f, 1));
        playeroneslotonezuccini.material = newmaterial;
        playeroneslotonezuccini.enabled = false;
        
        GameObject playeroneslotonepotatoobject = new GameObject();
        playeroneslotonepotatoobject.name = "Potato";
        playeroneslotonepotatoobject.transform.parent = managercanvasobject.transform;
        playeroneslotonepotato = playeroneslotonepotatoobject.AddComponent<Image>();
        playeroneslotonepotato.sprite = circlesprite;
        rectTransform = playeroneslotonepotato.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(37.5f, -75, 0);
        rectTransform.sizeDelta = new Vector2(50, 50);
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);
        rectTransform.pivot = new Vector2(0, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.8f, .8f, .4f, 1));
        playeroneslotonepotato.material = newmaterial;
        playeroneslotonepotato.enabled = false;
        
        GameObject playeroneslotonecornobject = new GameObject();
        playeroneslotonecornobject.name = "Corn";
        playeroneslotonecornobject.transform.parent = managercanvasobject.transform;
        playeroneslotonecorn = playeroneslotonecornobject.AddComponent<Image>();
        playeroneslotonecorn.sprite = circlesprite;
        rectTransform = playeroneslotonecorn.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -75, 0);
        rectTransform.sizeDelta = new Vector2(125, 50);
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);
        rectTransform.pivot = new Vector2(0, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.9f, .9f, .1f, 1));
        playeroneslotonecorn.material = newmaterial;
        playeroneslotonecorn.enabled = false;
        
        GameObject playeroneslotonelettuceobject = new GameObject();
        playeroneslotonelettuceobject.name = "Lettuce";
        playeroneslotonelettuceobject.transform.parent = managercanvasobject.transform;
        playeroneslotonelettuce = playeroneslotonelettuceobject.AddComponent<Image>();
        playeroneslotonelettuce.sprite = circlesprite;
        rectTransform = playeroneslotonelettuce.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(37.5f, -75, 0);
        rectTransform.sizeDelta = new Vector2(50, 50);
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);
        rectTransform.pivot = new Vector2(0, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.22f, .5f, .22f, 1));
        playeroneslotonelettuce.material = newmaterial;
        playeroneslotonelettuce.enabled = false;
        
        //Player One Slot Two
        GameObject playeroneslottwoeggplantobject = new GameObject();
        playeroneslottwoeggplantobject.name = "Eggplant";
        playeroneslottwoeggplantobject.transform.parent = managercanvasobject.transform;
        playeroneslottwoeggplant = playeroneslottwoeggplantobject.AddComponent<Image>();
        playeroneslottwoeggplant.sprite = circlesprite;
        rectTransform = playeroneslottwoeggplant.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -125, 0);
        rectTransform.sizeDelta = new Vector2(125, 50);
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);
        rectTransform.pivot = new Vector2(0, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.6f, .2f, .6f, 1));
        playeroneslottwoeggplant.material = newmaterial;
        playeroneslottwoeggplant.enabled = false;
        
        GameObject playeroneslottwotomatoobject = new GameObject();
        playeroneslottwotomatoobject.name = "Tomato";
        playeroneslottwotomatoobject.transform.parent = managercanvasobject.transform;
        playeroneslottwotomato = playeroneslottwotomatoobject.AddComponent<Image>();
        playeroneslottwotomato.sprite = circlesprite;
        rectTransform = playeroneslottwotomato.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(37.5f, -125, 0);
        rectTransform.sizeDelta = new Vector2(50, 50);
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);
        rectTransform.pivot = new Vector2(0, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(1 ,0, 0, 1));
        playeroneslottwotomato.material = newmaterial;
        playeroneslottwotomato.enabled = false;
        
        GameObject playeroneslottwozucciniobject = new GameObject();
        playeroneslottwozucciniobject.name = "Zuccini";
        playeroneslottwozucciniobject.transform.parent = managercanvasobject.transform;
        playeroneslottwozuccini = playeroneslottwozucciniobject.AddComponent<Image>();
        playeroneslottwozuccini.sprite = circlesprite;
        rectTransform = playeroneslottwozuccini.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -125, 0);
        rectTransform.sizeDelta = new Vector2(125, 50);
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);
        rectTransform.pivot = new Vector2(0, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.2f, .4f, .2f, 1));
        playeroneslottwozuccini.material = newmaterial;
        playeroneslottwozuccini.enabled = false;
        
        GameObject playeroneslottwopotatoobject = new GameObject();
        playeroneslottwopotatoobject.name = "Potato";
        playeroneslottwopotatoobject.transform.parent = managercanvasobject.transform;
        playeroneslottwopotato = playeroneslottwopotatoobject.AddComponent<Image>();
        playeroneslottwopotato.sprite = circlesprite;
        rectTransform = playeroneslottwopotato.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(37.5f, -125, 0);
        rectTransform.sizeDelta = new Vector2(50, 50);
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);
        rectTransform.pivot = new Vector2(0, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.8f, .8f, .4f, 1));
        playeroneslottwopotato.material = newmaterial;
        playeroneslottwopotato.enabled = false;
        
        GameObject playeroneslottwocornobject = new GameObject();
        playeroneslottwocornobject.name = "Corn";
        playeroneslottwocornobject.transform.parent = managercanvasobject.transform;
        playeroneslottwocorn = playeroneslottwocornobject.AddComponent<Image>();
        playeroneslottwocorn.sprite = circlesprite;
        rectTransform = playeroneslottwocorn.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -125, 0);
        rectTransform.sizeDelta = new Vector2(125, 50);
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);
        rectTransform.pivot = new Vector2(0, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.9f, .9f, .1f, 1));
        playeroneslottwocorn.material = newmaterial;
        playeroneslottwocorn.enabled = false;
        
        GameObject playeroneslottwolettuceobject = new GameObject();
        playeroneslottwolettuceobject.name = "Lettuce";
        playeroneslottwolettuceobject.transform.parent = managercanvasobject.transform;
        playeroneslottwolettuce = playeroneslottwolettuceobject.AddComponent<Image>();
        playeroneslottwolettuce.sprite = circlesprite;
        rectTransform = playeroneslottwolettuce.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(37.5f, -125, 0);
        rectTransform.sizeDelta = new Vector2(50, 50);
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);
        rectTransform.pivot = new Vector2(0, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.22f, .5f, .22f, 1));
        playeroneslottwolettuce.material = newmaterial;
        playeroneslottwolettuce.enabled = false;
        
        
        //Player Two Slot One
        GameObject playertwoslotoneeggplantobject = new GameObject();
        playeroneslottwoeggplantobject.name = "Eggplant";
        playertwoslotoneeggplantobject.transform.parent = managercanvasobject.transform;
        playertwoslotoneeggplant = playertwoslotoneeggplantobject.AddComponent<Image>();
        playertwoslotoneeggplant.sprite = circlesprite;
        rectTransform = playertwoslotoneeggplant.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -75, 0);
        rectTransform.sizeDelta = new Vector2(125, 50);
        rectTransform.anchorMin = new Vector2(1, 1);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.pivot = new Vector2(1, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.6f, .2f, .6f, 1));
        playertwoslotoneeggplant.material = newmaterial;
        playertwoslotoneeggplant.enabled = false;
        
        GameObject playertwoslotonetomatoobject = new GameObject();
        playeroneslottwoeggplantobject.name = "Eggplant";
        playertwoslotonetomatoobject.transform.parent = managercanvasobject.transform;
        playertwoslotonetomato = playertwoslotonetomatoobject.AddComponent<Image>();
        playertwoslotonetomato.sprite = circlesprite;
        rectTransform = playertwoslotonetomato.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-37.5f, -75, 0);
        rectTransform.sizeDelta = new Vector2(50, 50);
        rectTransform.anchorMin = new Vector2(1, 1);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.pivot = new Vector2(1, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(1 ,0, 0, 1));
        playertwoslotonetomato.material = newmaterial;
        playertwoslotonetomato.enabled = false;
        
        GameObject playertwoslotonezucciniobject = new GameObject();
        playeroneslottwoeggplantobject.name = "Eggplant";
        playertwoslotonezucciniobject.transform.parent = managercanvasobject.transform;
        playertwoslotonezuccini = playertwoslotonezucciniobject.AddComponent<Image>();
        playertwoslotonezuccini.sprite = circlesprite;
        rectTransform = playertwoslotonezuccini.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -75, 0);
        rectTransform.sizeDelta = new Vector2(125, 50);
        rectTransform.anchorMin = new Vector2(1, 1);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.pivot = new Vector2(1, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.2f, .4f, .2f, 1));
        playertwoslotonezuccini.material = newmaterial;
        playertwoslotonezuccini.enabled = false;
        
        GameObject playertwoslotonepotatoobject = new GameObject();
        playeroneslottwoeggplantobject.name = "Eggplant";
        playertwoslotonepotatoobject.transform.parent = managercanvasobject.transform;
        playertwoslotonepotato = playertwoslotonepotatoobject.AddComponent<Image>();
        playertwoslotonepotato.sprite = circlesprite;
        rectTransform = playertwoslotonepotato.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-37.5f, -75, 0);
        rectTransform.sizeDelta = new Vector2(50, 50);
        rectTransform.anchorMin = new Vector2(1, 1);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.pivot = new Vector2(1, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.8f, .8f, .4f, 1));
        playertwoslotonepotato.material = newmaterial;
        playertwoslotonepotato.enabled = false;
        
        GameObject playertwoslotonecornobject = new GameObject();
        playeroneslottwoeggplantobject.name = "Eggplant";
        playertwoslotonecornobject.transform.parent = managercanvasobject.transform;
        playertwoslotonecorn = playertwoslotonecornobject.AddComponent<Image>();
        playertwoslotonecorn.sprite = circlesprite;
        rectTransform = playertwoslotonecorn.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -75, 0);
        rectTransform.sizeDelta = new Vector2(125, 50);
        rectTransform.anchorMin = new Vector2(1, 1);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.pivot = new Vector2(1, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.9f, .9f, .1f, 1));
        playertwoslotonecorn.material = newmaterial;
        playertwoslotonecorn.enabled = false;
        
        GameObject playertwoslotonelettuceobject = new GameObject();
        playeroneslottwoeggplantobject.name = "Eggplant";
        playertwoslotonelettuceobject.transform.parent = managercanvasobject.transform;
        playertwoslotonelettuce = playertwoslotonelettuceobject.AddComponent<Image>();
        playertwoslotonelettuce.sprite = circlesprite;
        rectTransform = playertwoslotonelettuce.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-37.5f, -75, 0);
        rectTransform.sizeDelta = new Vector2(50, 50);
        rectTransform.anchorMin = new Vector2(1, 1);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.pivot = new Vector2(1, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.22f, .5f, .22f, 1));
        playertwoslotonelettuce.material = newmaterial;
        playertwoslotonelettuce.enabled = false;
        
        //Player Two Slot Two
        GameObject playertwoslottwoeggplantobject = new GameObject();
        playertwoslottwoeggplantobject.name = "Eggplant";
        playertwoslottwoeggplantobject.transform.parent = managercanvasobject.transform;
        playertwoslottwoeggplant = playertwoslottwoeggplantobject.AddComponent<Image>();
        playertwoslottwoeggplant.sprite = circlesprite;
        rectTransform = playertwoslottwoeggplant.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -125, 0);
        rectTransform.sizeDelta = new Vector2(125, 50);
        rectTransform.anchorMin = new Vector2(1, 1);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.pivot = new Vector2(1, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.6f, .2f, .6f, 1));
        playertwoslottwoeggplant.material = newmaterial;
        playertwoslottwoeggplant.enabled = false;
        
        GameObject playertwoslottwotomatoobject = new GameObject();
        playertwoslottwotomatoobject.name = "Tomato";
        playertwoslottwotomatoobject.transform.parent = managercanvasobject.transform;
        playertwoslottwotomato = playertwoslottwotomatoobject.AddComponent<Image>();
        playertwoslottwotomato.sprite = circlesprite;
        rectTransform = playertwoslottwotomato.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-37.5f, -125, 0);
        rectTransform.sizeDelta = new Vector2(50, 50);
        rectTransform.anchorMin = new Vector2(1, 1);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.pivot = new Vector2(1, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(1 ,0, 0, 1));
        playertwoslottwotomato.material = newmaterial;
        playertwoslottwotomato.enabled = false;
        
        GameObject playertwoslottwozucciniobject = new GameObject();
        playertwoslottwozucciniobject.name = "Zuccini";
        playertwoslottwozucciniobject.transform.parent = managercanvasobject.transform;
        playertwoslottwozuccini = playertwoslottwozucciniobject.AddComponent<Image>();
        playertwoslottwozuccini.sprite = circlesprite;
        rectTransform = playertwoslottwozuccini.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -125, 0);
        rectTransform.sizeDelta = new Vector2(125, 50);
        rectTransform.anchorMin = new Vector2(1, 1);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.pivot = new Vector2(1, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.2f, .4f, .2f, 1));
        playertwoslottwozuccini.material = newmaterial;
        playertwoslottwozuccini.enabled = false;
        
        GameObject playertwoslottwopotatoobject = new GameObject();
        playertwoslottwopotatoobject.name = "Potato";
        playertwoslottwopotatoobject.transform.parent = managercanvasobject.transform;
        playertwoslottwopotato = playertwoslottwopotatoobject.AddComponent<Image>();
        playertwoslottwopotato.sprite = circlesprite;
        rectTransform = playertwoslottwopotato.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-37.5f, -125, 0);
        rectTransform.sizeDelta = new Vector2(50, 50);
        rectTransform.anchorMin = new Vector2(1, 1);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.pivot = new Vector2(1, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.8f, .8f, .4f, 1));
        playertwoslottwopotato.material = newmaterial;
        playertwoslottwopotato.enabled = false;
        
        GameObject playertwoslottwocornobject = new GameObject();
        playertwoslottwocornobject.name = "Corn";
        playertwoslottwocornobject.transform.parent = managercanvasobject.transform;
        playertwoslottwocorn = playertwoslottwocornobject.AddComponent<Image>();
        playertwoslottwocorn.sprite = circlesprite;
        rectTransform = playertwoslottwocorn.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -125, 0);
        rectTransform.sizeDelta = new Vector2(125, 50);
        rectTransform.anchorMin = new Vector2(1, 1);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.pivot = new Vector2(1, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.9f, .9f, .1f, 1));
        playertwoslottwocorn.material = newmaterial;
        playertwoslottwocorn.enabled = false;
        
        GameObject playertwoslottwolettuceobject = new GameObject();
        playertwoslottwolettuceobject.name = "Lettuce";
        playertwoslottwolettuceobject.transform.parent = managercanvasobject.transform;
        playertwoslottwolettuce = playertwoslottwolettuceobject.AddComponent<Image>();
        playertwoslottwolettuce.sprite = circlesprite;
        rectTransform = playertwoslottwolettuce.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-37.5f, -125, 0);
        rectTransform.sizeDelta = new Vector2(50, 50);
        rectTransform.anchorMin = new Vector2(1, 1);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.pivot = new Vector2(1, 1);
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        newmaterial.SetColor("_Color", new Color(.22f, .5f, .22f, 1));
        playertwoslottwolettuce.material = newmaterial;
        playertwoslottwolettuce.enabled = false;
        
    }
}