using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIDI2FTM
{
    /// <summary>
    /// EffectDxxを追加するウィンドウ
    /// </summary>----------------------------------------------------------------------------------------------------
    public partial class AddEffectDxxWindow : Form
    {
        /// <summary>各チャンネルのエフェクト使用数</summary>
        private byte[] m_channeEffectCount;

        /// <summary>
        /// コンストラクタ♪
        /// </summary>----------------------------------------------------------------------------------------------------
        public AddEffectDxxWindow(ref string[] _channelList, ref byte[] _channeEffectCount)
        {
            InitializeComponent();

            // エフェクト使用数をメンバーに代入
            m_channeEffectCount = _channeEffectCount;

            // コンボボックスを初期化
            TrackerChannelList.DataSource = _channelList;
        }

        /// <summary>
        /// コンボボックスのインデックスが変わったとき
        /// </summary>----------------------------------------------------------------------------------------------------
        private void TrackerChannelList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 選択したチャンネルのエフェクト使用数が4以上なら
            if (m_channeEffectCount[TrackerChannelList.SelectedIndex] >= 4)
            {
                Button_Apply.Enabled = false;
                Label_Warning.Text = "選択しているチャンネルにはこれ以上エフェクトを追加できません。";
            }
            else
            {
                Button_Apply.Enabled = true;
                Label_Warning.Text = "";
            }
        }

        /// <summary>
        /// 適用する ボタンをくりっくしたとき
        /// </summary>----------------------------------------------------------------------------------------------------
        private void Button_Apply_Click(object sender, EventArgs e)
        {
            // Dxxを出力するチャンネルを設定
            ChannelConfigState.OutPutEffectDxxChannel = (byte)TrackerChannelList.SelectedIndex;
            // 閉じる
            Close();
        }

        /// <summary>
        /// 適用しない ボタンをクリックしたとき
        /// </summary>----------------------------------------------------------------------------------------------------
        private void Button_NotApply_Click(object sender, EventArgs e)
        {
            // 閉じる
            Close();
        }
    }
}
