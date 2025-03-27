using ProfGid.ViewModel;

namespace ProfGid.View;

public partial class ProfessionTestPage : ContentPage
{
	public ProfessionTestPage()
	{
		InitializeComponent();
	}

    private void OnAnswerSelected(object sender, CheckedChangedEventArgs e)
    {
		if(e.Value && sender is RadioButton radioButton)
		{
			var viewModel = (ProfessionTestViewModel)BindingContext;
			var selectedIndex = radioButton.Value;
			if(selectedIndex is int index)
			{
                var selectedProfession = viewModel.CurrentQuestion.Answers[index].ProfessionName;
                viewModel.AddScore(selectedProfession);
            }

			NextButton.IsEnabled = true;
			FinishButton.IsEnabled = true;
		}
    }
}