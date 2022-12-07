using BeerMug.Model;

namespace BeerMug.View
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Цвет поля с некорректным значением
        /// </summary>
        private Color _incorrectColor = Color.LightPink;

        /// <summary>
        /// Параметры пивной кружки.
        /// </summary>
        private readonly MugParameters Parameters;

        /// <summary>
        /// Хранит поле с текстом и его ошибки.
        /// </summary>
        private readonly Dictionary<TextBox, string> TextBoxAndError;

        // <summary>
        /// Хранит поле с текстом и соответстующий тип параметра.
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
    }
}