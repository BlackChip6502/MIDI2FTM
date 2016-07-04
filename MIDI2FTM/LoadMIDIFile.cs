/*****************************************************************************************************
 MIDIファイルを開く
*****************************************************************************************************/
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIDI2FTM
{
    public class LoadMIDIFile
    {
        public string FilePath;        // MIDIファイルのフルパス
        public byte[] ByteStream;      // 開いたMIDIファイルのバイトストリームデータ
        public bool IsOpen = false;    // ファイルを開いたか

        //----------------------------------------------------------------------------------------------------
        // コンストラクタ♪
        //----------------------------------------------------------------------------------------------------
        public LoadMIDIFile()
        {
        }

        //----------------------------------------------------------------------------------------------------
        // ダイアログを開いてパスを取得
        //----------------------------------------------------------------------------------------------------
        public void GetMIDIFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "スタンダードMIDI ファイル(*.mid)|*.mid|すべてのファイル(*.*)|*.*";

            // ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // ファイルパスを取得
                FilePath = ofd.FileName;
                openFile();
            }
        }

        //----------------------------------------------------------------------------------------------------
        // ファイルを開く
        //----------------------------------------------------------------------------------------------------
        private void openFile()
        {
            // ファイルを開く
            FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            try
            {
                // ファイルを読み込むバイト型配列を作成する
                ByteStream = new byte[fs.Length];
                // ファイルの内容をすべて読み込む
                fs.Read(ByteStream, 0, ByteStream.Length);

                Console.WriteLine("MIDIファイルを開きました : " + FilePath);
                IsOpen = true;
            }
            catch (Exception)
            {
                Console.WriteLine("MIDIファイルを開けませんでした : " + FilePath);
            }
            finally
            {
                if (fs != null)
                {
                    // リソースの破棄
                    fs.Close();
                }
            }
        }
    }
}
