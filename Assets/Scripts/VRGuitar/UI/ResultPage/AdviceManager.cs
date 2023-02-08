using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace VRGuitar
{
    /// <summary>
    /// アドバイスの表示を管理する
    /// </summary>
    public class AdviceManager : MonoBehaviour
    {
        [SerializeField] private GameObject advicePanel1;
        [SerializeField] private GameObject advicePanel2;
        [SerializeField] private GameObject advicePanel3;
        [SerializeField] private GameObject advicePanel4;
        [SerializeField] private TextMeshProUGUI adviceText1;
        [SerializeField] private TextMeshProUGUI adviceText2;
        [SerializeField] private TextMeshProUGUI adviceText3;
        [SerializeField] private TextMeshProUGUI adviceText4;

        private string rythmAdvice;
        private string yRotationAdvice;
        private string zRotationAdvice;
        private string ForearmAdvice;

        public void InitializeAdvicePanel()
        {
            advicePanel1.SetActive(false);
            advicePanel2.SetActive(false);
            advicePanel3.SetActive(false);
            advicePanel4.SetActive(false);
        }

        public void OpenAdvice(int item)
        {
            switch (item)
            {
                case 0:
                    advicePanel1.SetActive(true);
                    advicePanel2.SetActive(false);
                    advicePanel3.SetActive(false);
                    advicePanel4.SetActive(false);
                    adviceText1.text = rythmAdvice;
                    break;
                case 1:
                    advicePanel1.SetActive(false);
                    advicePanel2.SetActive(true);
                    advicePanel3.SetActive(false);
                    advicePanel4.SetActive(false);
                    adviceText2.text = zRotationAdvice;
                    break;
                case 2:
                    advicePanel1.SetActive(false);
                    advicePanel2.SetActive(false);
                    advicePanel3.SetActive(true);
                    advicePanel4.SetActive(false);
                    adviceText3.text = yRotationAdvice;
                    break;
                case 3:
                    advicePanel1.SetActive(false);
                    advicePanel2.SetActive(false);
                    advicePanel3.SetActive(false);
                    advicePanel4.SetActive(true);
                    adviceText4.text = ForearmAdvice;
                    break;
            }
        }

        public void MakeAdvice(float rythmScore, float zScore, float yScore, float ForearmScore)
        {
            // リズムのアドバイスを決定
            if (rythmScore < 1.5)
            {
                rythmAdvice = "リズムへのアドバイス１\n" +
                    "リズムが大きくずれてしまっています。まずは、ストロークパターンを覚えるところから始めましょう。";
            }
            else  if (rythmScore < 2.5)
            {
                rythmAdvice = "リズムへのアドバイス２\n" +
                    "リズムが大きくずれてしまっています。空ピッキングを意識しながらストロークを行いましょう。";
            }
            else if (rythmScore < 3.5)
            {
                rythmAdvice = "リズムへのアドバイス３\n" +
                    "リズムが少しずれてしまっています。空ピッキングを意識しながらストロークを行いましょう。";
            }
            else if (rythmScore < 4.5)
            {
                rythmAdvice = "リズムへのアドバイス４\n" +
                    "惜しいですね。少しだけリズムがずれてしまっています。\n" +
                    "メトロノームの音をちゃんと聞き、演奏の最後までｓのリズムを一定に保つように意識しましょう。";
            }
            else
            {
                rythmAdvice = "リズムへのアドバイス５\n" +
                    "きれいなリズムで演奏ができています。その調子です！";
            }

            // 手首のy軸回転のアドバイスを決定
            if (yScore < 1.5)
            {
                yRotationAdvice = "手首y軸のアドバイス１";
            }
            else if (yScore < 2.5)
            {
                yRotationAdvice = "手首y軸のアドバイス２";
            }
            else if (yScore < 3.5)
            {
                yRotationAdvice = "手首y軸のアドバイス３";
            }
            else if (yScore < 4.5)
            {
                yRotationAdvice = "手首y軸のアドバイス４";
            }
            else
            {
                yRotationAdvice = "手首y軸のアドバイス５";
            }

            // 手首のz軸回転のアドバイスを決定
            if (zScore < 1.5)
            {
                zRotationAdvice = "手首z軸のアドバイス１";
            }
            else if (zScore < 2.5)
            {
                zRotationAdvice = "手首z軸のアドバイス２";
            }
            else if (zScore < 3.5)
            {
                zRotationAdvice = "手首z軸のアドバイス３";
            }
            else if (zScore < 4.5)
            {
                zRotationAdvice = "手首z軸のアドバイス４";
            }
            else
            {
                zRotationAdvice = "手首z軸のアドバイス５";
            }

            // 前腕のアドバイスを決定
            if (ForearmScore < 1.5)
            {
                ForearmAdvice = "前腕のアドバイス１\n" +
                    "前腕の振りが大きすぎます。腕はコンパクトに振るように心がけましょう。";
            }
            else if (ForearmScore < 2.5)
            {
                ForearmAdvice = "前腕のアドバイス２\n" +
                    "前腕の振りが大きくなっています。腕はコンパクトに振るように心がけましょう。";
            }
            else if (ForearmScore < 3.5)
            {
                ForearmAdvice = "前腕のアドバイス３\n" +
                    "前腕の振りが少し大きくなっています。腕はもう少しコンパクトに振るように心がけましょう。";
            }
            else if (ForearmScore < 4.5)
            {
                ForearmAdvice = "前腕のアドバイス４\n" +
                    "前腕の振りが少し大きくなっています。腕はもう少しコンパクトに振るように心がけましょう。";
            }
            else
            {
                ForearmAdvice = "前腕のアドバイス５\n" +
                    "前腕コンパクトに振ることができていますね。その調子です！";
            }
        }
    }
}

