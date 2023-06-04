using UnityEngine;
using GameScore;
public class GamesCollections : MonoBehaviour
{
    // Все методы вызываются через UI - Games Collections
    // All methods are called via UI - Games Collections

    public void GamesCollectionsOpen(string idOrTag)
    {
        // Tags -  ALL | LOGICAL_GAMES
        GS_GamesCollections.Open(idOrTag);
    }
    public void GamesCollectionsFetch(string idOrTag)
    {
        // Tags -  ALL | LOGICAL_GAMES
        GS_GamesCollections.Fetch(idOrTag);
    }
}
