using UnityEngine;
using TMPro;
using System.Collections.Generic;
using GameScore;
public class Console : MonoBehaviour
{
    [SerializeField] private TMP_Text _console;
    public static Console Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void OnEnable()
    {
        GS_SDK.OnReady += OnSDKReady;
        GS_Player.OnPlayerReady += OnReady;

        GS_Player.OnPlayerChange += OnPlayerChange;

        GS_Player.OnPlayerSyncComplete += OnPlayerSyncComplete;
        GS_Player.OnPlayerSyncError += OnPlayerSyncError;
        GS_Player.OnPlayerLoadComplete += OnPlayerLoadComplete;
        GS_Player.OnPlayerLoadError += OnPlayerLoadError;
        GS_Player.OnPlayerLoginComplete += OnPlayerLoginComplete;
        GS_Player.OnPlayerLoginError += OnPlayerLoginError;
        GS_Player.OnPlayerFetchFieldsComplete += OnPlayerFetchFieldsComplete;
        GS_Player.OnPlayerFetchFieldsError += OnPlayerFetchFieldsError;

        GS_Fullscreen.OnFullscreenOpen += OnFullscreenOpen;
        GS_Fullscreen.OnFullscreenClose += OnFullscreenClose;
        GS_Fullscreen.OnFullscreenChange += OnFullscreenChange;

        GS_Ads.OnAdsStart += OnAdsStart;
        GS_Ads.OnAdsClose += OnAdsClose;
        GS_Ads.OnFullscreenStart += OnAdsFullscreenStart;
        GS_Ads.OnFullscreenClose += OnAdsFullscreenClose;
        GS_Ads.OnPreloaderStart += OnAdsPreloaderStart;
        GS_Ads.OnPreloaderClose += OnAdsPreloaderClose;
        GS_Ads.OnRewardedStart += OnAdsRewardedStart;
        GS_Ads.OnRewardedClose += OnAdsRewardedClose;
        GS_Ads.OnRewardedReward += OnRewarded;
        GS_Ads.OnStickyStart += OnAdsStickyStart;
        GS_Ads.OnStickyClose += OnAdsStickyClose;
        GS_Ads.OnStickyRefresh += OnAdsStickyRefresh;
        GS_Ads.OnStickyRender += OnAdsStickyRender;

        GS_Socials.OnShare += OnSocialsShare;
        GS_Socials.OnPost += OnSocialsPost;
        GS_Socials.OnInvite += OnSocialsInvite;
        GS_Socials.OnJoinCommunity += OnSocialsJoinCommunity;

        GS_Language.OnChangeLanguage += OnChangeLanguage;

        GS_AvatarGenerator.OnChangeAvatarGenerator += OnChangeAvatarGenerator;

        GS_Leaderboard.OnLeaderboardOpen += OnLeaderboardOpen;
        GS_Leaderboard.OnLeaderboardFetch += OnLeaderboardFetch;
        GS_Leaderboard.OnLeaderboardFetchError += OnLeaderboardFetchError;
        GS_Leaderboard.OnLeaderboardFetchPlayer += OnLeaderboardFetchPlayer;
        GS_Leaderboard.OnLeaderboardFetchPlayerError += OnLeaderboardFetchPlayerError;

        GS_Achievements.OnAchievementsOpen += OnAchievementsOpen;
        GS_Achievements.OnAchievementsClose += OnAchievementsClose;
        GS_Achievements.OnAchievementsUnlockError += OnAchievementsUnlockError;
        GS_Achievements.OnAchievementsFetch += OnAchievementsFetch;
        GS_Achievements.OnAchievementsFetchError += OnAchievementsFetchError;
        GS_Achievements.OnAchievementsUnlock += OnAchievementsUnlock;

        GS_Payments.OnPaymentsFetchProducts += OnPaymentsFetchProducts;
        GS_Payments.OnPaymentsFetchPlayerPurcahses += OnPaymentsFetchPlayerPurcahses;
        GS_Payments.OnPaymentsFetchProductsError += OnPaymentsFetchProductsError;
        GS_Payments.OnPaymentsPurchase += OnPaymentsPurchase;
        GS_Payments.OnPaymentsPurchaseError += OnPaymentsPurchaseError;
        GS_Payments.OnPaymentsConsume += OnPaymentsConsume;
        GS_Payments.OnPaymentsConsumeError += OnPaymentsConsumeError;

        GS_GamesCollections.OnGamesCollectionsOpen += OnGamesCollectionsOpen;
        GS_GamesCollections.OnGamesCollectionsClose += OnGamesCollectionsClose;
        GS_GamesCollections.OnGamesCollectionsFetch += OnGamesCollectionsFetch;
        GS_GamesCollections.OnGamesCollectionsFetchError += OnGamesCollectionsFetchError;

        GS_Game.OnPause += GamePaused;
        GS_Game.OnResume += GameResumed;
    }

    private void OnDisable()
    {
        GS_SDK.OnReady -= OnSDKReady;

        GS_Player.OnPlayerReady -= OnReady;

        GS_Player.OnPlayerChange -= OnPlayerChange;

        GS_Player.OnPlayerSyncComplete -= OnPlayerSyncComplete;
        GS_Player.OnPlayerSyncError -= OnPlayerSyncError;
        GS_Player.OnPlayerLoadComplete -= OnPlayerLoadComplete;
        GS_Player.OnPlayerLoadError -= OnPlayerLoadError;
        GS_Player.OnPlayerLoginComplete -= OnPlayerLoginComplete;
        GS_Player.OnPlayerLoginError -= OnPlayerLoginError;
        GS_Player.OnPlayerFetchFieldsComplete -= OnPlayerFetchFieldsComplete;
        GS_Player.OnPlayerFetchFieldsError -= OnPlayerFetchFieldsError;

        GS_Fullscreen.OnFullscreenOpen -= OnFullscreenOpen;
        GS_Fullscreen.OnFullscreenClose -= OnFullscreenClose;
        GS_Fullscreen.OnFullscreenChange -= OnFullscreenChange;

        GS_Ads.OnAdsStart -= OnAdsStart;
        GS_Ads.OnAdsClose -= OnAdsClose;
        GS_Ads.OnFullscreenStart -= OnAdsFullscreenStart;
        GS_Ads.OnFullscreenClose -= OnAdsFullscreenClose;
        GS_Ads.OnPreloaderStart -= OnAdsPreloaderStart;
        GS_Ads.OnPreloaderClose -= OnAdsPreloaderClose;
        GS_Ads.OnRewardedStart -= OnAdsRewardedStart;
        GS_Ads.OnRewardedClose -= OnAdsRewardedClose;
        GS_Ads.OnRewardedReward -= OnRewarded;
        GS_Ads.OnStickyStart -= OnAdsStickyStart;
        GS_Ads.OnStickyClose -= OnAdsStickyClose;
        GS_Ads.OnStickyRefresh -= OnAdsStickyRefresh;
        GS_Ads.OnStickyRender -= OnAdsStickyRender;

        GS_Socials.OnShare -= OnSocialsShare;
        GS_Socials.OnPost -= OnSocialsPost;
        GS_Socials.OnInvite -= OnSocialsInvite;
        GS_Socials.OnJoinCommunity -= OnSocialsJoinCommunity;

        GS_Language.OnChangeLanguage -= OnChangeLanguage;

        GS_AvatarGenerator.OnChangeAvatarGenerator -= OnChangeAvatarGenerator;


        GS_Leaderboard.OnLeaderboardOpen -= OnLeaderboardOpen;
        GS_Leaderboard.OnLeaderboardFetch -= OnLeaderboardFetch;
        GS_Leaderboard.OnLeaderboardFetchError -= OnLeaderboardFetchError;
        GS_Leaderboard.OnLeaderboardFetchPlayer -= OnLeaderboardFetchPlayer;
        GS_Leaderboard.OnLeaderboardFetchPlayerError -= OnLeaderboardFetchPlayerError;

        GS_Achievements.OnAchievementsOpen -= OnAchievementsOpen;
        GS_Achievements.OnAchievementsClose -= OnAchievementsClose;
        GS_Achievements.OnAchievementsUnlockError += OnAchievementsUnlockError;
        GS_Achievements.OnAchievementsFetch -= OnAchievementsFetch;
        GS_Achievements.OnAchievementsFetchGroups -= OnAchievementsFetchGroups;
        GS_Achievements.OnAchievementsFetchPlayer -= OnAchievementsFetchPlayer;

        GS_Achievements.OnAchievementsFetchError -= OnAchievementsFetchError;
        GS_Achievements.OnAchievementsUnlock -= OnAchievementsUnlock;

        GS_Payments.OnPaymentsFetchProducts -= OnPaymentsFetchProducts;
        GS_Payments.OnPaymentsFetchPlayerPurcahses += OnPaymentsFetchPlayerPurcahses;
        GS_Payments.OnPaymentsFetchProductsError -= OnPaymentsFetchProductsError;
        GS_Payments.OnPaymentsPurchase -= OnPaymentsPurchase;
        GS_Payments.OnPaymentsPurchaseError -= OnPaymentsPurchaseError;
        GS_Payments.OnPaymentsConsume -= OnPaymentsConsume;
        GS_Payments.OnPaymentsConsumeError -= OnPaymentsConsumeError;

        GS_GamesCollections.OnGamesCollectionsOpen -= OnGamesCollectionsOpen;
        GS_GamesCollections.OnGamesCollectionsClose -= OnGamesCollectionsClose;
        GS_GamesCollections.OnGamesCollectionsFetch -= OnGamesCollectionsFetch;
        GS_GamesCollections.OnGamesCollectionsFetchError -= OnGamesCollectionsFetchError;
    }

    private void OnSDKReady()
    {
        Log("GameScore: Ready");
    }

    // --- -> GS_Player <- ---
    private void OnPlayerChange()
    {
        Log("\n GS_Player change");
    }

    private void OnPlayerFetchFieldsComplete(List<PlayerFetchFieldsData> playerFetchFields)
    {
        Log("\n --- GS_Player Fetch Fields --- ");


        for (int i = 0; i < playerFetchFields.Count; i++)
        {
            Log($" ---------------");

            Log($" Name: {playerFetchFields[i].name}");
            Log($" Key: {playerFetchFields[i].key}");
            Log($" Type: {playerFetchFields[i].type}");
            Log($" Default: {playerFetchFields[i].defaultValue}");
            Log($" Important: {playerFetchFields[i].important}");

            for (int x = 0; x < playerFetchFields[i].variants.Length; x++)
            {
                Log($" Variants - value: {playerFetchFields[i].variants[x].value}");
                Log($" Variants - name: {playerFetchFields[i].variants[x].name}");
            }
        }
    }
    private void OnPlayerFetchFieldsError()
    {
        Log("\n GS_Player Fetch Fields: Error");
    }

    private void OnPlayerLoginComplete()
    {
        Log("\n GS_Player Login: Complite");
    }
    private void OnPlayerLoginError()
    {
        Log("\n GS_Player Login: Error");
    }

    private void OnPlayerLoadComplete()
    {
        Log("\n GS_Player Load: Complite");
    }
    private void OnPlayerLoadError()
    {
        Log("\n GS_Player Load: Error");
    }

    private void OnPlayerSyncError()
    {
        Log("\n GS_Player Sync: Error");
    }
    private void OnPlayerSyncComplete()
    {
        Log("\n GS_Player Sync: Complite");
    }



    // --- -> GS_Payments <- ---
    private void OnPaymentsConsumeError()
    {
        Log("\n  GS_Payments: Purchase Consume Error");
    }

    private void OnPaymentsConsume(string idOrTag)
    {
        Log($"GS_Payments consume tag: {idOrTag}");
        Log("\n  GS_Payments: Purchase Consume");
    }

    private void OnPaymentsPurchaseError()
    {
        Log("\n  GS_Payments: Purchase Error");
    }

    private void OnPaymentsPurchase(string purchasedIdOrTag)
    {
        Log($"GS_Payments Purchase Tag: {purchasedIdOrTag}");
    }

    private void OnPaymentsFetchProductsError()
    {
        Log("\n  GS_Payments: Fetch Products Error");
    }

    private void OnPaymentsFetchProducts(List<FetchProducts> products)
    {
        Log("\n --- GS_Payments Fetch Products --- ");

        for (int i = 0; i < products.Count; i++)
        {
            Log($"--------------- ");
            Log($"Product: {i}");


            Log($"Product ID: {products[i].id}");
            Log($"Product icon: {products[i].icon}");
            Log($"Product icon small: {products[i].iconSmall}");
            Log($"Product tag: {products[i].tag}");
            Log($"Product price: {products[i].price}");
            Log($"Product name: {products[i].name}");
            Log($"Product description: {products[i].description}");
            Log($"Product yandexId: {products[i].yandexId}");
            Log($"Product currencySymbol: {products[i].currencySymbol}");
            Log($"Product currency: {products[i].currency}");
        }
    }
    private void OnPaymentsFetchPlayerPurcahses(List<FetchPlayerPurcahses> playerPurchases)
    {
        Log("\n --- GS_Payments Fetch GS_Player Purchases --- ");

        for (int i = 0; i < playerPurchases.Count; i++)
        {
            Log($" --------------- ");
            Log($" GS_Player purchase: {i}");

            Log($" GS_Player purchase product ID: {playerPurchases[i].productId}");
            Log($" GS_Player purchase payload: {playerPurchases[i].payload}");
        }
    }



    // --- -> GS_Socials <- ---
    private void OnSocialsJoinCommunity(bool success)
    {
        if (success)
            Log("\n GS_Socials: JoinCommunity Success");
        else
            Log("\n GS_Socials: JoinCommunity was not success");
    }

    private void OnSocialsInvite(bool success)
    {
        if (success)
            Log("\n GS_Socials: Invite Success");
        else
            Log("\n GS_Socials: Invite was not success");
    }

    private void OnSocialsPost(bool success)
    {
        if (success)
            Log("\n GS_Socials: Post Success");
        else
            Log("\n GS_Socials: Post was not success");
    }

    private void OnSocialsShare(bool success)
    {
        if (success)
            Log("\n GS_Socials: Share Success");
        else
            Log("\n GS_Socials: Share was not success");
    }



    // --- -> GS_Ads <- ---
    private void OnAdsStart()
    {
        Log("\n GS_Ads - Start");
    }
    private void OnAdsClose(bool success)
    {
        Log("\n GS_Ads - Close");
    }


    // GS_Ads Sticky
    private void OnAdsStickyStart()
    {
        Log("\n  Sticky: Start");
    }
    private void OnAdsStickyRender()
    {
        Log("\n  Sticky: Render");
    }

    private void OnAdsStickyRefresh()
    {
        Log("\n  Sticky: Refresh");
    }

    private void OnAdsStickyClose()
    {
        Log("\n  Sticky: Close");
    }


    // GS_Ads Reward
    private void OnAdsRewardedStart()
    {
        Log("\n Rewarded: Start");
    }
    private void OnAdsRewardedClose(bool success)
    {
        if (success)
            Log("\n Rewarded: Close Success");
        else
            Log("\n Rewarded: Close was not success");
    }
    private void OnRewarded(string Tag)
    {
        Log($"Reward tag is : {Tag}");
        Log("Reward: Rewarded");
    }


    // GS_Ads Preloader 
    private void OnAdsPreloaderClose(bool success)
    {
        if (success)
            Log("\n Preloader: Close Success");
        else
            Log("\n Preloader: Close was not success");
    }

    private void OnAdsPreloaderStart()
    {
        Log("\n Preloader: Start");
    }


    // GS_Ads GS_Fullscreen

    private void OnAdsFullscreenStart()
    {
        Log("\n FullScreen - Start");
    }
    private void OnAdsFullscreenClose(bool success)
    {
        if (success)
            Log("\n FullScreen - Close: Success");
        else
            Log("\n FullScreen - Close: Was not success");
    }


    // --- -> GS_Fullscreen <- ---
    private void OnFullscreenChange()
    {
        Log("\n GS_Fullscreen: Changed Success");
    }
    private void OnFullscreenOpen()
    {
        Log("\n GS_Fullscreen: Opened Success");
    }
    private void OnFullscreenClose()
    {
        Log("\n  GS_Fullscreen: Closed Success");
    }



    // --- -> Games Collections <- ---
    private void OnGamesCollectionsOpen()
    {
        Log("\n GS_GamesCollections: Opened Success");
    }

    private void OnGamesCollectionsClose()
    {
        Log("\n  GS_GamesCollections: Closed Success");
    }

    private void OnGamesCollectionsFetch(string idOrTag, GamesCollectionsFetchData fetchData)
    {
        Log("\n --- Games Collections Fetch --- ");

        Log($"Games Collections Fetch Tag: {idOrTag}");

        Log($"Type name: {fetchData.__typename}");
        Log($"ID: {fetchData.id}");
        Log($"Tag: {fetchData.tag}");
        Log($"Name: {fetchData.name}");
        Log($"Description: {fetchData.description}");

        for (int i = 0; i < fetchData.games.Length; i++)
        {
            Log($" --------------- ");
            Log($"Game: {i}");

            Log($"Game ID: {fetchData.games[i].id}");
            Log($"Game url: {fetchData.games[i].url}");
            Log($"Game name: {fetchData.games[i].name}");
            Log($"Game description: {fetchData.games[i].description}");
            Log($"Game icon: {fetchData.games[i].icon}");

        }
    }

    private void OnGamesCollectionsFetchError()
    {
        Log("\n  GS_GamesCollections: Fetch Error");

    }




    // --- -> GS_Achievements <- ---
    private void OnAchievementsClose()
    {
        Log("\n  GS_Achievements: Closed Success");
    }

    private void OnAchievementsOpen()
    {
        Log("\n GS_Achievements: Opened Success");
    }

    private void OnAchievementsUnlockError()
    {
        Log("\n  GS_Achievements: Unlcok Error");
    }


    private void OnAchievementsUnlock(string tag)
    {

        Log("\n  GS_Achievements: Unlcok");
        Log($"Achievement unlock tag: {tag}");
    }

    private void OnAchievementsFetchError()
    {

        Log("\n  GS_Achievements: Fetch Error");

    }

    private void OnAchievementsFetch(List<AchievementsFetch> achievementsFetchData)
    {
        Log("\n --- GS_Achievements Fetch --- ");

        for (int i = 0; i < achievementsFetchData.Count; i++)
        {
            Log($" --------------- ");
            Log($" Achievement: {i}");

            Log($" Id: {achievementsFetchData[i].id}");
            Log($" Icon: {achievementsFetchData[i].icon}");
            Log($" Icon Small: {achievementsFetchData[i].iconSmall}");
            Log($" Tag: {achievementsFetchData[i].tag}");
            Log($" Rare: {achievementsFetchData[i].rare}");
            Log($" Name: {achievementsFetchData[i].name}");
            Log($" Description: {achievementsFetchData[i].description}");
        }

    }

    private void OnAchievementsFetchGroups(List<AchievementsFetchGroups> achievementsFetchGroupsData)
    {
        Log("\n --- GS_Achievements Fetch Groups --- ");

        for (int i = 0; i < achievementsFetchGroupsData.Count; i++)
        {
            Log($"--------------- ");
            Log($"Achievement Group: {i}");

            Log($"Id: {achievementsFetchGroupsData[i].id}");
            Log($"Tag: {achievementsFetchGroupsData[i].tag}");
            Log($"Name: {achievementsFetchGroupsData[i].name}");
            Log($"Description: {achievementsFetchGroupsData[i].description}");
            Log($"achievements: {achievementsFetchGroupsData[i].achievements}");
        }
    }

    private void OnAchievementsFetchPlayer(List<AchievementsFetchPlayer> achievementsFetchPlayerData)
    {
        Log("\n--- GS_Achievements Fetch GS_Player --- ");

        for (int i = 0; i < achievementsFetchPlayerData.Count; i++)
        {
            Log($"--------------- ");
            Log($"Game: {i}");

            Log($"GS_Player Id: {achievementsFetchPlayerData[i].playerId}");
            Log($"Achievement Id: {achievementsFetchPlayerData[i].achievementId}");
            Log($"Created At: {achievementsFetchPlayerData[i].createdAt}");
        }
    }



    // --- -> GS_Leaderboard <- ---
    private void OnLeaderboardOpen()
    {
        Log("\n GS_Leaderboard: Opened Success");
    }


    private List<LeaderBoardFetch> leaderboardData;
    private void OnLeaderboardFetch(string tag, GS_ModelArray model)
    {
        leaderboardData = model.GetArrayList<LeaderBoardFetch>();



        Log("\n --- GS_Leaderboard --- ");

        Log($"Tag: {tag}");

        for (int i = 0; i < leaderboardData.Count; i++)
        {
            Log($"--------------- ");
            Log($"{i}.");

            Log($"GS_Player id: {leaderboardData[i].id}");
            Log($"GS_Player score: {leaderboardData[i].score}");
            Log($"GS_Player name: {leaderboardData[i].name}");
            Log($"GS_Player position: {leaderboardData[i].position}");
            Log($"GS_Player gold: {leaderboardData[i].gold}");
            Log($"GS_Player level: {leaderboardData[i].level}");
        }
    }

    private void OnLeaderboardFetchError()
    {
        Log("\n GS_Leaderboard Fetch: Error");
    }

    private void OnLeaderboardFetchPlayer(string tag, int leaderboardPlayerRating)
    {
        Log("\n --- GS_Player Rating --- ");
        Log($"Tag: {tag}");
        Log($"GS_Player position: {leaderboardPlayerRating}");
    }
    private void OnLeaderboardFetchPlayerError()
    {
        Log("\n GS_Leaderboard Fetch GS_Player: Error");
    }



    // --- -> Game Score <- ---
    private void OnReady()
    {
        Log("GameScore: Player Ready ");

        Log($"Avatar Generator: {GS_AvatarGenerator.Current()}");

        PlatformInit();
        PaymentsInit();
        SocialsInit();
        AdsInit();
        PlayerInit();

        if (GS_Device.IsMobile())
            Log($"Device: Is Mobile: YES");
        else
            Log($"Device: Is Mobile: NO");

        if (GS_Device.IsDesktop())
            Log($"Device: Is Desktop: YES");
        else
            Log($"Device: Is Desktop: NO");

        if (GS_System.IsAllowedOrigin())
            Log($"System: Is Allowed Origin: YES");
        else
            Log($"System: Is Allowed Origin: NO");

        if (GS_System.IsDev())
            Log($"System: Is Dev: YES");
        else
            Log($"System: Is Dev: NO");

        if (GS_Game.IsPaused())
            Log($"Game Is Paused: YES");
        else
            Log($"Game Is Paused: NO");
    }

    private void PlatformInit()
    {
        Log($"Platform type: {GS_Platform.Type()}");

        if (GS_Platform.HasIntegratedAuth())
            Log($"Platform Has Integrated Auth: YES");
        else
            Log($"Platform Has Integrated Auth: NO");

        if (GS_Platform.IsExternalLinksAllowed())
            Log($"Platform Is External Links Allowed: YES");
        else
            Log($"Platform Is External Links Allowed: NO");
    }

    private void PaymentsInit()
    {
        if (GS_Payments.IsAvailable())
            Log($"GS_Payments Is Available: YES");
        else
            Log($"GS_Payments Is Available: NO");
    }

    private void SocialsInit()
    {
        Log($"\n GS_Socials Community Link: {GS_Socials.CommunityLink()}");

        if (GS_Socials.CanJoinCommunity())
            Log($"GS_Socials Can Join Community: YES");
        else
            Log($"GS_Socials Can Join Community: NO");

        if (GS_Socials.IsSupportsNativeCommunityJoin())
            Log($"GS_Socials Is Supports Native Community Join: YES");
        else
            Log($"GS_Socials Is Supports Native Community Join: NO");

        if (GS_Socials.IsSupportsNativeInvite())
            Log($"GS_Socials Is Supports Native Invite: YES");
        else
            Log($"GS_Socials Is Supports Native Invite: NO");


        if (GS_Socials.IsSupportsNativePosts())
            Log($"GS_Socials Is Supports Native Posts: YES");
        else
            Log($"GS_Socials Is Supports Native Posts: NO");


        if (GS_Socials.IsSupportsNativeShare())
            Log($"GS_Socials Is Supports Native Share: YES");
        else
            Log($"GS_Socials Is Supports Native Share: NO");
    }

    private void AdsInit()
    {
        if (GS_Ads.IsAdblockEnabled())
            Log($"GS_Ads Adblock Enabled: YES");
        else
            Log($"GS_Ads Adblock Enabled: NO");

        if (GS_Ads.IsStickyAvailable())
            Log($"GS_Ads Sticky Available: YES");
        else
            Log($"GS_Ads Sticky Available: NO");

        if (GS_Ads.IsFullscreenAvailable())
            Log($"GS_Ads GS_Fullscreen Available: YES");
        else
            Log($"GS_Ads GS_Fullscreen Available: NO");

        if (GS_Ads.IsRewardedAvailable())
            Log($"GS_Ads Reward Available: YES");
        else
            Log($"GS_Ads Reward Available: NO");

        if (GS_Ads.IsPreloaderAvailable())
            Log($" GS_Ads Preloader Available: YES");
        else
            Log($" GS_Ads Preloader Available: NO");


        if (GS_Ads.IsStickyPlaying())
            Log($" GS_Ads Sticky Playing: YES");
        else
            Log($"GS_Ads Sticky Playing: NO");


        if (GS_Ads.IsFullscreenPlaying())
            Log($"GS_Ads GS_Fullscreen Playing: YES");
        else
            Log($"GS_Ads GS_Fullscreen Playing: NO");


        if (GS_Ads.IsRewardedPlaying())
            Log($"GS_Ads Reward Playing: YES");
        else
            Log($"GS_Ads Reward Playing: NO");


        if (GS_Ads.IsPreloaderPlaying())
            Log($"GS_Ads Preloader Playing: YES");
        else
            Log($"GS_Ads Preloader Playing: NO");
    }

    private void PlayerInit()
    {
        if (GS_Player.IsLoggedIn())
            Log($"GS_Player is logged in: YES");
        else
            Log($"GS_Player is logged in: NO");

        if (GS_Player.IsStub())
            Log($"GS_Player is stub: YES");
        else
            Log($"GS_Player is stub: NO");

        if (GS_Player.HasAnyCredentials())
            Log($"GS_Player has any credentials: YES");
        else
            Log($"GS_Player has any credentials: NO");
    }

    private void OnOverlayReady()
    {
        Log("Overlay: Ready");
    }
    public void Language(string language)
    {
        Log($"\n Current GS_Language: {language}");
    }

    public void ChangeLanguage(string language)
    {
        Log($"\n GS_Language has changed to: {language}");
    }

    private void OnChangeAvatarGenerator(string generator)
    {
        Log($"\n Avatar Generator: {generator}");
    }


    private void OnChangeLanguage(string GS_Language)
    {
        Log($"\n GS_Language has changed to: {GS_Language}");
    }

    private void GameResumed()
    {
        Log("GAME EVENT: RESUMED");
    }

    private void GamePaused()
    {
        Log("GAME EVENT: PAUSED");
    }

    public void Log(string data)
    {
        _console.text += $"\n{data}";
        Debug.Log(data);
    }


}

[System.Serializable]
public struct LeaderBoardFetch
{
    public int id;
    public int score;
    public string name;
    public int position;
    public float gold;
    public int level;
}