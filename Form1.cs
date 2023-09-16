using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.IO;
using WowDotNetAPI;
using WowDotNetAPI.Models;

namespace IlvlCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {



        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == '.')
            { }
            else { e.Handled = e.KeyChar != (char)Keys.Back; }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string sHead = textBox_Head.Text.ToString();
                int Head = Convert.ToInt32(sHead);

                string sNeck = textBox_Neck.Text.ToString();
                int Neck = Convert.ToInt32(sNeck);

                string sShoulder = textBox_Shoulder.Text.ToString();
                int Shoulder = Convert.ToInt32(sShoulder);

                string sBack = textBox_Back.Text.ToString();
                int Back = Convert.ToInt32(sBack);

                string sChest = textBox_Chest.Text.ToString();
                int Chest = Convert.ToInt32(sChest);

                string sWrist = textBox_Wrist.Text.ToString();
                int Wrist = Convert.ToInt32(sWrist);

                string sHands = textBox_Hands.Text.ToString();
                int Hands = Convert.ToInt32(sHands);

                string sWaist = textBox_Waist.Text.ToString();
                int Waist = Convert.ToInt32(sWaist);

                string sLegs = textBox_Legs.Text.ToString();
                int Legs = Convert.ToInt32(sLegs);

                string sFeet = textBox_Feet.Text.ToString();
                int Feet = Convert.ToInt32(sFeet);

                string sFinger = textBox_Finger1.Text.ToString();
                int Finger = Convert.ToInt32(sFinger);

                string sRing = textBox_Finger2.Text.ToString();
                int Ring = Convert.ToInt32(sRing);

                string sTrinket1 = textBox_Trinket1.Text.ToString();
                int Trinket1 = Convert.ToInt32(sTrinket1);

                string sTrinket2 = textBox_Trinket2.Text.ToString();
                int Trinket2 = Convert.ToInt32(sTrinket2);

                string sWeapon = textBox_Weapon.Text.ToString();
                int Weapon = Convert.ToInt32(sWeapon);
                int all = 16;
                int all2 = 15;



                if (string.IsNullOrWhiteSpace(textBox_Offhand.Text) == true)
                {
                    int sumint1 = (Head) + (Neck) + (Shoulder) + (Back) + (Chest) + (Wrist) + (Hands) + (Waist) + (Legs) + (Feet) + (Finger) + (Ring) + (Trinket1) + (Trinket2) + (Weapon);
                    int sumdev = (sumint1) / (all2);
                    string sum = sumdev.ToString();
                    label20.Text = sum;
                    pictureBox9.SendToBack();
                }
                else
                {
                    string sOffhand = textBox_Offhand.Text.ToString();
                    int Offhand = Convert.ToInt32(sOffhand);

                    int sumint1 = (Head) + (Neck) + (Shoulder) + (Back) + (Chest) + (Wrist) + (Hands) + (Waist) + (Legs) + (Feet) + (Finger) + (Ring) + (Trinket1) + (Trinket2) + (Weapon) + (Offhand);
                    int sumdev = (sumint1) / (all);
                    string sum = sumdev.ToString();
                    label20.Text = sum;
                    pictureBox9.BringToFront();
                }
            }
            catch
            {
            }

            try
            {

                Information info = new Information();
                info.Data1 = textBox_Head.Text;
                info.Data2 = textBox_Neck.Text;
                info.Data3 = textBox_Shoulder.Text;
                info.Data4 = textBox_Back.Text;
                info.Data5 = textBox_Chest.Text;
                info.Data6 = textBox_Wrist.Text;
                info.Data7 = textBox_Weapon.Text;
                info.Data8 = textBox_Offhand.Text;
                info.Data9 = textBox_Hands.Text;
                info.Data10 = textBox_Waist.Text;
                info.Data11 = textBox_Legs.Text;
                info.Data12 = textBox_Feet.Text;
                info.Data13 = textBox_Finger1.Text;
                info.Data14 = textBox_Finger2.Text;
                info.Data15 = textBox_Trinket1.Text;
                info.Data16 = textBox_Trinket2.Text;
                SavveXML.Save(info, "data.xml");
            }
            catch
            { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog oFD = new SaveFileDialog();
            oFD.InitialDirectory = @"c:\\";
            oFD.Filter = "Xml Files (*.xml)|*.xml";
            oFD.FilterIndex = 2;
            oFD.RestoreDirectory = true;
            if (oFD.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    Information info = new Information();
                    info.Data1 = textBox_Head.Text;
                    info.Data2 = textBox_Neck.Text;
                    info.Data3 = textBox_Shoulder.Text;
                    info.Data4 = textBox_Back.Text;
                    info.Data5 = textBox_Chest.Text;
                    info.Data6 = textBox_Wrist.Text;
                    info.Data7 = textBox_Weapon.Text;
                    info.Data8 = textBox_Offhand.Text;
                    info.Data9 = textBox_Hands.Text;
                    info.Data10 = textBox_Waist.Text;
                    info.Data11 = textBox_Legs.Text;
                    info.Data12 = textBox_Feet.Text;
                    info.Data13 = textBox_Finger1.Text;
                    info.Data14 = textBox_Finger2.Text;
                    info.Data15 = textBox_Trinket1.Text;
                    info.Data16 = textBox_Trinket2.Text;
                    SavveXML.Save(info, oFD.FileName);
                }
                catch
                { }
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

            resetpanel();

            pictureBox2.Hide();
            pictureBox3.Hide();
            pictureBox4.Hide();
            pictureBox5.Hide();
            pictureBox6.Hide();
            pictureBox7.Hide();
            pictureBox8.Hide();
            pictureBox9.Hide();
            pictureBox10.Hide();
            pictureBox11.Hide();
            pictureBox12.Hide();
            pictureBox13.Hide();
            pictureBox14.Hide();
            pictureBox15.Hide();
            pictureBox16.Hide();
            pictureBox17.Hide();

            labels();
            if (File.Exists("data.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Information));
                FileStream read = new FileStream("data.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
                Information info = (Information)xs.Deserialize(read);
                textBox_Head.Text = info.Data1;
                textBox_Neck.Text = info.Data2;
                textBox_Shoulder.Text = info.Data3;
                textBox_Back.Text = info.Data4;
                textBox_Chest.Text = info.Data5;
                textBox_Wrist.Text = info.Data6;
                textBox_Weapon.Text = info.Data7;
                textBox_Offhand.Text = info.Data8;
                textBox_Hands.Text = info.Data9;
                textBox_Waist.Text = info.Data10;
                textBox_Legs.Text = info.Data11;
                textBox_Feet.Text = info.Data12;
                textBox_Finger1.Text = info.Data13;
                textBox_Finger2.Text = info.Data14;
                textBox_Trinket1.Text = info.Data15;
                textBox_Trinket2.Text = info.Data16;
                read.Close();

            }
            WowExplorer explorer = new WowExplorer(WowDotNetAPI.Region.EU, Locale.en_GB, "jtef7qhubsdfbsb3mntrmqbhbdqcgde2");
            IEnumerable<Realm> enRealm = explorer.GetRealms();
            foreach (var re1alm in enRealm)
            {

                comboBox_Realm.Items.Add(re1alm.Name);
            }
        }
        public void hidelable(Label h)
        {

            var pos = this.PointToScreen(h.Location);
            pos = pictureBox1.PointToClient(pos);
            h.Parent = pictureBox1;
            h.Location = pos;
            h.BackColor = Color.Transparent;
            h.ForeColor = Color.White;
        }
        public void hidelinklable(LinkLabel h)
        {

            var pos = this.PointToScreen(h.Location);
            pos = pictureBox1.PointToClient(pos);
            h.Parent = pictureBox1;
            h.Location = pos;
            h.BackColor = Color.Transparent;
            h.ForeColor = Color.White;
        }
        public void labels()
        {
            hidelable(Head);
            hidelable(label2);
            hidelable(label3);
            hidelable(label4);
            hidelable(label7);
            hidelable(label8);
            hidelable(label17);
            hidelable(label18);
            hidelable(label9);
            hidelable(label10);
            hidelable(label11);
            hidelable(label12);
            hidelable(label13);
            hidelable(label14);
            hidelable(label15);
            hidelable(label16);
            hidelable(label19);
            hidelable(label20);
            hidelinklable(linkLabel1);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = @"c\\";
            openFile.Filter = "Xml Files (*.xml)|*.xml";
            openFile.FilterIndex = 2;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XmlSerializer xs = new XmlSerializer(typeof(Information));
                    FileStream read = new FileStream(openFile.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                    Information info = (Information)xs.Deserialize(read);
                    linkLabel1.Text = openFile.SafeFileName.Replace(".xml", "");
                    textBox_Head.Text = info.Data1;
                    textBox_Neck.Text = info.Data2;
                    textBox_Shoulder.Text = info.Data3;
                    textBox_Back.Text = info.Data4;
                    textBox_Chest.Text = info.Data5;
                    textBox_Wrist.Text = info.Data6;
                    textBox_Weapon.Text = info.Data7;
                    textBox_Offhand.Text = info.Data8;
                    textBox_Hands.Text = info.Data9;
                    textBox_Waist.Text = info.Data10;
                    textBox_Legs.Text = info.Data11;
                    textBox_Feet.Text = info.Data12;
                    textBox_Finger1.Text = info.Data13;
                    textBox_Finger2.Text = info.Data14;
                    textBox_Trinket1.Text = info.Data15;
                    textBox_Trinket2.Text = info.Data16;
                    read.Close();
                }
                catch { }

            }
        }
        public void resetpanel()
        {
            panel1.SendToBack();
            panel2.SendToBack();
            panel3.SendToBack();
            panel4.SendToBack();
            panel5.SendToBack();
            panel6.SendToBack();
            panel7.SendToBack();
            panel8.SendToBack();
            panel9.SendToBack();
            panel10.SendToBack();
            panel11.SendToBack();
            panel12.SendToBack();
            panel13.SendToBack();
            panel14.SendToBack();
            panel15.SendToBack();
            panel16.SendToBack();
            panel17.SendToBack();
            panel18.SendToBack();
            panel19.SendToBack();
            panel20.SendToBack();
            panel21.SendToBack();
            panel22.SendToBack();
            panel23.SendToBack();
            panel24.SendToBack();
            panel25.SendToBack();
            panel26.SendToBack();
            panel27.SendToBack();
            panel28.SendToBack();
            panel29.SendToBack();
            panel30.SendToBack();
            panel31.SendToBack();
            panel32.SendToBack();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            getInfo();
        }
        public void getInfo()
        {
            try
            {
                WowExplorer explorer = new WowExplorer(WowDotNetAPI.Region.EU, Locale.en_GB, "##########################");
                WowDotNetAPI.Models.CharacterItem wow = new CharacterItem();
                string user = textBox_Import.Text;
                string Realm = comboBox_Realm.Text;


                Character item = explorer.GetCharacter(Realm, user, CharacterOptions.GetEverything);
                string image = item.Thumbnail.ToString().Replace("avatar", "profilemain");
                pictureBox1.Load(@"http://render-api-eu.worldofwarcraft.com/static-render/eu/" + image);
                linkLabel1.Links.Clear();
                linkLabel1.Text = user;
                linkLabel1.Links.Add(0, 200, @"http://eu.battle.net/wow/en/character/" + Realm + @"/" + user + @"/simple");
                resetpanel();
                try
                {
                    ////////////////////////HEAD Upgrade Check///////////////////////////////////
                    if (item.Items.Head.TooltipParams.ItemUpgrade.Current.ToString() == "2")
                    {
                        panel2.BringToFront();
                        panel1.BringToFront();
                    }
                    else if (item.Items.Head.TooltipParams.ItemUpgrade.Current.ToString() == "1")
                    {
                        panel1.BringToFront();
                    }
                    ////////////////////////HEAD Upgrade Check///////////////////////////////////
                }
                catch { }
                try
                {
                    ////////////////////////Neck Upgrade Check///////////////////////////////////
                    if (item.Items.Neck.TooltipParams.ItemUpgrade.Current.ToString() == "2")
                    {
                        panel4.BringToFront();
                        panel3.BringToFront();
                    }
                    else if (item.Items.Neck.TooltipParams.ItemUpgrade.Current.ToString() == "1")
                    {
                        panel3.BringToFront();
                    }
                    ////////////////////////Neck Upgrade Check///////////////////////////////////
                }
                catch { }
                try
                {
                    ////////////////////////Shoulder Upgrade Check///////////////////////////////////
                    if (item.Items.Shoulder.TooltipParams.ItemUpgrade.Current.ToString() == "2")
                    {
                        panel6.BringToFront();
                        panel5.BringToFront();
                    }
                    else if (item.Items.Shoulder.TooltipParams.ItemUpgrade.Current.ToString() == "1")
                    {
                        panel5.BringToFront();
                    }
                    ////////////////////////Shoulder Upgrade Check///////////////////////////////////
                }
                catch { }
                try
                {
                    ////////////////////////Back Upgrade Check///////////////////////////////////
                    if (item.Items.Back.TooltipParams.ItemUpgrade.Current.ToString() == "2")
                    {
                        panel8.BringToFront();
                        panel7.BringToFront();
                    }
                    else if (item.Items.Back.TooltipParams.ItemUpgrade.Current.ToString() == "1")
                    {
                        panel7.BringToFront();
                    }
                    ////////////////////////Back Upgrade Check///////////////////////////////////
                }
                catch { }
                try
                {
                    ////////////////////////Chest Upgrade Check///////////////////////////////////
                    if (item.Items.Chest.TooltipParams.ItemUpgrade.Current.ToString() == "2")
                    {
                        panel10.BringToFront();
                        panel9.BringToFront();
                    }
                    else if (item.Items.Chest.TooltipParams.ItemUpgrade.Current.ToString() == "1")
                    {
                        panel9.BringToFront();
                    }
                    ////////////////////////chest Upgrade Check///////////////////////////////////
                }
                catch { }
                try
                {
                    ////////////////////////Wrist Upgrade Check///////////////////////////////////
                    if (item.Items.Wrist.TooltipParams.ItemUpgrade.Current.ToString() == "2")
                    {
                        panel12.BringToFront();
                        panel11.BringToFront();
                    }
                    else if (item.Items.Wrist.TooltipParams.ItemUpgrade.Current.ToString() == "1")
                    {
                        panel11.BringToFront();
                    }
                    ////////////////////////Wrist Upgrade Check///////////////////////////////////
                }
                catch { }
                try
                {
                    ////////////////////////Weapond Upgrade Check///////////////////////////////////
                    if (item.Items.MainHand.TooltipParams.ItemUpgrade.Current.ToString() == "2")
                    {
                        panel14.BringToFront();
                        panel13.BringToFront();
                    }
                    else if (item.Items.MainHand.TooltipParams.ItemUpgrade.Current.ToString() == "1")
                    {
                        panel13.BringToFront();
                    }
                    ////////////////////////Weapon Upgrade Check///////////////////////////////////
                }
                catch { }
                try
                {
                    ////////////////////////Offhand Upgrade Check///////////////////////////////////
                    if (item.Items.OffHand.TooltipParams.ItemUpgrade.Current.ToString() == "2")
                    {
                        panel16.BringToFront();
                        panel15.BringToFront();
                    }
                    else if (item.Items.OffHand.TooltipParams.ItemUpgrade.Current.ToString() == "1")
                    {
                        panel15.BringToFront();
                    }
                    ////////////////////////offhand Upgrade Check///////////////////////////////////
                }
                catch { }
                try
                {
                    ////////////////////////Hands Upgrade Check///////////////////////////////////
                    if (item.Items.Hands.TooltipParams.ItemUpgrade.Current.ToString() == "2")
                    {
                        panel18.BringToFront();
                        panel17.BringToFront();
                    }
                    else if (item.Items.Hands.TooltipParams.ItemUpgrade.Current.ToString() == "1")
                    {
                        panel17.BringToFront();
                    }
                    ////////////////////////Hands Upgrade Check///////////////////////////////////
                }
                catch { }
                try
                {
                    ////////////////////////Waist Upgrade Check///////////////////////////////////
                    if (item.Items.Waist.TooltipParams.ItemUpgrade.Current.ToString() == "2")
                    {
                        panel20.BringToFront();
                        panel19.BringToFront();
                    }
                    else if (item.Items.Waist.TooltipParams.ItemUpgrade.Current.ToString() == "1")
                    {
                        panel19.BringToFront();
                    }
                    ////////////////////////Waist Upgrade Check///////////////////////////////////
                }
                catch { }
                try
                {
                    ////////////////////////Legs Upgrade Check///////////////////////////////////
                    if (item.Items.Legs.TooltipParams.ItemUpgrade.Current.ToString() == "2")
                    {
                        panel22.BringToFront();
                        panel21.BringToFront();
                    }
                    else if (item.Items.Legs.TooltipParams.ItemUpgrade.Current.ToString() == "1")
                    {
                        panel21.BringToFront();
                    }
                    ////////////////////////Legs Upgrade Check///////////////////////////////////
                }
                catch { }
                try
                {
                    ////////////////////////Feet Upgrade Check///////////////////////////////////
                    if (item.Items.Feet.TooltipParams.ItemUpgrade.Current.ToString() == "2")
                    {
                        panel24.BringToFront();
                        panel23.BringToFront();
                    }
                    else if (item.Items.Feet.TooltipParams.ItemUpgrade.Current.ToString() == "1")
                    {
                        panel23.BringToFront();
                    }
                    ////////////////////////feet Upgrade Check///////////////////////////////////
                }
                catch { }
                try
                {
                    ////////////////////////finger1 Upgrade Check///////////////////////////////////
                    if (item.Items.Finger1.TooltipParams.ItemUpgrade.Current.ToString() == "2")
                    {
                        panel26.BringToFront();
                        panel25.BringToFront();
                    }
                    else if (item.Items.Finger1.TooltipParams.ItemUpgrade.Current.ToString() == "1")
                    {
                        panel25.BringToFront();
                    }
                    ////////////////////////Finger1 Upgrade Check///////////////////////////////////
                }
                catch { }
                try
                {
                    ////////////////////////finger2 Upgrade Check///////////////////////////////////
                    if (item.Items.Finger2.TooltipParams.ItemUpgrade.Current.ToString() == "2")
                    {
                        panel28.BringToFront();
                        panel27.BringToFront();
                    }
                    else if (item.Items.Finger2.TooltipParams.ItemUpgrade.Current.ToString() == "1")
                    {
                        panel27.BringToFront();
                    }
                    ////////////////////////finger2 Upgrade Check///////////////////////////////////
                }
                catch { }
                try
                {
                    ////////////////////////Trinket1 Upgrade Check///////////////////////////////////
                    if (item.Items.Trinket1.TooltipParams.ItemUpgrade.Current.ToString() == "2")
                    {
                        panel30.BringToFront();
                        panel29.BringToFront();
                    }
                    else if (item.Items.Trinket1.TooltipParams.ItemUpgrade.Current.ToString() == "1")
                    {
                        panel29.BringToFront();
                    }
                    ////////////////////////trinket1 Upgrade Check///////////////////////////////////
                }
                catch { }
                try
                {
                    ////////////////////////trinket2 Upgrade Check///////////////////////////////////
                    if (item.Items.Trinket2.TooltipParams.ItemUpgrade.Current.ToString() == "2")
                    {
                        panel32.BringToFront();
                        panel31.BringToFront();
                    }
                    else if (item.Items.Trinket2.TooltipParams.ItemUpgrade.Current.ToString() == "1")
                    {
                        panel31.BringToFront();
                    }
                    ////////////////////////Trinket2 Upgrade Check///////////////////////////////////
                }
                catch { }

                string iFinger1 = item.Items.Finger1.ItemLevel.ToString();
                string iFinger2 = item.Items.Finger2.ItemLevel.ToString();
                string iHead = item.Items.Head.ItemLevel.ToString();
                string iBack = item.Items.Back.ItemLevel.ToString();
                string iWrist = item.Items.Wrist.ItemLevel.ToString();
                string iWaist = item.Items.Waist.ItemLevel.ToString();
                string iFeet = item.Items.Feet.ItemLevel.ToString();
                string iChest = item.Items.Chest.ItemLevel.ToString();
                string iWeapon = item.Items.MainHand.ItemLevel.ToString();
                string iShoulders = item.Items.Shoulder.ItemLevel.ToString();
                string iTrinket1 = item.Items.Trinket1.ItemLevel.ToString();
                string iTrinket2 = item.Items.Trinket2.ItemLevel.ToString();
                string iNeck = item.Items.Neck.ItemLevel.ToString();
                string iHands = item.Items.Hands.ItemLevel.ToString();
                try
                {
                    string iOffHand = item.Items.OffHand.ItemLevel.ToString();
                    textBox_Offhand.Text = iOffHand;
                }
                catch
                {
                    textBox_Offhand.Text = "";
                }
                string iLegs = item.Items.Legs.ItemLevel.ToString();

                pictureBox2.Show();
                pictureBox3.Show();
                pictureBox4.Show();
                pictureBox5.Show();
                pictureBox6.Show();
                pictureBox7.Show();
                pictureBox8.Show();
                pictureBox9.Show();
                pictureBox10.Show();
                pictureBox11.Show();
                pictureBox12.Show();
                pictureBox13.Show();
                pictureBox14.Show();
                pictureBox15.Show();
                pictureBox16.Show();
                pictureBox17.Show();

                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox12.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox13.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox14.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox15.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox16.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox17.SizeMode = PictureBoxSizeMode.StretchImage;

                pictureBox2.Load(@"http://media.blizzard.com/wow/icons/56/" + item.Items.Head.Icon + ".jpg");
                pictureBox3.Load(@"http://media.blizzard.com/wow/icons/56/" + item.Items.Neck.Icon + ".jpg");
                pictureBox4.Load(@"http://media.blizzard.com/wow/icons/56/" + item.Items.Shoulder.Icon + ".jpg");
                pictureBox5.Load(@"http://media.blizzard.com/wow/icons/56/" + item.Items.Back.Icon + ".jpg");
                pictureBox6.Load(@"http://media.blizzard.com/wow/icons/56/" + item.Items.Chest.Icon + ".jpg");
                pictureBox7.Load(@"http://media.blizzard.com/wow/icons/56/" + item.Items.Wrist.Icon + ".jpg");
                pictureBox8.Load(@"http://media.blizzard.com/wow/icons/56/" + item.Items.MainHand.Icon + ".jpg");
                try { pictureBox9.Load(@"http://media.blizzard.com/wow/icons/56/" + item.Items.OffHand.Icon + ".jpg"); } catch { }
                pictureBox10.Load(@"http://media.blizzard.com/wow/icons/56/" + item.Items.Hands.Icon + ".jpg");
                pictureBox11.Load(@"http://media.blizzard.com/wow/icons/56/" + item.Items.Waist.Icon + ".jpg");
                pictureBox12.Load(@"http://media.blizzard.com/wow/icons/56/" + item.Items.Legs.Icon + ".jpg");
                pictureBox13.Load(@"http://media.blizzard.com/wow/icons/56/" + item.Items.Feet.Icon + ".jpg");
                pictureBox14.Load(@"http://media.blizzard.com/wow/icons/56/" + item.Items.Finger1.Icon + ".jpg");
                pictureBox15.Load(@"http://media.blizzard.com/wow/icons/56/" + item.Items.Finger2.Icon + ".jpg");
                pictureBox16.Load(@"http://media.blizzard.com/wow/icons/56/" + item.Items.Trinket1.Icon + ".jpg");
                pictureBox17.Load(@"http://media.blizzard.com/wow/icons/56/" + item.Items.Trinket2.Icon + ".jpg");


                textBox_Head.Text = iHead;
                textBox_Neck.Text = iNeck;
                textBox_Shoulder.Text = iShoulders;
                textBox_Back.Text = iBack;
                textBox_Chest.Text = iChest;
                textBox_Wrist.Text = iWrist;
                textBox_Weapon.Text = iWeapon;
                textBox_Hands.Text = iHands;
                textBox_Waist.Text = iWaist;
                textBox_Legs.Text = iLegs;
                textBox_Feet.Text = iFeet;
                textBox_Finger1.Text = iFinger1;
                textBox_Finger2.Text = iFinger2;
                textBox_Trinket1.Text = iTrinket1;
                textBox_Trinket2.Text = iTrinket2;
            }
            catch { }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
            }
            catch { }
        }

        private void comboBox_Realm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getInfo();
            }
        }
    }
}
