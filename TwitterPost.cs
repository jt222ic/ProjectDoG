using UnityEngine;
using System.Collections;

public class TwitterPost : MonoBehaviour
{

    // Use this for initialization
    private const string TWITTER_ADDRESS = "https://twitter.com/intent/tweet";
    private const string TWITTER_113 = "https://twitter.com/OneArmy113";
    private const string Facebook = "https://www.facebook.com/OneArmy113/";
    private const string TWEET_LANGUAGE = "en";
    public static string TwitterdescriptionParam;
    private string appStoreLink = "https://play.google.com/store/apps/details?id=com.OneArmy.Dog_Dash";
    string TwitternameParameter = "Dog Dash the ultimate endless puzzle game!";
    public void ShareToTWitter()
    {
        
        Application.OpenURL(TWITTER_ADDRESS + "?text=" + WWW.EscapeURL(TwitternameParameter + "\n" + TwitterdescriptionParam + "" + appStoreLink));
    }
}