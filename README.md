# VRGuitar

## システム概要
ストローク動作の練習ができるVRエアギターシステム．
Focus3(VRヘッドセット)とVIVE リストトラッカーを装着して利用する．
機械学習により，ユーザーがエアギターをしているときの腕のストローク動作を自動評価し，アドバイスをフィードバックする．


## デモ動画
https://user-images.githubusercontent.com/72312199/225524001-bed490b8-5d7f-444d-956e-bd51fd85f80a.mp4

## データセット
### データ概要
- データ：リアルのギターを演奏しているときの腕のモーションデータ
- ラベル：演奏に対する評価
- 長さ：6秒
- フレーム数：512

### データ収集方法
#### 被験者
大学４年生１０名
##### 被験者のギター歴
- ５年以上：４名
- ２年以上５年未満：２名
- ２年未満：２名
- 未経験：２名

#### データ収集環境
Unityを用いて自動データ収集システムを作成. 

### ラベル付け
ギター経験5年以上の4人の大学4年生に, 演奏を以下の4つの観点から評価してもらい, 点数をつけてもらった.
（結果的に, ひとつのデータに4つのラベルがつくことになる. ）
#### 評価の観点
- リズム
- 手首の振り
- 手首のひねり
- 腕の振り

## ストローク動作の自動評価モデル
双方向LSTMを用いた.

![RegModel](https://github.com/kaz-0704/VRGuitar/assets/72312199/be9611bd-867d-454c-9dab-95ab4376e71a)

