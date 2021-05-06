using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using TicketBookingApp.Forms;

namespace TicketBookingApp
{
    public partial class MainMenu : Form
    {

        //Feilds 1

        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        //constructor 2
         
        public MainMenu()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7,45);
            panel1.Controls.Add(leftBorderBtn);

            // Form 14

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

        }

        //Structs 8

        private struct RGBColors
        {
        public static Color color1 = Color.FromArgb(172, 126, 241);
        public static Color color2 = Color.FromArgb(249, 118, 176);
        public static Color color3 = Color.FromArgb(253, 138, 114);
        public static Color color4 = Color.FromArgb(95, 77, 221);
        public static Color color5 = Color.FromArgb(249, 88, 155);
        public static Color color6 = Color.FromArgb(24, 161, 251);
        public static Color color7 = Color.FromArgb(173, 255, 47);
        public static Color color8 = Color.FromArgb(60, 179, 113);
        public static Color color9 = Color.FromArgb(143, 188, 143);
        public static Color color10 = Color.FromArgb(50, 205, 50);
        public static Color color11 = Color.FromArgb(50, 205, 50);
        public static Color color12 = Color.FromArgb(0, 250, 154);
        public static Color color13 = Color.FromArgb(0, 255, 127);
        }

        //Methods 3
        private void ActivateButton(object senderBtn, Color color)

        {
            if (senderBtn != null)

            {
                // Activae Previous btn 7
                DisableButton();
                //Button 4

                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37,36,81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                //Left Border Button 5
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                //Icon Current Child Form 11

                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

                  // 6
                private void DisableButton()
                {
                    if(currentBtn !=null)
                    {
                        currentBtn.BackColor = Color.FromArgb(30,9,53);
                        currentBtn.ForeColor = Color.Gainsboro;
                        currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                        currentBtn.IconColor = Color.Gainsboro;
                        currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                        currentBtn.ImageAlign = ContentAlignment.MiddleLeft;

                    }
                }


        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;


        }

            // clicking on btn 9
            private void btnDeshBoard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new FormDeshBoard());
        }

        private void btnAirline_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new FormAirline());
        }

        private void btnAirports_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FormAirPorts());
        }

        private void btnAirlineClass_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new FormAirlineClass());
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm(new FormDepartment());
        }
        private void btnEmployee_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FormEmployee());
        }

        private void btnPlaces_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color7); 
            OpenChildForm(new FormPlaces());
        }

        private void btnPricing_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color8);
            OpenChildForm(new FormPricing());
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color9);
            OpenChildForm(new FormReservation());
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color10);
            OpenChildForm(new FormRoles());
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color11);
            OpenChildForm(new FormSchedule());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color12);
            OpenChildForm(new FormSettings());
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color13);
            OpenChildForm(new FormLogin());
            
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            Reset();
        }
        // Reset Btn 10
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;

            // calling 12
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Home";
        }

        //Drag Mouse 13
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
