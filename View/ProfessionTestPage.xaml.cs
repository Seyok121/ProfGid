using ProfGid.ViewModel;
using ProfGid.Model;
using System.Diagnostics;

namespace ProfGid.View;

public partial class ProfessionTestPage : ContentPage
{
	public ProfessionTestPage()
	{
		InitializeComponent();
	}

    private void OnAnswerSelected(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value && sender is RadioButton radioButton &&
            BindingContext is ProfessionTestViewModel viewModel &&
            radioButton.BindingContext is Answer answer)
        {
            viewModel.SelectedAnswer = answer;
            viewModel.AddScore(answer.ProfessionName);
        }
    }
}