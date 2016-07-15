using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIDI2FTM
{
    /// <summary>
    /// MIDIファイルを開く
    /// </summary>----------------------------------------------------------------------------------------------------
    public class LoadMIDIFile
    {
        public string m_FilePath;        // MIDIファイルのフルパス
        public byte[] m_ByteStream;      // 開いたMIDIファイルのバイトストリームデータ
        public bool m_IsOpen = false;    // ファイルを開いたか
        
        /// <summary>
        /// コンストラクタ♪ 
        /// </summary>----------------------------------------------------------------------------------------------------
        public LoadMIDIFile()
        {
        }
        
        /// <summary>
        /// ダイアログを開いてパスを取得 
        /// </summary>----------------------------------------------------------------------------------------------------
        public void GetMIDIFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "スタンダードMIDI ファイル(*.mid)|*.mid|すべてのファイル(*.*)|*.*";

            // ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // ファイルパスを取得
                m_FilePath = ofd.FileName;
                openFile();
            }
        }
        
        /// <summary>
        /// ファイルを開く 
        /// </summary>----------------------------------------------------------------------------------------------------
        private void openFile()
        {
            // ファイルを開く
            FileStream fs = new FileStream(m_FilePath, FileMode.Open, FileAccess.Read);
            try
            {
                // ファイルを読み込むバイト型配列を作成する
                m_ByteStream = new byte[fs.Length];
                // ファイルの内容をすべて読み込む
                fs.Read(m_ByteStream, 0, m_ByteStream.Length);

                Console.WriteLine("MIDIファイルを開きました : " + m_FilePath);
                m_IsOpen = true;
            }
            catch (Exception)
            {
                Console.WriteLine("MIDIファイルを開けませんでした : " + m_FilePath);
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
