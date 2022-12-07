using System;
using System.Collections.Generic;
using System.Linq;
using BeerMug.Model;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace BeerMug.View
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// ���� ���� � ������������ ���������
        /// </summary>
        private Color _incorrectColor = Color.LightPink;

        /// <summary>
        /// ��������� ������ ������.
        /// </summary>
        private readonly MugParameters Parameters;

        /// <summary>
        /// ������ ���� � ������� � ��� ������.
        /// </summary>
        private readonly Dictionary<TextBox, string> TextBoxAndError;

        // <summary>
        /// ������ ���� � ������� � �������������� ��� ���������.
        /// </summary>
        private readonly Dictionary<TextBox, MugParametersType> TextBoxToParameterType;

        public MainForm()
        {
            InitializeComponent();
            Parameters = new MugParameters();
            TextBoxToParameterType = new Dictionary<TextBox, MugParametersType>
            {
                { lowerRadiusOfTheBottomTextBox, MugParametersType.BelowBottomDiametr },
                { upperRadiusOfTheBottomTextBox, MugParametersType.HighBottomDiametr },
                { bottomThicknessTextBox, MugParametersType.BottomThickness },
                { highTextBox, MugParametersType.HeightNeckBottom },
                { thicknessTextBox, MugParametersType.WallThickness },
                { outerDiametrTextBox, MugParametersType.MugNeckDiametr }
            };

            TextBoxAndError = new Dictionary<TextBox, string>
            {
                { lowerRadiusOfTheBottomTextBox, "" },
                { upperRadiusOfTheBottomTextBox, "" },
                { bottomThicknessTextBox, "" },
                { highTextBox, "" },
                { thicknessTextBox, "" },
                { outerDiametrTextBox, "" }
            };

        }

        /// <summary>
        /// ��������� ����������� �������� ��� �������� �����.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            SetDefaultValues(90, 6, 130, 13, 90, 60);
        }

        /// <summary>
        /// ��������� ����������� �������� � �����.
        /// </summary>
        /// <param name="belowBottomDiametrValue">�������� ������� ������� ���</param>
        /// <param name="highBottomDiametrValue">�������� �������� ������� ���</param>
        /// <param name="bottomThicknessValue">�������� ������� ���</param>
        /// <param name="heightNeckBottomValue">�������� ������ ������</param>
        /// <param name="wallThicknessValue">�������� ������� ������ ������</param>
        /// <param name="mugNeckDiametrValue">�������� �������� �������� ������</param>
        private void SetDefaultValues(double belowBottomDiametrValue, double highBottomDiametrValue,
          double bottomThicknessValue, double heightNeckBottomValue, double wallThicknessValue, double mugNeckDiametrValue)
        {
            Parameters.SetParametrValue(MugParametersType.BelowBottomDiametr, belowBottomDiametrValue);
            Parameters.SetParametrValue(MugParametersType.HighBottomDiametr, highBottomDiametrValue);
            Parameters.SetParametrValue(MugParametersType.BottomThickness, bottomThicknessValue);
            Parameters.SetParametrValue(MugParametersType.HeightNeckBottom, heightNeckBottomValue);
            Parameters.SetParametrValue(MugParametersType.WallThickness, wallThicknessValue);
            Parameters.SetParametrValue(MugParametersType.MugNeckDiametr, mugNeckDiametrValue);

            lowerRadiusOfTheBottomTextBox.Text = belowBottomDiametrValue.ToString();
            upperRadiusOfTheBottomTextBox.Text = highBottomDiametrValue.ToString();
            bottomThicknessTextBox.Text = bottomThicknessValue.ToString();
            highTextBox.Text = heightNeckBottomValue.ToString();
            outerDiametrTextBox.Text = mugNeckDiametrValue.ToString();
            thicknessTextBox.Text = wallThicknessValue.ToString();
        }

        /// <summary>
        /// ��������� �������� ����������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetParametr(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            var isType = TextBoxToParameterType.TryGetValue(textBox, out var type);
            double.TryParse(textBox.Text, out var value);
            if (!isType) return;
            try
            {
                Parameters.SetParametrValue(type, value);
                TextBoxAndError[textBox] = "";
                correctLable.Text = "";
            }
            catch (Exception error)
            {
                TextBoxAndError[textBox] = error.Message;
                correctLable.Text = "damn";
                textBox.BackColor = _incorrectColor;

            }
        }

        private bool CheckTextBoxes()
        {
            var isError = true;
            foreach (var item in
                     TextBoxAndError.Where(item => item.Value != ""))
            {
                isError = false;
                correctLable.Text = ($"in the field{item.Key} error: {item.Value}");
            }
            return isError;
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {
            SetDefaultValues(60, 90, 13, 130, 6, 90);
        }

        private void MinimumSizeButtom_Click_1(object sender, EventArgs e)
        {
            SetDefaultValues(80, 5, 100, 10, 80, 50);
        }

        private void MaximumSizeButton_Click_1(object sender, EventArgs e)
        {
            SetDefaultValues(100, 7, 165, 16.5, 100, 70);

        }

        private void AverageSizeButton_Click_1(object sender, EventArgs e)
        {
            SetDefaultValues(90, 6, 132.5, 13.25, 90, 60);
        }

        private void buildButton_Click_1(object sender, EventArgs e)
        {
            if (CheckTextBoxes())
            {
                // call builder
            }
            else
            {
                outerDiametrTextBox.BackColor = _incorrectColor;
                MessageBox.Show(@"Fill all parametrs");
            }
        }

        //private void outerDiametrTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    MugParametersType type = new MugParametersType();
        //    type = MugParametersType.MugNeckDiametr;
        //    double number;
        //    double.TryParse(string.Join("", outerDiametrTextBox.Text.Where(c => char.IsDigit(c))), out number);
        //    Parameters.SetParametrValue(type, number);
        //}

        //private void thicknessTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    MugParametersType type = new MugParametersType();
        //    type = MugParametersType.WallThickness;
        //    double number;
        //    double.TryParse(string.Join("", thicknessTextBox.Text.Where(c => char.IsDigit(c))), out number);
        //    Parameters.SetParametrValue(type, number);
        //}
    }
}