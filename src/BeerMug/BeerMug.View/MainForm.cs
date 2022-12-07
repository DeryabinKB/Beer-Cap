using BeerMug.Model;

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
    }
}