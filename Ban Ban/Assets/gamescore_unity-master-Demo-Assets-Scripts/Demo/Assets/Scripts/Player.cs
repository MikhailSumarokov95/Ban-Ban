using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using GameScore;

public class Player : MonoBehaviour
{
    public static Player Instance;

    private void Awake()
    {
        Instance = this;
    }

    [Space(25)]
    [SerializeField] private TMP_Text _id;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _goldText;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Dropdown _classDropdown;

    [SerializeField] private TMP_Dropdown _rankDropdown;
    [SerializeField] private Toggle _vip;

    [Space(25)]
    [SerializeField] private TMP_Text _staticNameText;
    [SerializeField] private TMP_Text _staticClassText;
    [SerializeField] private TMP_Text _staticRankText;
    [SerializeField] private TMP_Text _staticGoldText;
    [SerializeField] private TMP_Text _staticLevelText;
    [SerializeField] private TMP_Text _staticVipText;

    private float _goldCount;
    private int _level;
    private string _class;
    private int _rank;

    private void OnEnable()
    {
        GS_Player.OnPlayerReady += PlayerInit;
        GS_Language.OnChangeLanguage += OnLanguageChanged;

        GS_Player.OnPlayerFetchFieldsComplete += PlayerFetchFields;
    }

    private void OnDisable()
    {
        GS_Player.OnPlayerFetchFieldsComplete -= PlayerFetchFields;
        GS_Language.OnChangeLanguage -= OnLanguageChanged;
        GS_Player.OnPlayerReady -= PlayerInit;
    }
    private void PlayerInit()
    {

        GS_Player.FetchFields();

        Console.Instance.Log("\n --- Player Init --- ");

        if (GS_Player.Has("vip"))
            Console.Instance.Log("Player has VIP: YES");
        else
            Console.Instance.Log("Player has VIP: NO");

        Console.Instance.Log("PlayerID: " + GS_Player.GetID());
        Console.Instance.Log("Player Name: " + GS_Player.GetName());
        Console.Instance.Log("PlayerGetInt Level: " + GS_Player.GetInt("level").ToString());




        _id.text += GS_Player.GetID();
        _name.text = GS_Player.GetName();

        GS_Player.GetAvatar(_image);

        _level = GS_Player.GetInt("level");
        _goldCount = GS_Player.GetFloat("gold");

        _class = GS_Player.GetString("class");
        Console.Instance.Log("Player Get String - Class: " + GS_Player.GetString("class"));
        if (_class == "warrior")
            _classDropdown.value = 0;
        if (_class == "mage")
            _classDropdown.value = 1;
        if (_class == "robber")
            _classDropdown.value = 2;

        _rank = GS_Player.GetInt("rank");
        Console.Instance.Log("PlayerGetInt rank: " + GS_Player.GetInt("rank"));
        if (_rank == 0) //"Newble"
            _rankDropdown.value = 0;
        if (_rank == 1) //"Master"
            _rankDropdown.value = 1;
        if (_rank == 2) //"Pro"
            _rankDropdown.value = 2;

        _vip.isOn = GS_Player.GetBool("vip");

        UpdateTexts();
    }

    public void GoldPurchased()
    {
        _goldCount += 100000;
        GS_Player.Set("gold", _goldCount);
        _goldText.text = _goldCount.ToString();
        GS_Payments.Consume("EXTRA_GOLD");
    }

    public void VipPurchased()
    {
        GS_Player.Toggle("vip");
        _vip.isOn = true;
    }
    private void OnLanguageChanged(string language)
    {
        GS_Player.FetchFields();
    }
    public void SaveSync()
    {
        GS_Player.Sync();
    }
    public void AddLevel()
    {
        _level++;

        //SDK Params
        GS_Player.Add("level", _level);

        //Canvas
        _levelText.text = _level.ToString();
    }
    public void AddGold()
    {
        _goldCount += 20.5f;

        //SDK Params
        GS_Player.Set("gold", _goldCount);

        //Canvas
        _goldText.text = _goldCount.ToString();
    }



    public void OnRankChanged(int RankIndex)
    {
        if (RankIndex == 0)
            GS_Player.Set("rank", 0);
        if (RankIndex == 1)
            GS_Player.Set("rank", 1);
        if (RankIndex == 2)
            GS_Player.Set("rank", 2);
    }
    public void OnClassChanged(int ClassIndex)
    {
        // index: 0 - Воин
        if (ClassIndex == 0)
            GS_Player.Set("class", "warrior");
        if (ClassIndex == 1)
            GS_Player.Set("class", "mage");
        if (ClassIndex == 2)
            GS_Player.Set("class", "robber");
    }

    public void OnPlayerRemoveButtonClick()
    {
        Console.Instance.Log("\n --- Player Remove --- ");
        GS_Player.Remove();
        Reset_Remove();
    }
    public void OnResetButtonClick()
    {
        Console.Instance.Log("\n --- Player Reset --- ");
        GS_Player.ResetPlayer();
        Reset_Remove();

    }
    public void LoginPlayer()
    {
        GS_Player.Login();
    }
    public void OnVipChanged(bool Vip)
    {
        if (Vip)
        {
            GS_Player.Toggle("vip");
        }
        if (!Vip)
        {
            GS_Player.Set("vip", false);
        }
    }

    private void PlayerFetchFields(List<PlayerFetchFieldsData> playerFetchData)
    {
        for (int i = 0; i < playerFetchData.Count; i++)
        {
            switch (playerFetchData[i].name)
            {
                case "Name":
                    _staticNameText.text = playerFetchData[i].name;
                    break;

                case "Rank":
                    _staticRankText.text = playerFetchData[i].name;
                    for (int x = 0; x < _rankDropdown.options.Count; x++)
                    {
                        _rankDropdown.options[x].text = playerFetchData[i].variants[x].name;
                    }
                    break;

                case "Class":
                    _staticClassText.text = playerFetchData[i].name;

                    for (int x = 0; x < _classDropdown.options.Count; x++)
                    {
                        _classDropdown.options[x].text = playerFetchData[i].variants[x].name;
                    }
                    break;

                case "Level":
                    _staticLevelText.text = playerFetchData[i].name;
                    break;

                case "Gold":
                    _staticGoldText.text = playerFetchData[i].name;
                    break;


                case "Vip":
                    _staticVipText.text = playerFetchData[i].name;
                    break;
            }
        }
    }
    private void Reset_Remove()
    {
        _classDropdown.value = 0;
        _rankDropdown.value = 0;
        _level = 0;
        _goldCount = 0;
        _vip.isOn = false;
        UpdateTexts();
    }
    private void UpdateTexts()
    {
        _levelText.text = _level.ToString();
        _goldText.text = _goldCount.ToString();
    }
}
