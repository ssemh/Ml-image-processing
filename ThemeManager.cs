using System;
using System.Drawing;
using System.Windows.Forms;

namespace MLImageProcessing
{
    public enum Theme
    {
        Light,
        Dark
    }

    public class ThemeManager
    {
        public Theme CurrentTheme { get; private set; } = Theme.Light;

        // Light Theme Colors
        private readonly Color LightBackground = Color.FromArgb(245, 245, 250);
        private readonly Color LightPanel = Color.White;
        private readonly Color LightText = Color.FromArgb(30, 30, 30);
        private readonly Color LightSecondaryText = Color.FromArgb(100, 100, 100);
        private readonly Color LightBorder = Color.FromArgb(220, 220, 220);
        private readonly Color LightButton = Color.FromArgb(0, 122, 204);
        private readonly Color LightButtonHover = Color.FromArgb(0, 102, 180);
        private readonly Color LightButtonSecondary = Color.FromArgb(108, 117, 125);
        private readonly Color LightButtonSecondaryHover = Color.FromArgb(90, 98, 104);
        private readonly Color LightGroupBox = Color.White;
        private readonly Color LightTextBox = Color.White;
        private readonly Color LightNumericUpDown = Color.White;

        // Dark Theme Colors
        private readonly Color DarkBackground = Color.FromArgb(30, 30, 35);
        private readonly Color DarkPanel = Color.FromArgb(40, 40, 45);
        private readonly Color DarkText = Color.FromArgb(240, 240, 240);
        private readonly Color DarkSecondaryText = Color.FromArgb(180, 180, 180);
        private readonly Color DarkBorder = Color.FromArgb(60, 60, 65);
        private readonly Color DarkButton = Color.FromArgb(0, 122, 204);
        private readonly Color DarkButtonHover = Color.FromArgb(0, 142, 224);
        private readonly Color DarkButtonSecondary = Color.FromArgb(70, 80, 90);
        private readonly Color DarkButtonSecondaryHover = Color.FromArgb(90, 100, 110);
        private readonly Color DarkGroupBox = Color.FromArgb(40, 40, 45);
        private readonly Color DarkTextBox = Color.FromArgb(50, 50, 55);
        private readonly Color DarkNumericUpDown = Color.FromArgb(50, 50, 55);

        public Color BackgroundColor => CurrentTheme == Theme.Light ? LightBackground : DarkBackground;
        public Color PanelColor => CurrentTheme == Theme.Light ? LightPanel : DarkPanel;
        public Color TextColor => CurrentTheme == Theme.Light ? LightText : DarkText;
        public Color SecondaryTextColor => CurrentTheme == Theme.Light ? LightSecondaryText : DarkSecondaryText;
        public Color BorderColor => CurrentTheme == Theme.Light ? LightBorder : DarkBorder;
        public Color ButtonColor => CurrentTheme == Theme.Light ? LightButton : DarkButton;
        public Color ButtonHoverColor => CurrentTheme == Theme.Light ? LightButtonHover : DarkButtonHover;
        public Color ButtonSecondaryColor => CurrentTheme == Theme.Light ? LightButtonSecondary : DarkButtonSecondary;
        public Color ButtonSecondaryHoverColor => CurrentTheme == Theme.Light ? LightButtonSecondaryHover : DarkButtonSecondaryHover;
        public Color GroupBoxColor => CurrentTheme == Theme.Light ? LightGroupBox : DarkGroupBox;
        public Color TextBoxColor => CurrentTheme == Theme.Light ? LightTextBox : DarkTextBox;
        public Color NumericUpDownColor => CurrentTheme == Theme.Light ? LightNumericUpDown : DarkNumericUpDown;

        public void ToggleTheme()
        {
            CurrentTheme = CurrentTheme == Theme.Light ? Theme.Dark : Theme.Light;
        }

        public void SetTheme(Theme theme)
        {
            CurrentTheme = theme;
        }

        public void ApplyTheme(Form form)
        {
            form.BackColor = BackgroundColor;
            form.ForeColor = TextColor;

            foreach (Control control in form.Controls)
            {
                ApplyThemeToControl(control);
            }
        }

        private void ApplyThemeToControl(Control control)
        {
            // Labels
            if (control is Label label)
            {
                label.ForeColor = TextColor;
                // Use transparent background for labels to ensure visibility
                label.BackColor = Color.Transparent;
                // Ensure label is visible
                label.Visible = true;
            }

            // Buttons
            if (control is Button button)
            {
                if (button.Name == "btnMLProcess" || button.Name == "btnThemeToggle")
                {
                    button.BackColor = ButtonColor;
                    button.ForeColor = Color.White;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.MouseOverBackColor = ButtonHoverColor;
                }
                else
                {
                    button.BackColor = ButtonSecondaryColor;
                    button.ForeColor = Color.White;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.MouseOverBackColor = ButtonSecondaryHoverColor;
                }
            }

            // TextBoxes
            if (control is TextBox textBox)
            {
                textBox.BackColor = TextBoxColor;
                textBox.ForeColor = TextColor;
                textBox.BorderStyle = BorderStyle.FixedSingle;
            }

            // NumericUpDown
            if (control is NumericUpDown numericUpDown)
            {
                numericUpDown.BackColor = NumericUpDownColor;
                numericUpDown.ForeColor = TextColor;
            }

            // GroupBox
            if (control is GroupBox groupBox)
            {
                groupBox.BackColor = GroupBoxColor;
                groupBox.ForeColor = TextColor;
            }

            // PictureBox
            if (control is PictureBox pictureBox)
            {
                pictureBox.BackColor = PanelColor;
            }

            // Recursively apply to child controls
            foreach (Control child in control.Controls)
            {
                ApplyThemeToControl(child);
            }
        }
    }
}

