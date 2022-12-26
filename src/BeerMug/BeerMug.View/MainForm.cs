using System;
using System.Collections.Generic;
using System.Linq;
using BeerMug.Model;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;
using KompasConnector;
using System.Reflection.Metadata;

namespace BeerMug.View
{
    /// <summary>
    /// Класс взаимодействия с формой.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Экземпляр класса MugParameters.
        /// </summary>
        private MugParameters _beerMugParametrs = new MugParameters();

        /// <summary>
        /// Цвет корректно заполненного поля.
        /// </summary>  
        private Color _correctColor = Color.White;

        /// <summary>
        /// Цвет не корректно заполненного поля.
        /// </summary>  
        private Color _incorrectColor = Color.LightPink;

        /// <summary>
        /// Словарь, cвязывающий параметр пивной кружки и его текстбокс.
        /// </summary>
        private Dictionary<TextBox, Action<double>> _textBox
            = new Dictionary<TextBox, Action<double>>();

        public MainForm()
        {
            InitializeComponent();
            _textBox = new Dictionary<TextBox, Action<double>>();
            _textBox.Add(outerDiametrTextBox, (outerDiametr)
                => _beerMugParametrs.MugNeckDiametr = outerDiametr);
            _textBox.Add(thicknessTextBox, (wallThickness)
                => _beerMugParametrs.WallThickness = wallThickness);
            _textBox.Add(highTextBox, (high)
                => _beerMugParametrs.High = high);
            _textBox.Add(bottomThicknessTextBox, (bottomThickness)
                => _beerMugParametrs.BottomThickness = bottomThickness);
            _textBox.Add(upperRadiusOfTheBottomTextBox, (highBottomDiametr)
                => _beerMugParametrs.HighBottomDiametr = highBottomDiametr);
            _textBox.Add(lowerRadiusOfTheBottomTextBox, (lowBottomDiametr)
                => _beerMugParametrs.BelowBottomRadius = lowBottomDiametr);
        }

        /// <summary>
        /// Валидация текстбоксов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxValidator_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Focus();
            if (textBox.Text == string.Empty || textBox.Text == ",")
            {
                textBox.Text = string.Empty;
                return;
            }
            try
            {
                _textBox[textBox](double.Parse(textBox.Text));
                textBox.BackColor = _correctColor;
                if (textBox == outerDiametrTextBox)
                {
                    TextBoxValidator_TextChanged(thicknessTextBox, e);
                }
                if (textBox == thicknessTextBox)
                {
                    TextBoxValidator_TextChanged(highTextBox, e);
                }
                if (textBox == highTextBox)
                {
                    TextBoxValidator_TextChanged(bottomThicknessTextBox, e);
                }
                if (textBox == bottomThicknessTextBox)
                {
                    TextBoxValidator_TextChanged(upperRadiusOfTheBottomTextBox, e);
                }
                if (textBox == upperRadiusOfTheBottomTextBox)
                {
                    TextBoxValidator_TextChanged(lowerRadiusOfTheBottomTextBox, e);
                }
            }
            catch
            {
                textBox.BackColor = _incorrectColor;
            }
        }

        /// <summary>
        /// Проверка содержания текстбоксом только одной запятой и цифры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckForCommasAndNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsDigit(e.KeyChar))
                && !((e.KeyChar == ',')
                     && (((TextBox)sender).Text.IndexOf(",") == -1)
                    ))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Проверка, чтобы textbox содержал только цифры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IntegerCheck_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsDigit(e.KeyChar))
                && !((e.KeyChar == ',')
                && (((TextBox)sender).Text.IndexOf(",") == 1)
            ))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Обработка нажатия на кнопку Minimum size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinimumSizeButtom_Click(object sender, EventArgs e)
        {
            // to do в модель
            outerDiametrTextBox.Text = _beerMugParametrs.MugNeckDiametrMin.ToString();
            thicknessTextBox.Text = _beerMugParametrs.WallThicknessMin.ToString();
            highTextBox.Text = _beerMugParametrs.HighMin.ToString();
            bottomThicknessTextBox.Text = _beerMugParametrs.BottomThicknessMin.ToString();
            upperRadiusOfTheBottomTextBox.Text = _beerMugParametrs.HighBottomDiametrMin.ToString();
            lowerRadiusOfTheBottomTextBox.Text = _beerMugParametrs.BelowBottomDiametrMin.ToString();
        }

        /// <summary>
        /// Обработка нажатия на кнопку Maximum size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaximumSizeButton_Click(object sender, EventArgs e)
        {
            // to do в модель
            outerDiametrTextBox.Text = _beerMugParametrs.MugNeckDiametrMax.ToString();
            thicknessTextBox.Text = _beerMugParametrs.WallThicknessMax.ToString();
            highTextBox.Text = _beerMugParametrs.HighMax.ToString();
            bottomThicknessTextBox.Text = _beerMugParametrs.BottomThicknessMax.ToString();
            upperRadiusOfTheBottomTextBox.Text = _beerMugParametrs.HighBottomDiametrMax.ToString();
            lowerRadiusOfTheBottomTextBox.Text = _beerMugParametrs.BelowBottomDiametrMax.ToString();
        }

        /// <summary>
        /// Обработка нажатия на кнопку Build button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buildButton_Click(object sender, EventArgs e)
        {
            if (outerDiametrTextBox.Text == string.Empty ||
                 thicknessTextBox.Text == string.Empty ||
                 highTextBox.Text == string.Empty ||
                 bottomThicknessTextBox.Text == string.Empty ||
                 upperRadiusOfTheBottomTextBox.Text == string.Empty ||
                 lowerRadiusOfTheBottomTextBox.Text == string.Empty ||
                 _beerMugParametrs.Errors.Count > 0)
            {
                MessageBox.Show(_beerMugParametrs.Errors.Last().Value, "Error data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                var builder = new BeerMugBuilder();
                builder.Builder(_beerMugParametrs, capTypeComboBox.SelectedItem.ToString());
            }
        }
        // to do выпадающий список не меняется и размер окна фиксирован
        /// <summary>
        /// Ввод значений при загрузке формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // to do в модель
            outerDiametrTextBox.Text = _beerMugParametrs.MugNeckDiametrMin.ToString();
            thicknessTextBox.Text = _beerMugParametrs.WallThicknessMin.ToString();
            highTextBox.Text = _beerMugParametrs.HighMin.ToString();
            bottomThicknessTextBox.Text = _beerMugParametrs.BottomThicknessMin.ToString();
            upperRadiusOfTheBottomTextBox.Text = _beerMugParametrs.HighBottomDiametrMin.ToString();
            lowerRadiusOfTheBottomTextBox.Text = _beerMugParametrs.BelowBottomDiametrMin.ToString();
            capTypeComboBox.Text = "Faceted shape";
        }
    }
}