using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MIDI2FTM
{
    /// <summary>
    /// SMFを解析するクラス
    /// </summary>----------------------------------------------------------------------------------------------------
    public class SMFAnalyzer
    {
        private int m_byteCounter;            // 現在参照しているバイト
        private EventData m_eventData;        // イベント構造体
        private string m_consoleWrite;        // コンソール出力用

        /// <summary>
        /// 解析する♪
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_byteStream">バイナリデータ配列</param>
        /// <returns>解析が成功したらTrue 失敗ならFalseを返す</returns>
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
        
        /// <summary>
        /// チャンクタイプを取得 
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_byteStream">バイナリデータ配列</param>
        /// <returns>チャンクタイプ文字列を返す</returns>
        private string checkChunkType(ref byte[] _byteStream)
        {
            // チャンクタイプの文字列を取得
            string chunkType = asciiCodeConverter(ref _byteStream, 4);

            Console.WriteLine("ChunkType = " + chunkType);
            // 4バイト進める
            m_byteCounter += 4;
            
            return chunkType;
        }

        /// <summary>
        /// チャンクタイプMThdを解析 (4byte) 
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_byteStream">バイナリデータ配列</param>
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

        /// <summary>
        /// ヘッダからデータ長を取得 (4byte)
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_byteStream">バイナリデータ配列</param>
        /// <returns>データ長を返す</returns>
        private uint getDataLength(ref byte[] _byteStream)
        {
            // バイトオーダーを逆にして4バイトをuintに格納
            uint dataLength = BitConverter.ToUInt32(reverseByteOrder(ref _byteStream, m_byteCounter, 4), 0);

            Console.WriteLine("DataLength = " + dataLength);
            // 4バイト進める
            m_byteCounter += 4;

            return dataLength;
        }

        /// <summary>
        /// ヘッダからフォーマットを取得 (2byte)
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_byteStream">バイナリデータ配列</param>
        /// <returns>フォーマットタイプを返す</returns>
        private ushort getFormat(ref byte[] _byteStream)
        {
            // バイトオーダーを逆にして2バイトをushortに格納
            ushort format = BitConverter.ToUInt16(reverseByteOrder(ref _byteStream, m_byteCounter, 2), 0);

            Console.WriteLine("Format = " + format);
            // 2バイト進める
            m_byteCounter += 2;

            return format;
        }
        
        /// <summary>
        /// ヘッダからトラック数を取得 (2byte)
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_byteStream">バイナリデータ配列</param>
        /// <returns>トラック数を返す</returns>
        private ushort getTracks(ref byte[] _byteStream)
        {
            // バイトオーダーを逆にして2バイトをushortに格納
            ushort tracks = BitConverter.ToUInt16(reverseByteOrder(ref _byteStream, m_byteCounter, 2), 0);

            Console.WriteLine("Tracks = " + tracks);
            // 2バイト進める
            m_byteCounter += 2;

            return tracks;
        }
        
        /// <summary>
        /// ヘッダから分解能を取得 (2byte)
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_byteStream">バイナリデータ配列</param>
        /// <returns>分解能を返す</returns>
        private ushort getDivision(ref byte[] _byteStream)
        {
            // バイトオーダーを逆にして2バイトをushortに格納
            ushort resolution = BitConverter.ToUInt16(reverseByteOrder(ref _byteStream, m_byteCounter, 2), 0);

            Console.WriteLine("TPQN = " + resolution);
            // 2バイト進める
            m_byteCounter += 2;

            return resolution;
        }
        
        /// <summary>
        /// チャンクタイプMTrkを解析 
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_byteStream">バイナリデータ配列</param>
        /// <param name="_i">トラック番号</param>
        private void analyzingMTrk(ref byte[] _byteStream, int _trackNum)
        {
            // データ長を取得
            long dataLength = getDataLength(ref _byteStream);
            
            // トラックデータを解析
            while (dataLength > 0)
            {
                // 初期化
                // m_eventData.EventID = 0; 初期化しない（ランニングステータスルール）
                m_eventData.DeltaTime = 0;
                m_eventData.Measure = 0;
                m_eventData.Tick = 0;
                m_eventData.Gate = 0;
                m_eventData.Number = 0;
                m_eventData.Value = 0;
                m_eventData.Value2 = 0;
                m_eventData.Text = null;
                m_consoleWrite = null;

                // デルタタイムを取得
                getDeltaTime(ref _byteStream, ref dataLength);

                // イベントを取得
                getEvents(ref _byteStream, ref dataLength);

                // イベントに応じた処理
                eventsSwitch(ref _byteStream, ref dataLength);

                
                // ノートオフの場合、またはノートオンのボリューム0の場合
                if (m_eventData.EventID == 0x80 || m_eventData.EventID == 0x90 && m_eventData.Value == 0)
                {
                    // ノートオフのデルタイムを代入
                    uint time = m_eventData.DeltaTime;
                    // 配列を遡り同一ノートまでのデルタタイムの計測
                    for (int i = SMFData.Tracks[_trackNum].Event.Count - 1; i >= 0; i--)
                    {
                        EventData e = SMFData.Tracks[_trackNum].Event[i];
                        // 同一のノートを探す
                        if (e.EventID == 0x90 && e.Number == m_eventData.Number)
                        {
                            // ゲートタイムを代入してforを抜ける
                            e.Gate = time;
                            SMFData.Tracks[_trackNum].Event[i] = e;
                            break;
                        }
                        // デルタタイムを加算
                        time += e.DeltaTime;
                    }
                }

                // トラック名を取得していたとき
                if (m_eventData.EventID == 0xFF && m_eventData.Number == 0x03)
                {
                    SMFData.Name.Add(_trackNum + " : " + m_eventData.Text);
                }
                // 新しいイベントを配列に追加
                SMFData.Tracks[_trackNum].Event.Add(m_eventData);
                // ログ出力
                //Console.WriteLine(m_consoleWrite);
            }
        }
        
        /// <summary>
        /// デルタタイムを取得する
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_byteStream">バイナリデータ配列</param>
        /// <param name="_dataLength">データ長</param>
        private void getDeltaTime(ref byte[] _byteStream, ref long _dataLength)
        {
            // 可変長の値を取得
            uint deltaTime = getVariableLength(ref _byteStream, ref _dataLength);
            
            m_eventData.DeltaTime = deltaTime;
            m_consoleWrite += "DeltaTime = " + deltaTime + ", ";
        }

        /// <summary>
        /// 可変長の値を取得する (1byte - 4byte)
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_byteStream">バイナリデータ配列</param>
        /// <param name="_dataLength">データ長</param>
        /// <returns>可変長の値を返す</returns>
        private uint getVariableLength(ref byte[] _byteStream, ref long _dataLength)
        {
            uint variableValue;     // 可変長の値
            byte dataLength = 0;    // データ長

            // とりあえず7ビットの値を代入
            variableValue = (uint)_byteStream[m_byteCounter] & 0x7F;

            // データ長を調べる
            while (dataLength < 2)
            {
                // 8ビット目が1でなければ
                if ((_byteStream[m_byteCounter + dataLength] & 0x80) != 0x80) break;

                dataLength++;
                // バイト合成
                variableValue = (uint)(_byteStream[m_byteCounter + dataLength] & 0x7F) | variableValue << 7;
            }
            dataLength++;

            // データ長分のバイト数を進める
            m_byteCounter += dataLength;
            _dataLength -= dataLength;

            return variableValue;
        }
        
        /// <summary>
        /// イベントを取得する (0byte - 1byte)
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_byteStream">バイナリデータ配列</param>
        /// <param name="_dataLength">データ長</param>
        private void getEvents(ref byte[] _byteStream, ref long _dataLength)
        {
            // 8ビット目が1ならばイベントを取得する
            if ((_byteStream[m_byteCounter] & 0x80) == 0x80)
            {
                // イベントIDを代入
                m_eventData.EventID = _byteStream[m_byteCounter];

                // 1バイト進める
                m_byteCounter += 1;
                _dataLength -= 1;
            }
        }
        
        /// <summary>
        /// イベントに応じて処理を分ける
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_byteStream">バイナリデータ配列</param>
        /// <param name="_dataLength">データ長</param>
        private void eventsSwitch(ref byte[] _byteStream, ref long _dataLength)
        {
            uint dataLength = 0;

            // 11111111 メタイベント
            if ((m_eventData.EventID & 0xFF) == 0xFF)
            {
                // メタイベントの内容を読み取る
                metaEvents(ref _byteStream, ref _dataLength);
            }
            // 上位4ビットが 1111 未使用
            else if ((m_eventData.EventID & 0xF0) == 0xF0)
            {
                m_eventData.EventID = 0xF0;
                // データ長を取得
                dataLength = getVariableLength(ref _byteStream, ref _dataLength);
                m_consoleWrite += "SysEx(0xF0)";
            }
            // 上位4ビットが 1110 ピッチベンド
            else if ((m_eventData.EventID & 0xE0) == 0xE0)
            {
                m_eventData.EventID = 0xE0;
                dataLength = 2;
                // 1バイト目の7ビットと2バイト目の7ビットをビット合成
                short tmp = (short)(_byteStream[m_byteCounter] & 0x7F | (_byteStream[m_byteCounter + 1] & 0x7F) << 7);
                // 型に合わせて0調整
                tmp -= 8192;
                
                m_eventData.Value = tmp;         // ベロシティ
                m_consoleWrite += "Pitch Bend Change : " + tmp;
            }
            // 上位4ビットが 1101 未使用
            else if ((m_eventData.EventID & 0xD0) == 0xD0)
            {
                m_eventData.EventID = 0xD0;
                dataLength = 1;
                m_consoleWrite += "Channel Pressure";
            }
            // 上位4ビットが 1100 未使用
            else if ((m_eventData.EventID & 0xC0) == 0xC0)
            {
                m_eventData.EventID = 0xC0;
                dataLength = 1;
                m_consoleWrite += "Program Change";
            }
            // 上位4ビットが 1011 コントロールチェンジ
            else if ((m_eventData.EventID & 0xB0) == 0xB0)
            {
                m_eventData.EventID = 0xB0;
                dataLength = 2;
                // コントロールチェンジの内容を読み取る
                controlChange(ref _byteStream);
            }
            // 上位4ビットが 1010 未使用
            else if ((m_eventData.EventID & 0xA0) == 0xA0)
            {
                m_eventData.EventID = 0xA0;
                dataLength = 2;
                m_consoleWrite += "Polyphonic Key Pressure";
            }
            // 上位4ビットが 1001 ノート・オン
            else if ((m_eventData.EventID & 0x90) == 0x90)
            {
                m_eventData.EventID = 0x90;
                dataLength = 2;
                m_eventData.Number = _byteStream[m_byteCounter];       // ノート番号
                m_eventData.Value = _byteStream[m_byteCounter + 1];    // ベロシティ
                m_consoleWrite += "NoteOn : Note = " + NoteNumber.NumberToNoteName(_byteStream[m_byteCounter]) + ", Velocity = " + _byteStream[m_byteCounter + 1];
            }
            // 上位4ビットが 1000 ノート・オフ
            else if ((m_eventData.EventID & 0x80) == 0x80)
            {
                m_eventData.EventID = 0x80;
                dataLength = 2;
                m_eventData.Number = _byteStream[m_byteCounter];       // ノート番号
                m_consoleWrite += "NoteOff : Note = " + NoteNumber.NumberToNoteName(_byteStream[m_byteCounter]) + ", Velocity = " + _byteStream[m_byteCounter + 1];
            }
            else
            {
                m_consoleWrite += "ありえないイベントを読み込みました";
            }

            m_byteCounter += (int)dataLength;
            _dataLength -= dataLength;
        }

        /// <summary>
        /// メタ・イベント 0xFF
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_byteStream">バイナリデータ配列</param>
        /// <param name="_dataLength">データ長</param>
        private void metaEvents(ref byte[] _byteStream, ref long _dataLength)
        {
            uint dataLength = 0;
            // イベントタイプを取得
            m_eventData.Number = _byteStream[m_byteCounter];
            
            m_byteCounter += 1;
            _dataLength -= 1;

            // データ長を取得
            dataLength = getVariableLength(ref _byteStream, ref _dataLength);

            switch (m_eventData.Number)
            {   
                // Sequence Number シーケンス番号。FORMAT 0/1では利用されない
                case 0x00:
                    m_consoleWrite += "Sequence Number";
                    break;
                // Text コメントなどのテキスト
                case 0x01:
                    m_eventData.Text = asciiCodeConverter(ref _byteStream, dataLength);
                    m_consoleWrite += "Text = " + asciiCodeConverter(ref _byteStream, dataLength);
                    break;
                // Copyright Notice 著作権表示
                case 0x02:
                    m_eventData.Text = asciiCodeConverter(ref _byteStream, dataLength);
                    m_consoleWrite += "Copyright Notice = " + asciiCodeConverter(ref _byteStream, dataLength);
                    break;
                // Sequence/Track Name シーケンス名・トラック名
                case 0x03:
                    m_eventData.Text = asciiCodeConverter(ref _byteStream, dataLength);
                    m_consoleWrite += "Sequence/Track Name = " + asciiCodeConverter(ref _byteStream, dataLength);
                    break;
                // Instrument Name 楽器名
                case 0x04:
                    m_eventData.Text = asciiCodeConverter(ref _byteStream, dataLength);
                    m_consoleWrite += "Instrument Name = " + asciiCodeConverter(ref _byteStream, dataLength);
                    break;
                // Lylic 歌詞
                case 0x05:
                    m_eventData.Text = asciiCodeConverter(ref _byteStream, dataLength);
                    m_consoleWrite += "Lylic = " + asciiCodeConverter(ref _byteStream, dataLength);
                    break;
                // Marker
                case 0x06:
                    m_eventData.Text = asciiCodeConverter(ref _byteStream, dataLength);
                    m_consoleWrite += "Marker = " + asciiCodeConverter(ref _byteStream, dataLength);
                    break;
                // Cue Point
                case 0x07:
                    m_eventData.Text = asciiCodeConverter(ref _byteStream, dataLength);
                    m_consoleWrite += "Cue Point = " + asciiCodeConverter(ref _byteStream, dataLength);
                    break;
                // MIDI Channel Prefix
                case 0x20:
                    m_consoleWrite += "MIDI Channel Prefix";
                    break;
                // 不明なイベントタイプ
                case 0x21:
                    m_consoleWrite += "不明なイベントタイプ 0x21";
                    break;
                // End of Track トラックチャンクの終わりを示す
                case 0x2F:
                    m_consoleWrite += "End of Track";
                    break;
                // Set Tempo テンポ
                case 0x51:
                    // 4byteの値を取り出して1byte捨てる
                    uint tmp = BitConverter.ToUInt32(reverseByteOrder(ref _byteStream, m_byteCounter, 4), 0) >> 8;
                    float tempo = (float)Math.Round(60000000f / tmp, 3);
                    
                    m_eventData.Value = tempo;       // テンポ
                    m_consoleWrite += "Tempo = " + tempo;
                    break;
                // 	SMTPE Offset
                case 0x54:
                    m_consoleWrite += "SMTPE Offset";
                    break;
                // Time Signature 拍子
                case 0x58:
                    m_eventData.Value = (float)Math.Pow(2, _byteStream[m_byteCounter + 1]);           // 分母
                    m_eventData.Value2 = _byteStream[m_byteCounter];                                  // 分子
                    m_consoleWrite += "Time Signature = " + _byteStream[m_byteCounter] + "/" + Math.Pow(2, _byteStream[m_byteCounter + 1]);
                    break;
                // Key Signature キー
                case 0x59:
                    m_consoleWrite += "Key Signature";
                    break;
                // Sequencer-Specific Meta-event
                case 0x7F:
                    m_consoleWrite += "Sequencer-Specific Meta-event";
                    break;
                // 例外
                default:
                    m_consoleWrite += "例外のイベントタイプ = " + m_eventData.Number.ToString("X2");
                    break;
            }

            m_byteCounter += (int)dataLength;
            _dataLength -= dataLength;
        }
        
        /// <summary>
        /// コントロールチェンジ 0xBn
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_byteStream">バイナリデータ配列</param>
        private void controlChange(ref byte[] _byteStream)
        {
            // コントロールナンバーを取得
            byte number = _byteStream[m_byteCounter];
            // コントロールの値を取得
            short value = _byteStream[m_byteCounter + 1];

            // イベントデータを事前に代入
            m_eventData.EventID = 0xB0;     // イベントID
            m_eventData.Gate = 0;            // 未使用
            m_eventData.Number = number;     // コントロールナンバー
            m_eventData.Value = value;       // 値

            switch (number)
            {
                case 1:
                    m_consoleWrite += "Control Change : Modulation = " + value;
                    break;
                case 7:
                    m_consoleWrite += "Control Change : Volume = " + value;
                    break;
                case 11:
                    m_consoleWrite += "Control Change : Expression = " + value;
                    break;
                default:
                    m_consoleWrite += "Control Change : 未使用データ = " + value;
                    break;
            }
        }
        
        /// <summary>
        /// アスキーコード変換
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_byteStream">バイナリデータ配列</param>
        /// <param name="_dataLength">データ長</param>
        /// <returns>文字列を返す</returns>
        private string asciiCodeConverter(ref byte[] _byteStream, uint _dataLength)
        {
            // 文字数が0の場合
            if (_dataLength == 0) return null;

            // データ長のバイト数のアスキーコードを取得
            char[] asciiCode = new char[_dataLength];
            for (int i = 0; i <= _dataLength - 1; i++)
            {
                asciiCode[i] = (char)_byteStream[m_byteCounter + i];
            }
            return new string(asciiCode);
        }
        
        /// <summary>
        /// バイトオーダーを逆にする
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_byteStream">バイナリデータ配列</param>
        /// <param name="_byteOffset">何バイト目からか</param>
        /// <param name="_count">対象のバイト数</param>
        /// <returns>バイトオーダーを逆にした配列を返す</returns>
        private byte[] reverseByteOrder(ref byte[] _byteStream, int _byteOffset, int _count)
        {
            // 逆にするデータの要素分の配列を作成
            byte[] tmpData = new byte[_count];
            Buffer.BlockCopy(_byteStream, m_byteCounter, tmpData, 0, _count);
            // バイトオーダーを逆にする
            Array.Reverse(tmpData);

            return tmpData;
        }
    }
}
