/*****************************************************************************************************
 SMFを解析する
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIDI2FTM
{
    public class SMFAnalyzer
    {
        private int byteCounter;            // 現在参照しているバイト
        //private byte eventsNum;           // イベントID                                        
        private EventData eventData;        // イベント構造体
        private string consoleWrite;        // コンソール出力用

        //----------------------------------------------------------------------------------------------------
        // 解析する♪
        //----------------------------------------------------------------------------------------------------
        public bool AnalyzingSMF(ref byte[] _byteStream)
        {
            // トラックの配列を作成
            SMFData.Tracks = new List<Tracks>(20);
            SMFData.Name = new List<string>(20);

            Console.WriteLine("========SMFの解析開始========");
            
            // SMFかどうか
            if (checkChunkType(ref _byteStream) != "MThd")
            {
                Console.WriteLine("これはSMFではありません");
                Console.WriteLine("========SMFの解析終了========");
                return false;
            }

            // MThdのヘッダチャンクを解析
            analyzingMThd(ref _byteStream);

            // トラックの数だけ繰り返す
            for (int i = 0; i + 1 <= SMFHeader.Data.Tracks; i++)
            {
                // トラックチャンクかどうか
                if (checkChunkType(ref _byteStream) != "MTrk")
                {
                    Console.WriteLine("SMFが破損しています");
                    Console.WriteLine("========SMFの解析終了========");
                    //エラーダイアログを表示する
                    MessageBox.Show("MIDIファイルの読み込みに失敗しました。" + Environment.NewLine +
                        "データが破損している可能性があります。",
                        "エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }

                // 新しいトラックを配列に追加
                SMFData.Tracks.Add(new Tracks());

                // イベントの配列を作成
                SMFData.Tracks[i].Event = new List<EventData>(1000);
                
                // MTrkのデータチャンクを解析
                analyzingMTrk(ref _byteStream, i);
            }
            
            Console.WriteLine("========SMFの解析終了========");
            return true;
        }

        //----------------------------------------------------------------------------------------------------
        // チャンクタイプを取得
        //----------------------------------------------------------------------------------------------------
        private string checkChunkType(ref byte[] _byteStream)
        {
            // チャンクタイプの文字列を取得
            string chunkType = asciiCodeConverter(ref _byteStream, 4);

            Console.WriteLine("ChunkType = " + chunkType);
            // 4バイト進める
            byteCounter += 4;
            
            return chunkType;
        }
        //----------------------------------------------------------------------------------------------------
        // チャンクタイプMThdを解析 (4byte)
        //----------------------------------------------------------------------------------------------------
        private void analyzingMThd(ref byte[] _byteStream)
        {
            // データ長を取得
            getDataLength(ref _byteStream);
            // フォーマットを取得
            getFormat(ref _byteStream);
            // トラック数を取得
            SMFHeader.Data.Tracks = getTracks(ref _byteStream);
            // 分解能を取得
            SMFHeader.Data.Division = getDivision(ref _byteStream);
        }
        //----------------------------------------------------------------------------------------------------
        // ヘッダからデータ長を取得 (4byte)
        //----------------------------------------------------------------------------------------------------
        private uint getDataLength(ref byte[] _byteStream)
        {
            // バイトオーダーを逆にして4バイトをuintに格納
            uint dataLength = BitConverter.ToUInt32(reverseByteOrder(ref _byteStream, byteCounter, 4), 0);

            Console.WriteLine("DataLength = " + dataLength);
            // 4バイト進める
            byteCounter += 4;

            return dataLength;
        }
        //----------------------------------------------------------------------------------------------------
        // ヘッダからフォーマットを取得 (2byte)
        //----------------------------------------------------------------------------------------------------
        private ushort getFormat(ref byte[] _byteStream)
        {
            // バイトオーダーを逆にして2バイトをushortに格納
            ushort format = BitConverter.ToUInt16(reverseByteOrder(ref _byteStream, byteCounter, 2), 0);

            Console.WriteLine("Format = " + format);
            // 2バイト進める
            byteCounter += 2;

            return format;
        }
        //----------------------------------------------------------------------------------------------------
        // ヘッダからトラック数を取得 (2byte)
        //----------------------------------------------------------------------------------------------------
        private ushort getTracks(ref byte[] _byteStream)
        {
            // バイトオーダーを逆にして2バイトをushortに格納
            ushort tracks = BitConverter.ToUInt16(reverseByteOrder(ref _byteStream, byteCounter, 2), 0);

            Console.WriteLine("Tracks = " + tracks);
            // 2バイト進める
            byteCounter += 2;

            return tracks;
        }
        //----------------------------------------------------------------------------------------------------
        // ヘッダから分解能を取得 (2byte)
        //----------------------------------------------------------------------------------------------------
        private ushort getDivision(ref byte[] _byteStream)
        {
            // バイトオーダーを逆にして2バイトをushortに格納
            ushort resolution = BitConverter.ToUInt16(reverseByteOrder(ref _byteStream, byteCounter, 2), 0);

            Console.WriteLine("TPQN = " + resolution);
            // 2バイト進める
            byteCounter += 2;

            return resolution;
        }
        //----------------------------------------------------------------------------------------------------
        // チャンクタイプMTrkを解析
        //----------------------------------------------------------------------------------------------------
        private void analyzingMTrk(ref byte[] _byteStream, int _i)
        {
            // データ長を取得
            long dataLength = getDataLength(ref _byteStream);
            
            // トラックデータを解析
            while (dataLength > 0)
            {
                // 初期化
                // eventData.EventID = 0; 初期化しない（ランニングステータスルール）
                eventData.DeltaTime = 0;
                eventData.Measure = 0;
                eventData.Tick = 0;
                eventData.Gate = 0;
                eventData.Number = 0;
                eventData.Value = 0;
                eventData.Value2 = 0;
                eventData.Text = null;
                consoleWrite = null;

                // デルタタイムを取得
                getDeltaTime(ref _byteStream, ref dataLength);

                // イベントを取得
                getEvents(ref _byteStream, ref dataLength);

                // イベントに応じた処理
                eventsSwitch(ref _byteStream, ref dataLength);

                
                // ノートオフの場合、またはノートオンのボリューム0の場合
                if (eventData.EventID == 0x80 || eventData.EventID == 0x90 && eventData.Value == 0)
                {
                    // ノートオフのデルタイムを代入
                    uint time = eventData.DeltaTime;
                    // 配列を遡り同一ノートまでのデルタタイムの計測
                    for (int i = SMFData.Tracks[_i].Event.Count - 1; i >= 0; i--)
                    {
                        EventData e = SMFData.Tracks[_i].Event[i];
                        // 同一のノートを探す
                        if (e.EventID == 0x90 && e.Number == eventData.Number)
                        {
                            // ゲートタイムを代入してforを抜ける
                            e.Gate = time;
                            SMFData.Tracks[_i].Event[i] = e;
                            break;
                        }
                        // デルタタイムを加算
                        time += e.DeltaTime;
                    }
                }

                // トラック名を取得していたとき
                if (eventData.EventID == 0xFF && eventData.Number == 0x03)
                {
                    SMFData.Name.Add(_i + " : " + eventData.Text);
                }
                // 新しいイベントを配列に追加
                SMFData.Tracks[_i].Event.Add(eventData);
                // ログ出力
                //Console.WriteLine(consoleWrite);
            }
        }

        //----------------------------------------------------------------------------------------------------
        // デルタタイムを取得する
        //----------------------------------------------------------------------------------------------------
        private void getDeltaTime(ref byte[] _byteStream, ref long _dataLength)
        {
            // 可変長の値を取得
            uint deltaTime = getVariableLength(ref _byteStream, ref _dataLength);
            
            eventData.DeltaTime = deltaTime;
            consoleWrite += "DeltaTime = " + deltaTime + ", ";
        }

        //----------------------------------------------------------------------------------------------------
        // 可変長の値を取得する (1byte - 4byte)
        //----------------------------------------------------------------------------------------------------
        private uint getVariableLength(ref byte[] _byteStream, ref long _dataLength)
        {
            uint variableValue;     // 可変長の値
            byte dataLength = 0;    // データ長

            // とりあえず7ビットの値を代入
            variableValue = (uint)_byteStream[byteCounter] & 0x7F;

            // データ長を調べる
            while (dataLength < 2)
            {
                // 8ビット目が1でなければ
                if ((_byteStream[byteCounter + dataLength] & 0x80) != 0x80) break;

                dataLength++;
                // バイト合成
                variableValue = (uint)(_byteStream[byteCounter + dataLength] & 0x7F) | variableValue << 7;
            }
            dataLength++;

            // データ長分のバイト数を進める
            byteCounter += dataLength;
            _dataLength -= dataLength;

            return variableValue;
        }

        //----------------------------------------------------------------------------------------------------
        // イベントを取得する (0byte - 1byte)
        //----------------------------------------------------------------------------------------------------
        private void getEvents(ref byte[] _byteStream, ref long _dataLength)
        {
            // 8ビット目が1ならばイベントを取得する
            if ((_byteStream[byteCounter] & 0x80) == 0x80)
            {
                // イベントIDを代入
                eventData.EventID = _byteStream[byteCounter];

                // 1バイト進める
                byteCounter += 1;
                _dataLength -= 1;
            }
        }

        //----------------------------------------------------------------------------------------------------
        // イベントに応じて処理を分ける
        //----------------------------------------------------------------------------------------------------
        private void eventsSwitch(ref byte[] _byteStream, ref long _dataLength)
        {
            uint dataLength = 0;

            // 11111111 メタイベント
            if ((eventData.EventID & 0xFF) == 0xFF)
            {
                // メタイベントの内容を読み取る
                metaEvents(ref _byteStream, ref _dataLength);
            }
            // 上位4ビットが 1111 未使用
            else if ((eventData.EventID & 0xF0) == 0xF0)
            {
                eventData.EventID = 0xF0;
                // データ長を取得
                dataLength = getVariableLength(ref _byteStream, ref _dataLength);
                consoleWrite += "SysEx(0xF0)";
            }
            // 上位4ビットが 1110 ピッチベンド
            else if ((eventData.EventID & 0xE0) == 0xE0)
            {
                eventData.EventID = 0xE0;
                dataLength = 2;
                // 1バイト目の7ビットと2バイト目の7ビットをビット合成
                short tmp = (short)(_byteStream[byteCounter] & 0x7F | (_byteStream[byteCounter + 1] & 0x7F) << 7);
                // 型に合わせて0調整
                tmp -= 8192;
                
                eventData.Value = tmp;         // ベロシティ
                consoleWrite += "Pitch Bend Change : " + tmp;
            }
            // 上位4ビットが 1101 未使用
            else if ((eventData.EventID & 0xD0) == 0xD0)
            {
                eventData.EventID = 0xD0;
                dataLength = 1;
                consoleWrite += "Channel Pressure";
            }
            // 上位4ビットが 1100 未使用
            else if ((eventData.EventID & 0xC0) == 0xC0)
            {
                eventData.EventID = 0xC0;
                dataLength = 1;
                consoleWrite += "Program Change";
            }
            // 上位4ビットが 1011 コントロールチェンジ
            else if ((eventData.EventID & 0xB0) == 0xB0)
            {
                eventData.EventID = 0xB0;
                dataLength = 2;
                // コントロールチェンジの内容を読み取る
                controlChange(ref _byteStream);
            }
            // 上位4ビットが 1010 未使用
            else if ((eventData.EventID & 0xA0) == 0xA0)
            {
                eventData.EventID = 0xA0;
                dataLength = 2;
                consoleWrite += "Polyphonic Key Pressure";
            }
            // 上位4ビットが 1001 ノート・オン
            else if ((eventData.EventID & 0x90) == 0x90)
            {
                eventData.EventID = 0x90;
                dataLength = 2;
                eventData.Number = _byteStream[byteCounter];       // ノート番号
                eventData.Value = _byteStream[byteCounter + 1];    // ベロシティ
                consoleWrite += "NoteOn : Note = " + NoteNumber.NumberToNoteName(_byteStream[byteCounter]) + ", Velocity = " + _byteStream[byteCounter + 1];
            }
            // 上位4ビットが 1000 ノート・オフ
            else if ((eventData.EventID & 0x80) == 0x80)
            {
                eventData.EventID = 0x80;
                dataLength = 2;
                eventData.Number = _byteStream[byteCounter];       // ノート番号
                consoleWrite += "NoteOff : Note = " + NoteNumber.NumberToNoteName(_byteStream[byteCounter]) + ", Velocity = " + _byteStream[byteCounter + 1];
            }
            else
            {
                consoleWrite += "ありえないイベントを読み込みました";
            }

            byteCounter += (int)dataLength;
            _dataLength -= dataLength;
        }

        //----------------------------------------------------------------------------------------------------
        // メタ・イベント 0xFF
        //----------------------------------------------------------------------------------------------------
        private void metaEvents(ref byte[] _byteStream, ref long _dataLength)
        {
            uint dataLength = 0;
            // イベントタイプを取得
            eventData.Number = _byteStream[byteCounter];
            
            byteCounter += 1;
            _dataLength -= 1;

            // データ長を取得
            dataLength = getVariableLength(ref _byteStream, ref _dataLength);

            switch (eventData.Number)
            {   
                // Sequence Number シーケンス番号。FORMAT 0/1では利用されない
                case 0x00:
                    consoleWrite += "Sequence Number";
                    break;
                // Text コメントなどのテキスト
                case 0x01:
                    eventData.Text = asciiCodeConverter(ref _byteStream, dataLength);
                    consoleWrite += "Text = " + asciiCodeConverter(ref _byteStream, dataLength);
                    break;
                // Copyright Notice 著作権表示
                case 0x02:
                    eventData.Text = asciiCodeConverter(ref _byteStream, dataLength);
                    consoleWrite += "Copyright Notice = " + asciiCodeConverter(ref _byteStream, dataLength);
                    break;
                // Sequence/Track Name シーケンス名・トラック名
                case 0x03:
                    eventData.Text = asciiCodeConverter(ref _byteStream, dataLength);
                    consoleWrite += "Sequence/Track Name = " + asciiCodeConverter(ref _byteStream, dataLength);
                    break;
                // Instrument Name 楽器名
                case 0x04:
                    eventData.Text = asciiCodeConverter(ref _byteStream, dataLength);
                    consoleWrite += "Instrument Name = " + asciiCodeConverter(ref _byteStream, dataLength);
                    break;
                // Lylic 歌詞
                case 0x05:
                    eventData.Text = asciiCodeConverter(ref _byteStream, dataLength);
                    consoleWrite += "Lylic = " + asciiCodeConverter(ref _byteStream, dataLength);
                    break;
                // Marker
                case 0x06:
                    eventData.Text = asciiCodeConverter(ref _byteStream, dataLength);
                    consoleWrite += "Marker = " + asciiCodeConverter(ref _byteStream, dataLength);
                    break;
                // Cue Point
                case 0x07:
                    eventData.Text = asciiCodeConverter(ref _byteStream, dataLength);
                    consoleWrite += "Cue Point = " + asciiCodeConverter(ref _byteStream, dataLength);
                    break;
                // MIDI Channel Prefix
                case 0x20:
                    consoleWrite += "MIDI Channel Prefix";
                    break;
                // 不明なイベントタイプ
                case 0x21:
                    consoleWrite += "不明なイベントタイプ 0x21";
                    break;
                // End of Track トラックチャンクの終わりを示す
                case 0x2F:
                    consoleWrite += "End of Track";
                    break;
                // Set Tempo テンポ
                case 0x51:
                    // 4byteの値を取り出して1byte捨てる
                    uint tmp = BitConverter.ToUInt32(reverseByteOrder(ref _byteStream, byteCounter, 4), 0) >> 8;
                    float tempo = (60000000f / tmp);
                    
                    eventData.Value = tempo;       // テンポ
                    consoleWrite += "Tempo = " + tempo;
                    break;
                // 	SMTPE Offset
                case 0x54:
                    consoleWrite += "SMTPE Offset";
                    break;
                // Time Signature 拍子
                case 0x58:
                    eventData.Value = (float)Math.Pow(2, _byteStream[byteCounter + 1]);           // 分母
                    eventData.Value2 = _byteStream[byteCounter];                                  // 分子
                    consoleWrite += "Time Signature = " + _byteStream[byteCounter] + "/" + Math.Pow(2, _byteStream[byteCounter + 1]);
                    break;
                // Key Signature キー
                case 0x59:
                    consoleWrite += "Key Signature";
                    break;
                // Sequencer-Specific Meta-event
                case 0x7F:
                    consoleWrite += "Sequencer-Specific Meta-event";
                    break;
                // 例外
                default:
                    consoleWrite += "例外のイベントタイプ = " + eventData.Number.ToString("X2");
                    break;
            }

            byteCounter += (int)dataLength;
            _dataLength -= dataLength;
        }

        //----------------------------------------------------------------------------------------------------
        // コントロールチェンジ 0xBn
        //----------------------------------------------------------------------------------------------------
        private void controlChange(ref byte[] _byteStream)
        {
            // コントロールナンバーを取得
            byte number = _byteStream[byteCounter];
            // コントロールの値を取得
            short value = _byteStream[byteCounter + 1];

            // イベントデータを事前に代入
            eventData.EventID = 0xB0;     // イベントID
            eventData.Gate = 0;            // 未使用
            eventData.Number = number;     // コントロールナンバー
            eventData.Value = value;       // 値

            switch (number)
            {
                case 1:
                    consoleWrite += "Control Change : Modulation = " + value;
                    break;
                case 7:
                    consoleWrite += "Control Change : Volume = " + value;
                    break;
                case 11:
                    consoleWrite += "Control Change : Expression = " + value;
                    break;
                default:
                    consoleWrite += "Control Change : 未使用データ = " + value;
                    break;
            }
        }

        //----------------------------------------------------------------------------------------------------
        // アスキーコード変換
        //----------------------------------------------------------------------------------------------------
        private string asciiCodeConverter(ref byte[] _byteStream, uint _dataLength)
        {
            // 文字数が0の場合
            if (_dataLength == 0) return null;

            // データ長のバイト数のアスキーコードを取得
            char[] asciiCode = new char[_dataLength];
            for (int i = 0; i <= _dataLength - 1; i++)
            {
                asciiCode[i] = (char)_byteStream[byteCounter + i];
            }
            return new string(asciiCode);
        }

        //----------------------------------------------------------------------------------------------------
        // バイトオーダーを逆にする
        //----------------------------------------------------------------------------------------------------
        private byte[] reverseByteOrder(ref byte[] _byteStream, int _byteOffset, int _count)
        {
            // 逆にするデータの要素分の配列を作成
            byte[] tmpData = new byte[_count];
            Buffer.BlockCopy(_byteStream, byteCounter, tmpData, 0, _count);
            // バイトオーダーを逆にする
            Array.Reverse(tmpData);

            return tmpData;
        }
    }
}
