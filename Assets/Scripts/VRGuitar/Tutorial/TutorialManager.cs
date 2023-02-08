using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameMainSystem mainSystem;
    [SerializeField] private TextController textController;
    [SerializeField] private GameObject pointer;
    [SerializeField] private GameObject tutorialButton;
    [SerializeField] private GameObject nextButton;
    private TutorialState state;
    private string[] initialSentences;
    private string[] pointerSentences;
    private string[] menuSentences;
    private string[] howToPlaySentences;
    private string[] playingSentences;

    /// <summary>
    /// チュートリアル内の状態
    /// </summary>
    public enum TutorialState
    {
        Begining,
        PointerIntroduction,
        PlayingIntroduction,
    }

    private void Start()
    {
        nextButton.SetActive(false);

        initialSentences = new string[]
        {
            "VRエアギターレッスンへようこそ！",
            "ここでは、システムの使い方を学んでもらいます。",
        };

        pointerSentences = new string[]
        {
            "はじめに、レーザーポインタの操作方法について説明します。",

            "まずは、レーザーポインタを出してみましょう。",
            "右手で握りこぶしを作り、その状態をキープしてください。",
            "いいですね！",
            "このとき、同時にメニュー画面も開かれます。",
            "レーザーポインタは、基本的に親指を立てた状態で動かします。",
            "もう一度握りこぶしのポーズをキープすることで、ポインタを消すことができます。",

            "次は、レーザーポインタを使ってメニュー画面のボタンを押してみましょう。",
            "ポインタをボタンに当てると、ボタンの色が変わります。",
            "その状態で、立ててある親指を倒してみましょう。",
            "これでボタンを押すことができました！",
            "これからまだチュートリアルが続きますが、わかっている部分は"
        };

        menuSentences = new string[]
        {

        };

        howToPlaySentences = new string[]
        {
            "ではいよいよ、ギターの演奏方法に入っていきましょう。",

            "まず、ギターを自分の好きな位置に移動させます。",
            "メニュー画面を開き、'ギター位置変更'をクリックします。",
            "これにより、ギターを動かせるようになります。",
            "左手の親指と人差し指でギターをつまむようにすると、ギターを持つことができます。",
            "そのままギターを自分の演奏しやすい位置に移動させましょう。",
            "ギターのネックとボディのつなぎ目の部分を体の真正面に持ってくると、ひきやすくなると思います。",
            "位置が決まったら、メニュー画面の'位置決定'をクリックしてギターを固定します。",

            "次に、音の鳴らし方について説明します。",
            "ギターのネックの部分を見ると、カラフルな円柱にアルファベットが書かれたものが並んでいると思います。",
            "それらのアルファベットは、ギターのコードを表しています。\n" +
            "（コードは和音とも呼ばれます。）",
            "コードとは、調和する音の組み合わせのことです。",
            "異なるコードを弾き連ねることで、楽曲は作り出されています。",
            "まずは、鳴らすコードを指定します。",
            "円柱に左手で触れると、触れたコードのアルファベットが大きくなります。",
            "その状態で左手の親指を曲げると、円柱の色がひとつだけ変わります。",
            "これが、コードを選択できている状態です。",
            "ここで、右手でギターのボディの穴の開いた部分の弦をはじいてみましょう。",
            "音が鳴りましたね！",
            "左手でコードを指定し、右手で音を鳴らす、これがギターの基本的な動きです。",
            "実際のギターでは、左手の指で弦を抑えることで、コードを指定します。",
        };

        StartCoroutine(StartTutorial());
    }

    public IEnumerator StartTutorial()
    {
        //*************************
        //   チュートリアル冒頭
        //*************************
        // まだポインタを操作できないため、テキストが自動で切り替わる。
        state = TutorialState.Begining;
        textController.SetSenteces(initialSentences);

        for (int i = 0; i <= initialSentences.Length; i++)
        {
            mainSystem.PushText();
            yield return new WaitForSeconds(3.0f);
        }

        //*************************
        // ポインタの使い方の説明
        //*************************
        //state = TutorialState.PointerIntroduction;
        //textController.SetSenteces(pointerSentences);

        //for (int i = 0; i < 3; i++)
        //{
        //    mainSystem.PushText();
        //    yield return new WaitForSeconds(3.0f);
        //}
        //// ポインタを出せたら次へ進む
        //while (true)
        //{
        //    if (pointer.activeSelf)
        //    {
        //        break;
        //    }
        //    yield return null;
        //}
        //for (int i = 0; i <= 6; i++)
        //{
        //    mainSystem.PushText();
        //    yield return new WaitForSeconds(3.0f);
        //}
        //tutorialButton.SetActive(true);
        //Button button = tutorialButton.GetComponent<Button>();
        //// ボタンを押せたら次へ進む
        //while (true)
        //{
        //    if (button.onClick != null)
        //    {
        //        break;
        //    }
        //    yield return null;
        //}
        //for (int i = 0; i <= 1; i++)
        //{
        //    mainSystem.PushText();
        //    yield return new WaitForSeconds(3.0f);
        //}


        //*************************
        // 　演奏方法の説明
        //*************************
        textController.SetSenteces(howToPlaySentences);
        mainSystem.PushText();
        yield return new WaitForSeconds(2.0f);
        nextButton.SetActive(true);

        yield return null;
    }
}
