# MIDI2FTM
MIDIをFamitrackerのFTMにコンバートできるようにしたいなぁ。

任意の設定でMIDIをFTMにコンバートできるようなツールを作成中
コンバート後にFamitrackerでEditがしやすいようにFamitrackerで1行進む音価を指定できたり
同時発音は1音に絞られるので高音優先、低音優先設定とか、1Frameに何小節続くようにするかとか、
連符をエフェクトGで再現したり、あれとかこれとか、なんやかんやできるようにしたい。完成するのかな？

-- 

  
__やることメモ__
* チャンネル設定でできること実装  
* Speedの値が極端すぎてテンポが表現しきれない場合どうすんの？  
  - 最小テンポ、最大テンポを表示してこの範囲内になっちゃうってわかるようにするか。  
    テンポチェンジするにも不可能な範囲がでてきちゃうし、その場合どうしよう。それも範囲内で我慢してもらうしかないな。  
    まぁFamitrackerで表現できないものは出来ないしそれは仕方がないか。  
    途中でSpeedを変更するってことはする予定はないんだけど、いいよね、  
    それ変更できたらコンバートというよりそれはもうエディットだと思う。
* そのうちこっそりパターンのオーダー配列を保持しよう
* 連符がGで表現しきれないときどう丸め込むの？
  - 無理やりねじ込むか。もはや連符がちゃんと表現できてなくても仕方ない
    3連符がある曲なのにSpeedを5とかに設定する人がわるいってことで  
    そこはFamitrackerの基本を知ってる前提で6とか設定しましょうね。
* エフェクト列の追加処理たしかエフェクトは各チャンネルで4つ持てたよね
  - コンバートして、最大で使用したエフェクトの数を記憶しておいて、もう一周して埋める作業かな
* エフェクト足りないときどうするの？ノイズチャンネルとかに追いやる？Fくらいなら追いやってもいいよね  
  - うーん、コンバート後にエフェクト足りなかったよ！ってメッセージをだすかな、ダイアログ？ステータスバー？
* WindowsのスケーリングでGUI崩れるのとか大丈夫か確認、いやそれは最後でいい
* ネームスペース分けたいな、てかフォルダわけたい
* 最終的な出力のことはまだ一切考えてない  
  - 最悪テキスト出力でユーザーがFamitrackerにインポートして使ってもらう形かな  
    FTMのバイナリがどうなってるか知らん。解析してたら時間がかかりすぎるだろう。  
    とりあえずVersion1リリースではテキスト出力だな、できればFamitrackerのパス指定して、  
    Famitrackerで開くみたいなボタン用意してテキストインポートまで自動でできたらな・・・できるのかな？  
    Famitrackerにテキストの引数渡して開くみたいな方法ある？？あったらいいな
* 基本設定からやり直すボタンがほしいかも
* Row highlight , 2nd highlight ほしいかも  設定するというより、最小音価、Speedから算出するか  

--  
  
__済み__
・繰り返し処理で毎回リストビューに触るな → 処理中は描画しないようにした  
・summary書こう → 書いた  
・チャンネルリセット、全体リセット → リセットできるようにした、ちゃんと初期化するようにした  
・処理中はステータスバーになんか出す → メッセージとプログレスバーを実装   

